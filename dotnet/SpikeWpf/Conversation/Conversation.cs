using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Engine;
using System.Linq;

namespace SpikeWpf.Conversation
{
	/// <summary>
	/// This is an implementation of Conversation per Business Transaction pattern.
	/// Doesn't work with tables with "assigned" generator class (like tables with IDENTITY column in SQL Server)
	/// See http://fabiomaulo.blogspot.com/2008/12/identity-never-ending-story.html
	/// </summary>
	public class Conversation : IConversation
	{
		private readonly IDictionary<ISessionFactory, ISession> _map;
		private ConversationState _state;

		public Conversation(IEnumerable<ISessionFactory> sessionFactories)
		{
			_state = ConversationState.Stopped;
			_map = new Dictionary<ISessionFactory, ISession>();
			foreach(ISessionFactory sessionFactory in sessionFactories)
			{
				_map.Add(sessionFactory, null);
			}
		}

		public void Start()
		{
			CheckState(ConversationState.Stopped);
			foreach(ISessionFactoryImplementor sessionFactory in _map.Keys.ToArray())
			{
				ISession session = sessionFactory.OpenSession(null, false, false, sessionFactory.Settings.ConnectionReleaseMode);
				session.FlushMode = FlushMode.Never;
				_map[sessionFactory] = session;
			}
			_state = ConversationState.Started;
		}

		public IDisposable Resume()
		{
			CheckState(ConversationState.Started);
			foreach(ISession session in _map.Values)
			{
				session.BeginTransaction();
			}
			ConversationSessionContext.Bind(_map);
			_state = ConversationState.InContext;
			return new DisposeAction(Pause);
		}

		public void Pause()
		{
			CheckState(ConversationState.InContext);
			ConversationSessionContext.UnBind(_map);
			foreach(ISession session in _map.Values)
			{
				session.Transaction.Commit();
			}
			_state = ConversationState.Started;
		}

		public void End(bool commit)
		{
			CheckState(ConversationState.Started);
			if(commit)
			{
				foreach(ISession session in _map.Values)
				{
					using(ITransaction tx = session.BeginTransaction())
					{
						session.Flush();
						tx.Commit();
					}
				}
			}
			foreach (ISessionFactory sessionFactory in _map.Keys.ToArray())
			{
				_map[sessionFactory].Close();
				_map[sessionFactory].Dispose();
				_map[sessionFactory] = null;
			}
			_state = ConversationState.Stopped;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void CheckState(params ConversationState[] validStates)
		{
			foreach(ConversationState validState in validStates)
			{
				if(_state == validState)
				{
					return;
				}
			}
			throw new ConversationException(string.Concat("Operation not allowed in ", _state, " state"));
		}

		protected void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(_state == ConversationState.InContext)
				{
					Pause();
				}
				if(_state == ConversationState.Started)
				{
					End(false);
				}
			}
		}

		~Conversation()
		{
			Dispose(false);
		}
	}
}