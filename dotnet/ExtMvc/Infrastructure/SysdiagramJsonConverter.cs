using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class SysdiagramJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly SysdiagramStringConverter _stringConverter;

		public SysdiagramJsonConverter(SysdiagramStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Sysdiagram) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Sysdiagram item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.Name,
				item.PrincipalId,
				item.DiagramId,
				item.Version,
				// item.Definition, // Skip bacause is binary data
			};
		}

		private object BuildReferenceDto(Sysdiagram item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Sysdiagram ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Sysdiagram();
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
			return typeof (Sysdiagram).IsAssignableFrom(objectType);
		}
	}
}