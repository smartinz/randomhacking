using NHibernate;
using NUnit.Framework;
using SpikeWpf.Conversation;

namespace SpikeWpf.Tests
{
	[TestFixture]
	public class ConversationTest
	{
		private ISessionFactory _sessionFactory;
		Conversation.Conversation _target;

		[SetUp]
		public void SetUp()
		{
			_sessionFactory = TestDatabaseHelper.CreateTestDatabase();
			_target = new Conversation.Conversation(new[]{ _sessionFactory });
		}

		[Test]
		public void Getting_current_session_without_conversation()
		{
			SetUpFixture.SqlOperationsAppender.Clear();
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			_target.Start();
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(0));
		}
	}
}