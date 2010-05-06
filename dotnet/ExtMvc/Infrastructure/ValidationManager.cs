using System.Web.Mvc;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace ExtMvc.Infrastructure
{
	public static class ValidationManager
	{
		public static void Validate(Controller controller, object entity)
		{
			InvalidValue[] invalidValues = Environment.SharedEngineProvider.GetEngine().Validate(entity);
			foreach(InvalidValue invalidValue in invalidValues)
			{
				controller.ModelState.AddModelError(invalidValue.PropertyPath, invalidValue.Message);
			}
		}
	}
}