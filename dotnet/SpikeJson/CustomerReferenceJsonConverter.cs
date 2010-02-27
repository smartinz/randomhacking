using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpikeJson
{
	public class CustomerReferenceJsonConverter : JsonConverter
	{
		public static Db Db;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var customer = (Customer) value;
			writer.WriteStartObject();
			writer.WritePropertyName("id");
			writer.WriteValue(customer.Id.ToString());
			writer.WritePropertyName("description");
			writer.WriteValue(customer.Name);
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject load = JObject.Load(reader);
			var id = int.Parse(load.Value<string>("id"));
			var ret = Db.Get<Customer>(id);
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof (Customer);
		}
	}
}