using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace SpikeWpf
{
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var viewModel = new MainWindowViewModel(Messenger.Default);
			var window = new MainWindow{ DataContext = viewModel };
			window.Show();
		}
	}
}