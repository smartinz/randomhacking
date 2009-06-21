		namespace NorthwindWeb.Data
		{
		public class ShipperRepository
		{
		private NorthwindWeb.Context _context;
		public ShipperRepository(NorthwindWeb.Context context)
		{
		_context = context;
		}
		
		public void Create(NorthwindWeb.Business.Shipper v)
		{
		var r = _context.NorthwindWebService.CreateShipper(v);
		
			v.ShipperID = r.ShipperID;
			v.CompanyName = r.CompanyName;
			v.Phone = r.Phone;
		}
	
		public NorthwindWeb.Business.Shipper Read(int ShipperID)
		{
		return _context.NorthwindWebService.ReadShipper(ShipperID);
		}
	
		public void Update(NorthwindWeb.Business.Shipper v)
		{
		var r = _context.NorthwindWebService.UpdateShipper(v);
		
			v.ShipperID = r.ShipperID;
			v.CompanyName = r.CompanyName;
			v.Phone = r.Phone;
		}
	
		public void Delete(NorthwindWeb.Business.Shipper v)
		{
		_context.NorthwindWebService.DeleteShipper(v);
		}
	
		public NorthwindWeb.Business.Shipper[] Search(string companyName, string phone)
		{
		return _context.NorthwindWebService.SearchShipper(companyName, phone);
		}
	
		}
		}
