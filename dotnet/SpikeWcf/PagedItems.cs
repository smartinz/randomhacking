using System;
using System.Runtime.Serialization;

namespace SpikeWcf
{
	[DataContract]
	public class PagedItems<T>
	{
		public PagedItems(T[] items)
		{
			Items = items;
		}

		[DataMember(Name = "items")]
		public T[] Items { get; set; }
	}
}