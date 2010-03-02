using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class TerritoryJsonConverter : JsonConverter
	{
		public const bool DefaultSerializeAsReference = true;

		private readonly bool _serializeAsReference;
		private readonly TerritoryStringConverter _stringConverter;

		public TerritoryJsonConverter(TerritoryStringConverter stringConverter, bool serializeAsReference)
		{
			_stringConverter = stringConverter;
			_serializeAsReference = serializeAsReference;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Territory)value;
			object dto;
			if(_serializeAsReference)
			{
				dto = new{
					StringId = _stringConverter.ToString(item),
					Description = item.ToString(),
				};
			}
			else
			{
				dto = new{
					StringId = _stringConverter.ToString(item),
					item.TerritoryId,
					item.TerritoryDescription,
					// item.Employees, // Skip bacause is collection of non detail objects

										
					item.Region,
				};
			}
			serializer.Serialize(writer, dto);
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Territory ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Territory();
			if(!_serializeAsReference)
			{
				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Territory).IsAssignableFrom(objectType);
		}
	}
}