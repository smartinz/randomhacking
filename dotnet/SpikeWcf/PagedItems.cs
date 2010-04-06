using System.Runtime.Serialization;

namespace SpikeWcf
{
	[DataContract]
	public class PagedItems<T>
	{
		public PagedItems(T[] items, int count)
		{
			Items = items;
			Count = count;
		}

		[DataMember(Name = "items")]
		public T[] Items { get; set; }

		[DataMember(Name = "count")]
		public int Count { get; set; }
	}
}