using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class CustomerJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly CustomerStringConverter _stringConverter;

		public CustomerJsonConverter(CustomerStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Customer) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Customer item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.CustomerId,
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
				item.Customerdemographics,
				// item.Orders, // Skip bacause is collection of non detail objects
			};
		}

		private object BuildReferenceDto(Customer item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Customer ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Customer();
			if (FullSerialization())
			{
				ret.Customerdemographics.Clear(); // items in this collection will be replaced with items from json. This is a "last one wins" policy


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
			return typeof (Customer).IsAssignableFrom(objectType);
		}
	}
}