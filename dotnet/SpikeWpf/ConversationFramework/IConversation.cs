using System;

namespace SpikeWpf.ConversationFramework
{
	public interface IConversation : IDisposable
	{
		void Open();

		IDisposable Context();
		void UnbindContext();

		void Flush();

		void Close();
	}
}