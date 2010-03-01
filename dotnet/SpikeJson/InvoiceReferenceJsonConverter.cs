using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpikeJson
{
	public class InvoiceReferenceJsonConverter : JsonConverter
	{
		private readonly Db _db;

		public InvoiceReferenceJsonConverter(Db db)
		{
			_db = db;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var customer = (Invoice)value;
			writer.WriteStartObject();
			writer.WritePropertyName("id");
			writer.WriteValue(customer.Id.ToString());
			writer.WritePropertyName("description");
			writer.WriteValue(customer.Description);
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject load = JObject.Load(reader);
			var id = int.Parse(load.Value<string>("id"));
			var ret = _db.Get<Invoice>(id);
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Invoice).IsAssignableFrom(objectType);
		}
	}
}