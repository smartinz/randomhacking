using System;

namespace SpikeWpf.ConversationFramework
{
	public interface IConversation : IDisposable
	{
		IDisposable SetAsCurrent();
		void ResetCurrent();

		void Flush();

		void Close();
	}
}