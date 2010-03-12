using System;
using System.Windows.Input;
using MvvmFoundation.Wpf;

namespace SpikeWpf
{
	public class SearchCustomerViewModel : ObservableObject, IWorkspace
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
	}
}