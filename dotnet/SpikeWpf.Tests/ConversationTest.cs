using System.IO;
using NHibernate;
using NUnit.Framework;

namespace SpikeWpf.Tests
{
	[TestFixture]
	public class ConversationTest
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.cfg.xml"));
			_sessionFactory = TestDatabaseHelper.CreateTestDatabase(typeof(ConversationTest).Assembly);
		}

		#endregion

		private ISessionFactory _sessionFactory;

		[Test]
		public void tt()
		{
			var conversation = new Conversation.Conversation(new[]{_sessionFactory});
		}
	}
}