using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class ProductJsonConverter : JsonConverter
	{
		public const bool DefaultSerializeAsReference = true;

		private readonly bool _serializeAsReference;
		private readonly ProductStringConverter _stringConverter;

		public ProductJsonConverter(ProductStringConverter stringConverter, bool serializeAsReference)
		{
			_stringConverter = stringConverter;
			_serializeAsReference = serializeAsReference;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Product)value;
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
					item.ProductId,
					item.ProductName,
					item.QuantityPerUnit,
					item.UnitPrice,
					item.UnitsInStock,
					item.UnitsOnOrder,
					item.ReorderLevel,
					item.Discontinued,
					item.Category,
					// item.Supplier, // Skip bacause is inverse association
				};
			}
			serializer.Serialize(writer, dto);
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Product ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Product();
			if(!_serializeAsReference)
			{
				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Product).IsAssignableFrom(objectType);
		}
	}
}