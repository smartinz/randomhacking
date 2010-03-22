using System;
using Iesi.Collections.Generic;

namespace Conversation.Tests.Domain
{
	public class MasterEntity
	{
		public MasterEntity()
		{
			Id = Guid.NewGuid();
			Details = new HashedSet<DetailEntity>();
		}

		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Version { get; set; }
		public virtual ISet<DetailEntity> Details { get; set; }
		public virtual void AddDetail(DetailEntity detailEntity)
		{
			detailEntity.MasterEntity = this;
			Details.Add(detailEntity);
		}
	}
}