using System;

namespace SpikeWpf.ConversationFramework
{
	public class ConversationException : Exception
	{
		public ConversationException(string message) : base(message) {}
	}
}