using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace JQueryMvc.Infrastructure
{
	public class JsonResult2 : ActionResult
	{
		public Encoding ContentEncoding { get; set; }

		public string ContentType { get; set; }

		public object Data { get; set; }

		public override void ExecuteResult(ControllerContext context)
		{
			if(context == null)
			{
				throw new ArgumentNullException("context");
			}

			HttpResponseBase response = context.HttpContext.Response;

			if(!String.IsNullOrEmpty(ContentType))
			{
				response.ContentType = ContentType;
			}
			else
			{
				response.ContentType = "application/json";
			}
			if(ContentEncoding != null)
			{
				response.ContentEncoding = ContentEncoding;
			}
			if(Data != null)
			{
				var jsonSerializerSettings = new JsonSerializerSettings{
					ContractResolver = new CamelCasePropertyNamesContractResolver(),
					Converters = new List<JsonConverter>{ new IsoDateTimeConverter()}
				};
				response.Write(JsonConvert.SerializeObject(Data, Formatting.None, jsonSerializerSettings));
			}
		}
	}
}