﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpikeJson
{
	public class ItemReferenceJsonConverter : JsonConverter
	{
		private readonly Db _db;

		public ItemReferenceJsonConverter(Db db)
		{
			_db = db;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var customer = (Item)value;
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
			var ret = _db.Get<Item>(id);
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Item).IsAssignableFrom(objectType);
		}
	}
}