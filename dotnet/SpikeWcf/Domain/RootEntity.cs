using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace SpikeWcf.Domain
{
	public class RootEntity
	{
		private ISet<DetailEntity> _detailEntities;

		public RootEntity()
		{
			ExternalEntities = new List<ExternalEntity>();
			_detailEntities = new HashedSet<DetailEntity>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<ExternalEntity> ExternalEntities { get; private set; }

		public ExternalEntity ExternalEntity { get; set; }

		public ISet<DetailEntity> DetailEntities
		{
			get { return _detailEntities; }
			set { _detailEntities = value;}
		}
	}
}