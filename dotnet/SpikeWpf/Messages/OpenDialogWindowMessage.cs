using System;
using GalaSoft.MvvmLight.Messaging;

namespace SpikeWpf.Messages
{
	public class OpenDialogWindowMessage : MessageBase
	{
		public OpenDialogWindowMessage(IViewModel viewModel, Action<bool?> closeAction)
		{
			ViewModel = viewModel;
			CloseAction = closeAction;
		}

		public IViewModel ViewModel { get; private set; }
		public Action<bool?> CloseAction { get; private set; }
	}
}