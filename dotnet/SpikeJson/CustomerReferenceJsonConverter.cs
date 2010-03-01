using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpikeJson
{
	public class CustomerReferenceJsonConverter : JsonConverter
	{
		private readonly Db _db;

		public CustomerReferenceJsonConverter(Db db)
		{
			_db = db;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var customer = (Customer)value;
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
			int id = int.Parse(load.Value<string>("id"));
			var ret = _db.Get<Customer>(id);
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Customer).IsAssignableFrom(objectType);
		}
	}
}