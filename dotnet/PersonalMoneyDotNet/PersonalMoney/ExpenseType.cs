using System;

namespace PersonalMoney
{
	public class ExpenseType
	{
		private int _id;
		private string _description;
		
		public ExpenseType()
		{
		}

		public virtual int Id
		{
			get
			{
				return _id;
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
	}
}
