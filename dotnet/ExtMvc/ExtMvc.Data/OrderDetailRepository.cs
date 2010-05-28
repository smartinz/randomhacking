using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class OrderDetailRepository : IRepository
	{
		private readonly ISessionFactory _northwind;


		public OrderDetailRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(OrderDetail v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public OrderDetail Read(int orderId, int productId)
		{
			var keyObject = new OrderDetail{ OrderId = orderId, ProductId = productId };
			return _northwind.GetCurrentSession().Load<OrderDetail>(keyObject);
		}

		public void Update(OrderDetail v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(OrderDetail v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<OrderDetail> Search(int? orderId, int? productId, decimal? unitPrice, short? quantity, float? discount)
		{
			IQueryable<OrderDetail> queryable = _northwind.GetCurrentSession().Linq<OrderDetail>();
			if(orderId != default(int?))
			{
				queryable = queryable.Where(x => x.OrderId == orderId);
			}
			if(productId != default(int?))
			{
				queryable = queryable.Where(x => x.ProductId == productId);
			}
			if(unitPrice != default(decimal?))
			{
				queryable = queryable.Where(x => x.UnitPrice == unitPrice);
			}
			if(quantity != default(short?))
			{
				queryable = queryable.Where(x => x.Quantity == quantity);
			}
			if(discount != default(float?))
			{
				queryable = queryable.Where(x => x.Discount == discount);
			}

			return new QueryablePresentableSet<OrderDetail>(queryable);
		}
	}
}