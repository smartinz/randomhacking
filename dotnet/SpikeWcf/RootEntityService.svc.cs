using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using AutoMapper;
using SpikeWcf.Domain;
using SpikeWcf.Dtos;

namespace SpikeWcf
{
	[ServiceContract]
	public class RootEntityService
	{
		[OperationContract]
		[WebInvoke(UriTemplate = "/GetAll", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public RootEntityDto[] GetAll(RootEntityDto rootEntity)
		{
			var rootEntityDomain = Mapper.Map<RootEntityDto, RootEntity>(rootEntity);
			return Mapper.Map<RootEntity[], RootEntityDto[]>(new[]{
				rootEntityDomain, 
				new RootEntity{ Id = 1, Name = "Uno" }, 
				new RootEntity{ Id = 2, Name = "Due" },
			});
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