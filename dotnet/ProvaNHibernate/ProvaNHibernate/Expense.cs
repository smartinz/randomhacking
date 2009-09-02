using System;

namespace ProvaNHibernate
{
	public class Expense
	{
		private int _id;
		private string _description;
		
		public Expense()
		{
		}

		public virtual int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
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
