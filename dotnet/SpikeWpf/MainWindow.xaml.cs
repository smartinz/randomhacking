using GalaSoft.MvvmLight.Messaging;

namespace SpikeWpf
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			Messenger.Default.Register<OpenWorkspaceModal>(this, OpenWorkspace);
		}

		private void OpenWorkspace(OpenWorkspaceModal message)
		{
			var window = new ModalWindow{
				DataContext = message.Workspace,
				Owner = this
			};
			window.ShowDialog();
			
		}
	}
}