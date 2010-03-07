using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class TerritoryJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly TerritoryStringConverter _stringConverter;

		public TerritoryJsonConverter(TerritoryStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Territory) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Territory item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.TerritoryId,
				item.TerritoryDescription,
				// item.Employees, // Skip bacause is collection of non detail objects

								
				item.Region,
			};
		}

		private object BuildReferenceDto(Territory item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Territory ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Territory();
			if (FullSerialization())
			{
				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		private bool FullSerialization()
		{
			const bool isDetail = false;
			return isDetail || CanConvert(_rootType);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof (Territory).IsAssignableFrom(objectType);
		}
	}
}