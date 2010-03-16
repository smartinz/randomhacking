using GalaSoft.MvvmLight.Messaging;
using SpikeWpf.Messages;

namespace SpikeWpf
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			Messenger.Default.Register<OpenDialogWindowMessage>(this, OpenDialogWindow);
		}

		private void OpenDialogWindow(OpenDialogWindowMessage message)
		{
			var window = new DialogWindow{
				DataContext = message.ViewModel,
				Owner = this
			};
			var dialogResult = window.ShowDialog();
			message.CloseAction(dialogResult);
		}
	}
}