using NHibernate;
using NHibernate.Cfg;

namespace SpikeNHibernateIoc
{
	internal class Usage
	{
		public void UsageExample()
		{
			Environment.BytecodeProvider = new CustomCreateInstanceByteCodeProvider{
				{ typeof(Category), () => new Category("ciao") }
			};

			ISessionFactory factory = new Configuration().Configure().BuildSessionFactory();
		}
	}
}