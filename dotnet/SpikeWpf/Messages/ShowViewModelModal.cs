﻿using System;
using GalaSoft.MvvmLight.Messaging;

namespace SpikeWpf.Messages
{
	public class ShowViewModelModal : MessageBase
	{
		public ShowViewModelModal(IViewModel viewModel, Action<bool?> closeAction)
		{
			ViewModel = viewModel;
			CloseAction = closeAction;
		}

		public IViewModel ViewModel { get; private set; }
		public Action<bool?> CloseAction { get; private set; }
	}
}