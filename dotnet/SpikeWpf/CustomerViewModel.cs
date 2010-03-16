using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Input;
using SpikeWpf.Domain;

namespace SpikeWpf
{
	public class CustomerViewModel : IViewModel, INotifyPropertyChanged, IDataErrorInfo
	{
		private readonly Customer _customer;

		public CustomerViewModel(Customer customer)
		{
			_customer = customer;
			Title = "Customer";
		}

		public string Name
		{
			get { return _customer.Name; }
			set
			{
				_customer.Name = value;
				OnPropertyChanged(() => Name);
			}
		}

		public string Address
		{
			get { return _customer.Address; }
			set
			{
				_customer.Address = value;
				OnPropertyChanged(() => Name);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
		public string Title { get; private set; }

		private void OnPropertyChanged(Expression<Func<object>> expression)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(Utils.Name.Of(expression)));
		}

		#region Implementation of IDataErrorInfo

		string IDataErrorInfo.this[string columnName]
		{
			get
			{
				if(columnName == "Name")
				{
					CommandManager.InvalidateRequerySuggested();
					return (Name ?? "").Length > 5 ? null : "AHH!";
				}
				return null;
			}
		}

		string IDataErrorInfo.Error
		{
			get { return ((IDataErrorInfo)this)["Name"]; }
		}

		#endregion
	}
}