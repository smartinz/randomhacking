using System;
using ExtMvc.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtMvc.Infrastructure
{
	public class EmployeeJsonConverter : JsonConverter
	{
		private readonly Type _rootType;
		private readonly EmployeeStringConverter _stringConverter;

		public EmployeeJsonConverter(EmployeeStringConverter stringConverter, Type rootType)
		{
			_stringConverter = stringConverter;
			_rootType = rootType;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var item = (Employee) value;
			object dto = FullSerialization() ? BuildFullDto(item) : BuildReferenceDto(item);
			serializer.Serialize(writer, dto);
		}

		private object BuildFullDto(Employee item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				item.EmployeeId,
				item.LastName,
				item.FirstName,
				item.Title,
				item.TitleOfCourtesy,
				item.BirthDate,
				item.HireDate,
				item.Address,
				item.City,
				item.Region,
				item.PostalCode,
				item.Country,
				item.HomePhone,
				item.Extension,
				// item.Photo, // Skip bacause is binary data
								
				item.Notes,
				item.PhotoPath,
				// item.RelatedEmployee, // Skip bacause is inverse association
								
				// item.Employees, // Skip bacause is collection of non detail objects

								
				// item.Territories, // Skip bacause is collection of non detail objects

								
				// item.Orders, // Skip bacause is collection of non detail objects
			};
		}

		private object BuildReferenceDto(Employee item)
		{
			return new{
				StringId = _stringConverter.ToString(item),
				Description = item.ToString(),
			};
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);
			Employee ret = jObject.Property("stringId") != null ? _stringConverter.FromString(jObject.Value<string>("stringId")) : new Employee();
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
			return typeof (Employee).IsAssignableFrom(objectType);
		}
	}
}