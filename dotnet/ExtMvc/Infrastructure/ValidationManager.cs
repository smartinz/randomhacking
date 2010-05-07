using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace ExtMvc.Infrastructure
{
	public static class ValidationManager
	{
		public static void Validate(ModelStateDictionary modelState, object entity, string prefix)
		{
			InvalidValue[] invalidValues = Environment.SharedEngineProvider.GetEngine().Validate(entity);

			foreach(InvalidValue invalidValue in invalidValues)
			{
				modelState.AddModelError(prefix + "." + invalidValue.PropertyPath, invalidValue.Message);
			}
		}

		public static PropertyError MakeHierarchical(ModelStateDictionary modelStateDictionary)
		{
			var root = new PropertyError();
			foreach (var kvp in modelStateDictionary)
			{
				PropertyError current = root;
				foreach (string property in kvp.Key.Split('.', '[', ']').Where(k => k != ""))
				{
					int index;
					current = int.TryParse(property, out index) ? current[index] : current[property];
				}
				foreach (ModelError modelError in kvp.Value.Errors)
				{
					current.Errors.Add(modelError);
				}
			}
			return root;
		}

		public static object BuildDictionary(PropertyError root)
		{
			if(root.Indexes.Count > 0)
			{
				var ary = new object[root.Indexes.Keys.Max() + 1];
				foreach(var kvp in root.Indexes)
				{
					ary[kvp.Key] = BuildDictionary(kvp.Value);
				}
				return ary;
			}
			if(root.Properties.Count > 0)
			{
				return root.Properties.ToDictionary(kvp => kvp.Key, kvp => BuildDictionary(kvp.Value));
			}
			return root.BuildMessage();
		}
	}

	public class PropertyError
	{
		public PropertyError()
		{
			Errors = new ModelErrorCollection();
			Properties = new Dictionary<string, PropertyError>();
			Indexes = new Dictionary<int, PropertyError>();
		}

		public ModelErrorCollection Errors { get; set; }
		public Dictionary<string, PropertyError> Properties { get; set; }
		public Dictionary<int, PropertyError> Indexes { get; set; }

		public PropertyError this[string property]
		{
			get
			{
				if(!Properties.ContainsKey(property))
				{
					Properties.Add(property, new PropertyError());
				}
				return Properties[property];
			}
		}

		public PropertyError this[int index]
		{
			get
			{
				if(!Indexes.ContainsKey(index))
				{
					Indexes.Add(index, new PropertyError());
				}
				return Indexes[index];
			}
		}

		public string BuildMessage()
		{
			return string.Join(". ", Errors.Select(e => e.Exception == null ? e.ErrorMessage : e.Exception.Message));
		}
	}
}