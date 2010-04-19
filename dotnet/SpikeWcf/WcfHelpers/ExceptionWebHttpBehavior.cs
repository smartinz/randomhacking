using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SpikeWcf.WcfHelpers
{
    public class ExceptionWebHttpBehavior : WebHttpBehavior
    {
        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Clear();
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new ExceptionErrorHandler());
        }
    }
}