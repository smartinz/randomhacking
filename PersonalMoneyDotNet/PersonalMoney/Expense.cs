using System;

namespace PersonalMoney
{
	public class Expense
	{
		private int _id;
		private DateTime _date;
		private int _amount;
		private string _description;
		private ExpenseType _type;
		
		public Expense()
		{
		}

		public virtual ExpenseType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public virtual int Id
		{
			get
			{
				return _id;
			}
		}

		public virtual DateTime Date
		{
			get
			{
				return _date;
			}
			set
			{
				_date = value;
			}
		}

		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public virtual int Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				_amount = value;
			}
		}
		
	}
}
