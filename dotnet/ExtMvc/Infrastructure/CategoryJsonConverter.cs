using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class CategoryJsonConverter : JsonConverter
	{
		public const bool DefaultSerializeAsReference = true;

		private readonly bool _serializeAsReference;
		private readonly CategoryStringConverter _stringConverter;

		public CategoryJsonConverter(CategoryStringConverter stringConverter, bool serializeAsReference)
		{
			_stringConverter = stringConverter;
			_serializeAsReference = serializeAsReference;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Category)value;
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
					item.CategoryId,
					item.CategoryName,
					item.Description,
					// item.Picture, // Skip bacause is binary data
										
					// item.Products, // Skip bacause is collection of non detail objects
				};
			}
			serializer.Serialize(writer, dto);
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Category ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Category();
			if(!_serializeAsReference)
			{
				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Category).IsAssignableFrom(objectType);
		}
	}
}