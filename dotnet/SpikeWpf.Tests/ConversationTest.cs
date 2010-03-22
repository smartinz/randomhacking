using System;
using NHibernate;
using NUnit.Framework;
using SpikeWpf.Conversation;
using SpikeWpf.Tests.Domain;

namespace SpikeWpf.Tests
{
	[TestFixture]
	public class ConversationTest
	{
		[SetUp]
		public void SetUp()
		{
			_sessionFactory = TestDatabaseHelper.CreateTestDatabase();
			_conversationFactory = new ConversationFactory(new[]{ _sessionFactory });
			SetUpFixture.SqlOperationsAppender.Clear();
		}

		private ISessionFactory _sessionFactory;
		private ConversationFactory _conversationFactory;

		private Guid SaveTestEntities()
		{
			IConversation conversation = _conversationFactory.Open();
			MasterEntity newEntity;
			using (conversation.SetAsCurrent())
			{
				newEntity = new MasterEntity{ Name = "Entity1" };
				newEntity.AddDetail(new DetailEntity{ Name = "Detail1" });
				newEntity.AddDetail(new DetailEntity{ Name = "Detail2" });
				_sessionFactory.GetCurrentSession().SaveOrUpdate(newEntity);
			}
			conversation.Flush();
			conversation.Close();
			return newEntity.Id;
		}

		[Test]
		public void Current_session_should_be_available_with_an_active_conversation()
		{
			IConversation conversation = _conversationFactory.Open();
			using (conversation.SetAsCurrent())
			{
				Assert.That(_sessionFactory.GetCurrentSession(), Is.Not.Null);
			}
			conversation.Close();
		}

		[Test]
		public void Current_session_should_not_be_available_without_an_active_conversation()
		{
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			_conversationFactory.Open();
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(0));
		}

		[Test]
		public void Should_load_lazy_properties_when_out_of_context()
		{
			Guid newEntityId = SaveTestEntities();

			IConversation conversation = _conversationFactory.Open();
			MasterEntity entity;
			using (conversation.SetAsCurrent())
			{
				entity = _sessionFactory.GetCurrentSession().Get<MasterEntity>(newEntityId);
			}
			Assert.That(entity.Details.Count, Is.EqualTo(2));
			conversation.Close();
		}

		[Test]
		public void Should_not_touch_database_when_rollback_conversation()
		{
			IConversation conversation = _conversationFactory.Open();
			using (conversation.SetAsCurrent())
			{
				var newEntity = new MasterEntity{ Name = "Entity1" };
				_sessionFactory.GetCurrentSession().SaveOrUpdate(newEntity);
			}
			conversation.Close();
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(0));
		}

		[Test]
		public void Should_touch_database_when_committing_conversation()
		{
			SaveTestEntities();
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(3));
		}
	}
}