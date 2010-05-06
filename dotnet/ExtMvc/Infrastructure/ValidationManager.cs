using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using System.Linq;

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

		public static IDictionary<string, PropertyError> BuildErrorDictionary(ModelStateDictionary modelStateDictionary)
		{
			var root = new PropertyError();
			foreach(string propertyPath in modelStateDictionary.Keys)
			{
				PropertyError current = root;
				foreach(string property in propertyPath.Split('.'))
				{
					if(!current.Properties.ContainsKey(property))
					{
						current.Properties.Add(property, new PropertyError());
					}
					current = current.Properties[property];
				}
				current.Messages.AddRange(modelStateDictionary[propertyPath].Errors.Select(e => e.ErrorMessage));
			}
			return root.Properties;
		}

		#region Nested type: PropertyTuple

		public class PropertyError
		{
			public List<string> Messages { get; set; }
			public Dictionary<string, PropertyError> Properties { get; set; }

			public PropertyError()
			{
				Messages = new List<string>();
				Properties = new Dictionary<string, PropertyError>();
			}
		}

		#endregion
	}
}