using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class OrderDetailJsonConverter : JsonConverter
	{
		public const bool DefaultSerializeAsReference = true;

		private readonly bool _serializeAsReference;
		private readonly OrderDetailStringConverter _stringConverter;

		public OrderDetailJsonConverter(OrderDetailStringConverter stringConverter, bool serializeAsReference)
		{
			_stringConverter = stringConverter;
			_serializeAsReference = serializeAsReference;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (OrderDetail)value;
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
					item.OrderId,
					item.ProductId,
					item.UnitPrice,
					item.Quantity,
					item.Discount,
				};
			}
			serializer.Serialize(writer, dto);
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			OrderDetail ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new OrderDetail();
			if(!_serializeAsReference)
			{
				serializer.Populate(jObject.CreateReader(), ret);
			}
			return ret;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(OrderDetail).IsAssignableFrom(objectType);
		}
	}
}