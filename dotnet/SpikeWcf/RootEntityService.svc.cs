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
		public PagedItems<RootEntityDto> GetAll(RootEntityDto rootEntity)
		{
			RootEntity rootEntityDomain = Mapper.Map<RootEntityDto, RootEntity>(rootEntity);

			RootEntityDto[] ret = Mapper.Map<RootEntity[], RootEntityDto[]>(new[]{
				rootEntityDomain,
				new RootEntity{
					Id = 1,
					Name = "Uno",
					ExternalEntity = new ExternalEntity{
						Id = 3,
						Description = "external entity 3",
					},
				},
				new RootEntity{
					Id = 2,
					Name = "Due",
					ExternalEntity = new ExternalEntity{
						Id = 4,
						Description = "external entity 4"
					}
				},
			});
			return new PagedItems<RootEntityDto>(ret, ret.Length);
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

		[OperationContract]
		[WebInvoke(UriTemplate = "/ExceptionTest", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ExceptionTest()
		{
		    throw new ApplicationException("Exception message");
		}
	}
}