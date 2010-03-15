using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SpikeWpf
{
	public interface IWorkspace : INotifyPropertyChanged, IDisposable, IViewModel
	{
		ICommand CloseCommand { get; }
		string DisplayName { get; }
		event EventHandler RequestClose;
	}
}