using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SpikeWpf.Messages;

namespace SpikeWpf
{
	public class MainWindowViewModel
	{
		public MainWindowViewModel() : this(Messenger.Default) {}

		public MainWindowViewModel(Messenger messenger)
		{
			Workspaces = new ObservableCollection<IWorkspace>();
			Workspaces.CollectionChanged += Workspaces_CollectionChanged;
			SearchCustomerCommand = new RelayCommand(SearchCustomer);
			CreateCustomerCommand = new RelayCommand(() => messenger.Send(new OpenDialogWindowMessage(new SearchCustomerViewModel(), r => MessageBox.Show(r.ToString()))));
		}

		public ICommand SearchCustomerCommand { get; private set; }

		public ICommand CreateCustomerCommand { get; private set; }

		public ObservableCollection<IWorkspace> Workspaces { get; private set; }

		private void Workspaces_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			foreach(IWorkspace workspace in e.NewItems ?? new IWorkspace[0])
			{
				workspace.RequestClose += CloseWorkspace;
			}

			foreach(IWorkspace workspace in e.OldItems ?? new IWorkspace[0])
			{
				workspace.RequestClose -= CloseWorkspace;
			}
		}

		private void CloseWorkspace(object sender, EventArgs e)
		{
			var workspace = sender as IWorkspace;
			Workspaces.Remove(workspace);
			var disposable = sender as IDisposable;
			if(disposable != null)
			{
				disposable.Dispose();
			}
		}

		public void SearchCustomer()
		{
			var workspace = new SearchCustomerViewModel();
			AddWorkspace(workspace);
		}

		private void AddWorkspace(IWorkspace workspace)
		{
			Workspaces.Add(workspace);
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
			if(collectionView != null)
			{
				collectionView.MoveCurrentTo(workspace);
			}
		}
	}
}