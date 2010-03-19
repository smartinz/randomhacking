using System;

namespace SpikeWpf.Conversation
{
	public interface IConversation : IDisposable
	{
		void Start();
		IDisposable Resume();
		void Pause();
		void End(bool commit);
	}
}