using System.Linq;
using System.Web.Mvc;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace ExtMvc.Infrastructure
{
	public static class ValidationManager
	{
		public static void Validate(ModelStateDictionary modelState, object entity, string parameterName)
		{
			InvalidValue[] invalidValues = Environment.SharedEngineProvider.GetEngine().Validate(entity);

			foreach(InvalidValue invalidValue in invalidValues)
			{
				modelState.AddModelError(parameterName + "." + invalidValue.PropertyPath, invalidValue.Message);
			}
		}

		public static PropertyError MakeHierarchical(ModelStateDictionary modelStateDictionary)
		{
			var root = new PropertyError();
			foreach(var kvp in modelStateDictionary.Where(kvp => kvp.Value.Errors.Count > 0))
			{
				PropertyError current = root;
				foreach(string property in kvp.Key.Split('.', '[', ']').Where(k => k != ""))
				{
					int index;
					current = int.TryParse(property, out index) ? current[index] : current[property];
				}
				foreach(ModelError modelError in kvp.Value.Errors)
				{
					current.Errors.Add(modelError);
				}
			}
			return root;
		}

		public static object BuildResponse(ModelStateDictionary modelState)
		{
			return new{
				success = modelState.IsValid,
				errors = BuildDictionary(MakeHierarchical(modelState))
			};
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
}