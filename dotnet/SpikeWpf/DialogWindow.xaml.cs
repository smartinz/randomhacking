using System;
using System.Windows;
using System.Windows.Input;

namespace SpikeWpf
{
	public partial class DialogWindow
	{
		static public ICommand CancelCommand = new RoutedCommand();
		static public ICommand OkCommand = new RoutedCommand();

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

		private void OkCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void OkCommand_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			DialogResult = true;
			e.Handled = true;
		}

		private void CancelCommand_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			DialogResult = false;
			e.Handled = true;
		}

		private void CancelCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}
	}
}