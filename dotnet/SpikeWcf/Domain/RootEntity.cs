using System.Collections.Generic;

namespace SpikeWcf.Domain
{
	public class RootEntity
	{
		private ICollection<DetailEntity> _detailEntities;
		private ICollection<ExternalEntity> _externalEntities;

		public RootEntity()
		{
			_externalEntities = new HashSet<ExternalEntity>();
			_detailEntities = new HashSet<DetailEntity>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<ExternalEntity> ExternalEntities
		{
			get { return _externalEntities; }
		}

		public ExternalEntity ExternalEntity { get; set; }

		public ICollection<DetailEntity> DetailEntities
		{
			get { return _detailEntities; }
		}
	}
}