using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class OrderJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly OrderStringConverter _stringConverter;

		public OrderJsonConverter(OrderStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Order) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Order item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.OrderId,
				item.OrderDate,
				item.RequiredDate,
				item.ShippedDate,
				item.Freight,
				item.ShipName,
				item.ShipAddress,
				item.ShipCity,
				item.ShipRegion,
				item.ShipPostalCode,
				item.ShipCountry,
				item.Customer,
				item.Employee,
				// item.Shipper, // Skip bacause is inverse association
			};
		}

		private object BuildReferenceDto(Order item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Order ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Order();
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
			return typeof (Order).IsAssignableFrom(objectType);
		}
	}
}