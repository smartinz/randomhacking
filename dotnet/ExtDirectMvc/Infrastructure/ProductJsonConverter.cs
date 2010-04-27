using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class ProductJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly ProductStringConverter _stringConverter;

		public ProductJsonConverter(ProductStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Product) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Product item)
		{
			return new{
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

		private object BuildReferenceDto(Product item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Product ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Product();
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
			return typeof (Product).IsAssignableFrom(objectType);
		}
	}
}