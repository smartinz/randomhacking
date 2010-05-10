using System.Web;

namespace ExtMvc.Infrastructure
{
	public class Conversation : IConversation
	{
		public bool Accept
		{
			get
			{
				if(HttpContext.Current.Items[GetType().FullName] == null)
				{
					return false;
				}
				return (bool)HttpContext.Current.Items[GetType().FullName];
			}
			set { HttpContext.Current.Items[GetType().FullName] = true; }
		}
	}
}