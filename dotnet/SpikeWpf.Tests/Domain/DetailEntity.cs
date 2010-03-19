using System;

namespace SpikeWpf.Tests.Domain
{
	public class DetailEntity
	{
		public DetailEntity()
		{
			Id = Guid.NewGuid();
		}
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Version { get; set; }
		public virtual MasterEntity MasterEntity{ get; set;}

	}
}