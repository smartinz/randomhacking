using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class OrderDetailRepository
	{
		private readonly ISession _Northwind;


		public OrderDetailRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(OrderDetail v)
		{
			_Northwind.Save(v);
		}

		public OrderDetail Read(int orderId, int productId)
		{
			var keyObject = new OrderDetail {OrderId = orderId, ProductId = productId};
			return _Northwind.Load<OrderDetail>(keyObject);
		}

		public void Update(OrderDetail v)
		{
			_Northwind.Update(v);
		}

		public void Delete(OrderDetail v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<OrderDetail> Search(int? orderId, int? productId, decimal? unitPrice, short? quantity, float? discount)
		{
			IQueryable<OrderDetail> queryable = _Northwind.Linq<OrderDetail>();
			if (orderId != default(int?))
			{
				queryable = queryable.Where(x => x.OrderId == orderId);
			}
			if (productId != default(int?))
			{
				queryable = queryable.Where(x => x.ProductId == productId);
			}
			if (unitPrice != default(decimal?))
			{
				queryable = queryable.Where(x => x.UnitPrice == unitPrice);
			}
			if (quantity != default(short?))
			{
				queryable = queryable.Where(x => x.Quantity == quantity);
			}
			if (discount != default(float?))
			{
				queryable = queryable.Where(x => x.Discount == discount);
			}

			return queryable;
		}
	}
}