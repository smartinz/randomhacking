using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class CategoryJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly CategoryStringConverter _stringConverter;

		public CategoryJsonConverter(CategoryStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Category) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Category item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.CategoryId,
				item.CategoryName,
				item.Description,
				// item.Picture, // Skip bacause is binary data
								
				// item.Products, // Skip bacause is collection of non detail objects
			};
		}

		private object BuildReferenceDto(Category item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Category ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Category();
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
			return typeof (Category).IsAssignableFrom(objectType);
		}
	}
}