using NHibernate;
using NUnit.Framework;
using SpikeWpf.Conversation;
using SpikeWpf.Tests.Domain;

namespace SpikeWpf.Tests
{
	[TestFixture]
	public class ConversationTest
	{
		private ISessionFactory _sessionFactory;
		private Conversation.Conversation _target;

		[SetUp]
		public void SetUp()
		{
			_sessionFactory = TestDatabaseHelper.CreateTestDatabase();
			_target = new Conversation.Conversation(new[]{ _sessionFactory });
			SetUpFixture.SqlOperationsAppender.Clear();
		}

		[Test]
		public void Current_session_should_be_available_with_an_active_conversation()
		{
			_target.Start();
			using(_target.Resume())
			{
				Assert.That(_sessionFactory.GetCurrentSession(), Is.Not.Null);
			}
			_target.End(false);
		}

		[Test]
		public void Should_not_touch_database_when_rollback_()
		{
			_target.Start();
			using(_target.Resume())
			{
				var newEntity = new MasterEntity{ Name = "Entity1" };
				_sessionFactory.GetCurrentSession().SaveOrUpdate(newEntity);
			}
			_target.End(false);
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(0));
		}

		[Test]
		public void Current_session_should_not_be_available_without_an_active_conversation()
		{
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			_target.Start();
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(0));
		}
	}
}