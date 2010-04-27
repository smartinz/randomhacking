using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class SupplierJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly SupplierStringConverter _stringConverter;

		public SupplierJsonConverter(SupplierStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Supplier) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Supplier item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.SupplierId,
				item.CompanyName,
				item.ContactName,
				item.ContactTitle,
				item.Address,
				item.City,
				item.Region,
				item.PostalCode,
				item.Country,
				item.Phone,
				item.Fax,
				item.HomePage,
				// item.Products, // Skip bacause is collection of non detail objects
			};
		}

		private object BuildReferenceDto(Supplier item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Supplier ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Supplier();
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
			return typeof (Supplier).IsAssignableFrom(objectType);
		}
	}
}