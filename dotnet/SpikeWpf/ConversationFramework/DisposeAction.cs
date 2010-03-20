using System;

namespace SpikeWpf.ConversationFramework
{
	public class DisposeAction : IDisposable
	{
		private readonly Action _disposeAction;

		public DisposeAction(Action disposeAction)
		{
			_disposeAction = disposeAction;
		}

		public void Dispose()
		{
			_disposeAction();
		}
	}
}