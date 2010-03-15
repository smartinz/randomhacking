using GalaSoft.MvvmLight.Messaging;

namespace SpikeWpf.Messages
{
	public class ShowViewModel : MessageBase
	{
		public ShowViewModel(IViewModel viewModel)
		{
			ViewModel = viewModel;
		}

		public IViewModel ViewModel { get; private set; }
	}
}