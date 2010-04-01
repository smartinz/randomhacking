using System.Collections.Generic;

namespace SpikeWcf.Domain
{
	public class RootEntity
	{
		public RootEntity()
		{
			ExternalEntities = new List<ExternalEntity>();
			DetailEntities = new List<DetailEntity>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<ExternalEntity> ExternalEntities { get; private set; }

		public ExternalEntity ExternalEntity { get; set; }

		public ICollection<DetailEntity> DetailEntities { get; private set; }
	}
}