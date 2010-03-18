using System;

namespace SpikeWpf.Conversation
{
	public class ConversationException : Exception
	{
		public ConversationException(string message) : base(message) {}
	}
}