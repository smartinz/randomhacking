using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CustomerDemographicRepository
	{
		private readonly ISessionFactory _northwind;


		public CustomerDemographicRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(CustomerDemographic v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public CustomerDemographic Read(string customerTypeId)
		{
			return _northwind.GetCurrentSession().Load<CustomerDemographic>(customerTypeId);
		}

		public void Update(CustomerDemographic v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(CustomerDemographic v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<CustomerDemographic> Search(string customerTypeId, string customerDesc)
		{
			IQueryable<CustomerDemographic> queryable = _northwind.GetCurrentSession().Linq<CustomerDemographic>();
			if(customerTypeId != default(string))
			{
				queryable = queryable.Where(x => x.CustomerTypeId.StartsWith(customerTypeId));
			}
			if(customerDesc != default(string))
			{
				queryable = queryable.Where(x => x.CustomerDesc.StartsWith(customerDesc));
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<CustomerDemographic>(queryable);
		}
	}
}