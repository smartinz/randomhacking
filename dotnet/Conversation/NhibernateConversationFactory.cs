using System.Collections.Generic;
using NHibernate;
using NHibernate.Engine;

namespace Conversation
{
	public class NhibernateConversationFactory : IConversationFactory
	{
		private readonly IEnumerable<ISessionFactory> _sessionFactories;

		public NhibernateConversationFactory(IEnumerable<ISessionFactory> sessionFactories)
		{
			_sessionFactories = sessionFactories;
		}

		public IConversation Open()
		{
			var map = new Dictionary<ISessionFactory, ISession>();
			foreach(ISessionFactoryImplementor sessionFactory in _sessionFactories)
			{
				ISession session = sessionFactory.OpenSession(null, false, false, sessionFactory.Settings.ConnectionReleaseMode);
				session.FlushMode = FlushMode.Never;
				map.Add(sessionFactory, session);
			}
			return new NhibernateConversation(map);
		}
	}
}