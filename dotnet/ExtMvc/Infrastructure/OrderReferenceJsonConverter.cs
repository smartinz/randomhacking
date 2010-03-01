using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class OrderReferenceJsonConverter : JsonConverter
	{
		private readonly ExtMvc.Infrastructure.OrderStringConverter _stringConverter;

		public OrderReferenceJsonConverter(ExtMvc.Infrastructure.OrderStringConverter stringConverter)
		{
			_stringConverter = stringConverter;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (ExtMvc.Domain.Order)value;
			writer.WriteStartObject();
			writer.WritePropertyName("id");
			writer.WriteValue(_stringConverter.ToString(item));
			writer.WritePropertyName("description");
			writer.WriteValue(item.ToString());
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject load = JObject.Load(reader);
			return _stringConverter.FromString(load.Value<string>("id"));
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(ExtMvc.Domain.Order).IsAssignableFrom(objectType);
		}
	}
}