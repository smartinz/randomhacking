using System.ServiceModel;
using System.ServiceModel.Web;

namespace SpikeWcf
{
	[ServiceContract]
	public class CustomerService
	{
		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAll")]
		public Customer[] GetAll(Customer customer)
		{
			return new[]{
				customer,
				new Customer{ Id = 1, Name = "Uno" },
				new Customer{ Id = 2, Name = "Due" },
			};
		}

		//[OperationContract]
		//[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAll")]
		//public object JsonDataTypeTest(string stringPar, int intPar, bool boolPar, string[] arrayPar)
		//{
		//    return new{
		//        stringPar,
		//        intPar,
		//        boolPar,
		//        arrayPar,
		//    };
		//}
	}
}