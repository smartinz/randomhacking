namespace NorthwindWebNHibernate.Business
{
	public class EmployeeTerritories
	{

		public int EmployeeID { get; set; }

		public string TerritoryID { get; set; }

		public override string ToString()
		{
			return string.Format("EmployeeTerritories.EmployeeID={0}", this.EmployeeID);
		}
	}
}
