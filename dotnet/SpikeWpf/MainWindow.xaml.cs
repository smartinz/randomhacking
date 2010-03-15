using GalaSoft.MvvmLight.Messaging;
using SpikeWpf.Messages;

namespace SpikeWpf
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			Messenger.Default.Register<ShowViewModel>(this, ShowViewModel);
			Messenger.Default.Register<ShowViewModelModal>(this, ShowViewModelModal);
		}

		private void ShowViewModel(ShowViewModel message)
		{
			var window = new ModalWindow{
				DataContext = message.ViewModel,
				Owner = this
			};
			window.Show();
		}

		private void ShowViewModelModal(ShowViewModelModal message)
		{
			var window = new ModalWindow{
				DataContext = message.ViewModel,
				Owner = this
			};
			var dialogResult = window.ShowDialog();
			message.CloseAction(dialogResult);
		}
	}
}