using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace SpikeWpf
{
	public class SearchCustomerViewModel : IWorkspace
	{
		public SearchCustomerViewModel()
		{
			CloseCommand = new RelayCommand(Close);
			DisplayName = "Search Customer";
		}

		public ICommand CloseCommand { get; private set; }

		public string DisplayName { get; private set; }
		public event EventHandler RequestClose = delegate { };

		public void Dispose() {}

		public void Close()
		{
			RequestClose(this, EventArgs.Empty);
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}