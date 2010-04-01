using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SpikeWcf
{
	[ServiceContract]
	public class CustomerService
	{
		[OperationContract]
		[WebInvoke(UriTemplate = "/GetAll", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Customer[] GetAll(Customer customer)
		{
			return new[]{
				customer,
				new Customer{ Id = 1, Name = "Uno" },
				new Customer{ Id = 2, Name = "Due" },
			};
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "/JsonDataTypeTest", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public JsonDataTypeTestResponse JsonDataTypeTest(string stringPar, int intPar, bool boolPar, string[] arrayPar, DateTime datePar, double doublePar, decimal decimalPar, Guid guidPar)
		{
			return new JsonDataTypeTestResponse{
				StringPar = stringPar,
				IntPar = intPar,
				BoolPar = boolPar,
				ArrayPar = arrayPar,
				DatePar = datePar,
				DoublePar = doublePar,
				DecimalPar = decimalPar,
				GuidPar = guidPar,
			};
		}
	}
}