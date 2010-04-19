using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SpikeWcf.WcfHelpers
{
    public class ExceptionErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            /*
             * See
             * http://www.zamd.net/2008/07/08/ErrorHandlingWithWebHttpBindingForAjaxJSON.aspx
             * http://decav.com/blogs/andre/archive/2007/11/03/wcf-throwing-exceptions-with-webhttpbinding.aspx
             * http://blog.wadolabs.com/2009/03/wcf-exception-handling-with-ierrorhandler/
             */
            fault = Message.CreateMessage(version, "", new ExceptionInfo(error), new DataContractJsonSerializer(typeof(ExceptionInfo)));
            var wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);
            var rmp = new HttpResponseMessageProperty{
                StatusCode = HttpStatusCode.InternalServerError,
                StatusDescription = error.Message,
            };
            rmp.Headers[HttpResponseHeader.ContentType] = "application/json";
            fault.Properties.Add(HttpResponseMessageProperty.Name, rmp);
        }
    }
}