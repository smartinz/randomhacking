using System;

namespace SpikeWpf.ConversationFramework
{
	public interface IConversation : IDisposable
	{
		IDisposable Context();
		void UnbindContext();

		void Flush();

		void Close();
	}
}