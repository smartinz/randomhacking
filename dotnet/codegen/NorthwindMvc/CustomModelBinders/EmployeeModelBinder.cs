using System;
using System.Web.Mvc;

namespace NorthwindMvc.CustomModelBinders
{
	public class EmployeeModelBinder : DefaultModelBinder
	{
		private readonly IContextStorage _contextStorage;

		public EmployeeModelBinder(IContextStorage contextStorage)
		{
			_contextStorage = contextStorage;
		}

		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult providerResult = bindingContext.ValueProvider[bindingContext.ModelName];
			return _contextStorage.Get().NorthwindWebService.ReadEmployee(Convert.ToInt32(providerResult.AttemptedValue));
		}
	}
}