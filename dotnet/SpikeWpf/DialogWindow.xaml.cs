using System.ComponentModel;
using GalaSoft.MvvmLight.Command;

namespace SpikeWpf
{
	public partial class DialogWindow
	{
		public DialogWindow()
		{
			InitializeComponent();
			cancelButton.Command = new RelayCommand(Cancel);
			okButton.Command = new RelayCommand(Ok, CanOk);
		}

		private bool CanOk()
		{
			var dataErrorInfo = DataContext as IDataErrorInfo;
			return dataErrorInfo == null || string.IsNullOrEmpty(dataErrorInfo.Error);
		}

		private void Ok()
		{
			DialogResult = true;
		}

		private void Cancel()
		{
			DialogResult = false;
		}
	}
}