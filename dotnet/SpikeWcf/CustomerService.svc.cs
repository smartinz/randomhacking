using System.ServiceModel;
using System.ServiceModel.Web;

namespace SpikeWcf
{
	[ServiceContract]
	public class CustomerService
	{
		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAll")]
		public Customer[] GetAll()
		{
			return new[]{
				new Customer{ Id = 1, Name = "Uno" },
				new Customer{ Id = 2, Name = "Due" },
			};
		}
	}
}