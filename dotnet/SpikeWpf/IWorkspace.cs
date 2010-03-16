using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SpikeWpf
{
	public interface IWorkspace : INotifyPropertyChanged, IDisposable, IViewModel
	{
		ICommand CloseCommand { get; }
		event EventHandler RequestClose;
	}
}