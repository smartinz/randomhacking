using Iesi.Collections.Generic;

namespace SpikeNHibernateBurrow
{
	public class Entity
	{
		public Entity()
		{
			Childrens = new HashedSet<ChildEntity>();
		}

		public virtual int Id { get; set; }
		public virtual string Value1 { get; set; }
		public virtual string Value2 { get; set; }
		public virtual string Value3 { get; set; }
		public virtual ISet<ChildEntity> Childrens { get; set; }

		public virtual void AddChildren(ChildEntity childEntity)
		{
			Childrens.Add(childEntity);
			childEntity.Entity = this;
		}
	}
}