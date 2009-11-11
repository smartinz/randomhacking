using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;

namespace JQueryWebServices
{
	[ScriptService]
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class ExampleService : WebService
	{
		[WebMethod]
		public object HelloWorld(string q)
		{
			return new[]{ 1, 2, 3, 4, 5 }.Select(number => new{ 
				id = number, 
				label = q + " - " + number.ToString(),
				result = q + " - " + number.ToString()
			});
		}
	}
}