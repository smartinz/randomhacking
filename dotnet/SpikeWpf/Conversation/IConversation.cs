using System;

namespace SpikeWpf.Conversation
{
	public interface IConversation
	{
		void Start();
		IDisposable Resume();
		void Pause();
		void End(bool commit);
	}
}