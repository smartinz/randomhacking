using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class RegionJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly RegionStringConverter _stringConverter;

		public RegionJsonConverter(RegionStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Region) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Region item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.RegionId,
				item.RegionDescription,
				// item.Territories, // Skip bacause is collection of non detail objects
			};
		}

		private object BuildReferenceDto(Region item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Region ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Region();
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
			return typeof (Region).IsAssignableFrom(objectType);
		}
	}
}