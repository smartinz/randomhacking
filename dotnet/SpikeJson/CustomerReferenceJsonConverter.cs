using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpikeJson
{
	public class CustomerReferenceJsonConverter : JsonConverter
	{
		public static Db Db;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (IsArray(value.GetType()))
			{
				writer.WriteStartArray();
				var enumerable = (IEnumerable<Customer>) value;
				foreach (Customer customer in enumerable)
				{
					WriteJsonSingle(customer, writer);
				}
				writer.WriteEndArray();
			}
			else
			{
				WriteJsonSingle(value, writer);
			}
		}

		private static void WriteJsonSingle(object value, JsonWriter writer)
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
			int id = int.Parse(load.Value<string>("id"));
			var ret = Db.Get<Customer>(id);
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof (Customer).IsAssignableFrom(objectType) || IsArray(objectType);
		}

		private static bool IsArray(Type objectType)
		{
			return typeof (IEnumerable<Customer>).IsAssignableFrom(objectType);
		}
	}
}