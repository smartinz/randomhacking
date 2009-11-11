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
			return new[]{ 1, 2, 3, 4, 5 }.Select(id => new{ id, description = q + " - " + id.ToString() });
		}
	}
}