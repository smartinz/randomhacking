using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class CustomerDemographicJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly CustomerDemographicStringConverter _stringConverter;

		public CustomerDemographicJsonConverter(CustomerDemographicStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (CustomerDemographic) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(CustomerDemographic item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.CustomerTypeId,
				item.CustomerDesc,
			};
		}

		private object BuildReferenceDto(CustomerDemographic item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			CustomerDemographic ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new CustomerDemographic();
			if (FullSerialization())
			{
				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		private bool FullSerialization()
		{
			const bool isDetail = true;
			return isDetail || CanConvert(_rootType);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof (CustomerDemographic).IsAssignableFrom(objectType);
		}
	}
}