using System.Windows;

namespace SpikeWpf
{
	public partial class ModalWindow
	{
		public ModalWindow()
		{
			InitializeComponent();
		}

		private void cancelButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}

		private void okButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}