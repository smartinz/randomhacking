using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class CustomerJsonConverter : JsonConverter
	{
		public const bool DefaultSerializeAsReference = true;

		private readonly bool _serializeAsReference;
		private readonly CustomerStringConverter _stringConverter;

		public CustomerJsonConverter(CustomerStringConverter stringConverter, bool serializeAsReference)
		{
			_stringConverter = stringConverter;
			_serializeAsReference = serializeAsReference;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Customer)value;
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
			serializer.Serialize(writer, dto);
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Customer ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Customer();
			if(!_serializeAsReference)
			{
				ret.Customerdemographics.Clear(); // items in this collection will be replaced with items from json. This is a "last one wins" policy


				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Customer).IsAssignableFrom(objectType);
		}
	}
}