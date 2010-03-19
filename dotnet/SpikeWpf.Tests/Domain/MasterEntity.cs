using System;

namespace SpikeWpf.Tests.Domain
{
	public class MasterEntity
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Version { get; set; }
	}
}