using System.Windows;

namespace SpikeWpf
{
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var viewModel = new MainWindowViewModel();
			var window = new MainWindow{ DataContext = viewModel };
			window.Show();
		}
	}
}