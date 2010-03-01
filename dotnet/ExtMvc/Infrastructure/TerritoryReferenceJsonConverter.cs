using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class TerritoryReferenceJsonConverter : JsonConverter
	{
		private readonly ExtMvc.Infrastructure.TerritoryStringConverter _stringConverter;

		public TerritoryReferenceJsonConverter(ExtMvc.Infrastructure.TerritoryStringConverter stringConverter)
		{
			_stringConverter = stringConverter;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (ExtMvc.Domain.Territory)value;
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
			return typeof(ExtMvc.Domain.Territory).IsAssignableFrom(objectType);
		}
	}
}