using System.Windows;

namespace SpikeWpf
{
	public partial class DialogWindow
	{
		public DialogWindow()
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