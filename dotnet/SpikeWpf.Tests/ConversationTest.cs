using System;
using NHibernate;
using NUnit.Framework;
using SpikeWpf.ConversationFramework;
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
			_conversation = new Conversation(new[]{ _sessionFactory });
			SetUpFixture.SqlOperationsAppender.Clear();
		}

		private ISessionFactory _sessionFactory;
		private Conversation _conversation;

		private Guid SaveTestEntities()
		{
			_conversation.Open();
			MasterEntity newEntity;
			using(_conversation.Context())
			{
				newEntity = new MasterEntity{ Name = "Entity1" };
				newEntity.AddDetail(new DetailEntity{ Name = "Detail1" });
				newEntity.AddDetail(new DetailEntity{ Name = "Detail2" });
				_sessionFactory.GetCurrentSession().SaveOrUpdate(newEntity);
			}
			_conversation.Flush();
			_conversation.Close();
			return newEntity.Id;
		}

		[Test]
		public void Current_session_should_be_available_with_an_active_conversation()
		{
			_conversation.Open();
			using(_conversation.Context())
			{
				Assert.That(_sessionFactory.GetCurrentSession(), Is.Not.Null);
			}
			_conversation.Close();
		}

		[Test]
		public void Current_session_should_not_be_available_without_an_active_conversation()
		{
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			_conversation.Open();
			Assert.Throws<ConversationException>(() => _sessionFactory.GetCurrentSession());
			Assert.That(SetUpFixture.SqlOperationsAppender.GetEvents().Length, Is.EqualTo(0));
		}

		[Test]
		public void Should_load_lazy_properties_when_out_of_context()
		{
			Guid newEntityId = SaveTestEntities();

			_conversation.Open();
			MasterEntity entity;
			using(_conversation.Context())
			{
				entity = _sessionFactory.GetCurrentSession().Get<MasterEntity>(newEntityId);
			}
			Assert.That(entity.Details.Count, Is.EqualTo(2));
			_conversation.Close();
		}

		[Test]
		public void Should_not_touch_database_when_rollback_conversation()
		{
			_conversation.Open();
			using(_conversation.Context())
			{
				var newEntity = new MasterEntity{ Name = "Entity1" };
				_sessionFactory.GetCurrentSession().SaveOrUpdate(newEntity);
			}
			_conversation.Close();
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