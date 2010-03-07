using Castle.Windsor;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ExtMvc.Infrastructure
{
	public class JsonSerializerSettingsBuilder
	{
		private readonly IWindsorContainer _ioc;

		public JsonSerializerSettingsBuilder(IWindsorContainer ioc)
		{
			_ioc = ioc;
		}

		public JsonSerializerSettings BuildFor<T>()
		{
			return new JsonSerializerSettings{
				Converters = _ioc.ResolveAll<JsonConverter>(new{rootType = typeof (T)}),
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}
	}
}