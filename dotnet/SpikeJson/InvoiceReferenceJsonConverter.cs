using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpikeJson
{
	public class InvoiceReferenceJsonConverter : JsonConverter
	{
		private readonly Db _db;
		private readonly object _rootValue;
		private readonly bool _serializeValue;

		public InvoiceReferenceJsonConverter(Db db, object rootValue)
		{
			_db = db;
			_rootValue = rootValue;
			_serializeValue = true;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var customer = (Invoice)value;
			writer.WriteStartObject();
			writer.WritePropertyName("id");
			writer.WriteValue(customer.Id.ToString());
			if(ReferenceEquals(value, _rootValue) || _serializeValue)
			{
				writer.WritePropertyName("data");
				serializer.Serialize(writer, value);
			}
			else
			{
				writer.WritePropertyName("description");
				writer.WriteValue(customer.Description);
			}
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Invoice ret;
			var idProperty = jObject.Property("id");
			if(idProperty != null)
			{
				var id = idProperty.Value.Value<int>();
				ret = _db.Get<Invoice>(id);
			}
			else
			{
				ret = new Invoice();
			}
			JProperty dataProperty = jObject.Property("data");
			if(dataProperty != null)
			{
				serializer.Populate(jObject.Property("data").Value.CreateReader(), ret);
			}
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Invoice).IsAssignableFrom(objectType);
		}
	}
}