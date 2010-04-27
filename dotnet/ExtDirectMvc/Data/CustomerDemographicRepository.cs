using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CustomerDemographicRepository
	{
		private readonly ISession _Northwind;


		public CustomerDemographicRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(CustomerDemographic v)
		{
			_Northwind.Save(v);
		}

		public CustomerDemographic Read(string customerTypeId)
		{
			return _Northwind.Load<CustomerDemographic>(customerTypeId);
		}

		public void Update(CustomerDemographic v)
		{
			_Northwind.Update(v);
		}

		public void Delete(CustomerDemographic v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<CustomerDemographic> SearchNormal(string customerTypeId, string customerDesc)
		{
			IQueryable<CustomerDemographic> queryable = _Northwind.Linq<CustomerDemographic>();
			if (customerTypeId != default(string))
			{
				queryable = queryable.Where(x => x.CustomerTypeId == customerTypeId);
			}
			if (customerDesc != default(string))
			{
				queryable = queryable.Where(x => x.CustomerDesc == customerDesc);
			}

			return queryable;
		}
	}
}