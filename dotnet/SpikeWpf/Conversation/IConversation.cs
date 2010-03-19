using System;

namespace SpikeWpf.Conversation
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