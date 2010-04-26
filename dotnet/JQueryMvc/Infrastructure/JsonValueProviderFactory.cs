using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace JQueryMvc.Infrastructure
{
	// http://haacked.com/archive/2010/04/15/sending-json-to-an-asp-net-mvc-action-method-argument.aspx
	// This class should be included in MVC 3
	public class JsonValueProviderFactory : ValueProviderFactory
	{
		private static void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, JToken value)
		{
			if(value is JObject)
			{
				var jObject = value as JObject;
				foreach(JProperty jProperty in jObject.Properties())
				{
					AddToBackingStore(backingStore, MakePropertyKey(prefix, jProperty.Name), jProperty.Value);
				}
			}
			else if(value is JArray)
			{
				var jArray = value as JArray;
				for(int i = 0; i < jArray.Count; i++)
				{
					AddToBackingStore(backingStore, MakeArrayKey(prefix, i), jArray[i]);
				}
			}
			else if(value is JValue)
			{
				var jValue = value as JValue;
				backingStore[prefix] = jValue.Value;
			}
			else
			{
				throw new Exception(string.Format("JToken is of unsupported type {0}", value.GetType()));
			}
		}

		private static JObject GetDeserializedJson(ControllerContext controllerContext)
		{
			if(!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
			{
				// not JSON request
				return null;
			}

			var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
			string bodyText = reader.ReadToEnd();
			if(String.IsNullOrEmpty(bodyText))
			{
				// no JSON data
				return null;
			}

			return JObject.Parse(bodyText);
		}

		public override IValueProvider GetValueProvider(ControllerContext controllerContext)
		{
			JObject jsonData = GetDeserializedJson(controllerContext);
			if(jsonData == null)
			{
				return null;
			}

			var backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
			AddToBackingStore(backingStore, String.Empty, jsonData);
			return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
		}

		private static string MakeArrayKey(string prefix, int index)
		{
			return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
		}

		private static string MakePropertyKey(string prefix, string propertyName)
		{
			return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
		}
	}
}