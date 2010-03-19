using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;

namespace SpikeWpf.Conversation
{
	public class ConversationSessionContext : ICurrentSessionContext
	{
		[ThreadStatic]
		static private IDictionary<ISessionFactory, ISession> _map;

		private readonly ISessionFactoryImplementor _factory;

		public ConversationSessionContext(ISessionFactoryImplementor factory)
		{
			_factory = factory;
		}

		public ISession CurrentSession()
		{
			ISession session;
			if(_map != null && _map.TryGetValue(_factory, out session) && session != null)
			{
				return session;
			}
			throw new ConversationException("No current conversation. Make sure the operation is executed with a Started and Resumed conversation for this thread");
		}

		public static void Bind(IDictionary<ISessionFactory, ISession> map)
		{
			if(map == null)
			{
				throw new ArgumentNullException("map");
			}
			if(_map != null)
			{
				throw new ConversationException("Another conversation is currently bound to the context");
			}
			_map = map;
		}

		public static void UnBind(IDictionary<ISessionFactory, ISession> map)
		{
			if(ReferenceEquals(map, _map))
			{
				throw new ConversationException("Trying to unbind a conversation that is not in context");
			}
			_map = null;
		}
	}
}