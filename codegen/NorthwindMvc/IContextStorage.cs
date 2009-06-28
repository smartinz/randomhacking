using NorthwindWeb;

namespace NorthwindMvc
{
	public interface IContextStorage
	{
		Context Get();
	}
}