using System;
using System.Collections.Generic;
using NHibernate;

namespace SpikeWpf.Conversation
{
	public class Conversation : IConversation
	{
		private readonly IDictionary<ISessionFactory, ISession> _map;
		private readonly ConversationStatus _status;

		public Conversation(IEnumerable<ISessionFactory> sessionFactories)
		{
			_status = ConversationStatus.Stopped;
			_map = new Dictionary<ISessionFactory, ISession>();
			foreach(ISessionFactory sessionFactory in sessionFactories)
			{
				_map.Add(sessionFactory, null);
			}
		}

		public void Start() {}

		public IDisposable Resume()
		{
			ConversationSessionContext.Bind(_map);
			return new DisposeAction(Pause);
		}

		public void Pause()
		{
			ConversationSessionContext.Bind(null);
			foreach(var map in _map) {}
		}

		public void End(bool commit)
		{
			if(commit)
			{
				// Commit
			}
			else
			{
				// Rollback
			}
		}
	}
}