		namespace NorthwindWeb.Data
		{
		[System.Web.Services.WebServiceBindingAttribute(Name = "NorthwindWebServiceSoap", Namespace = "http://www.northwind.com")]
		[System.ComponentModel.DesignerCategoryAttribute("code")]
		public class NorthwindWebService : System.Web.Services.Protocols.SoapHttpClientProtocol
		{
		public NorthwindWebService()
		{
		Url = "http://localhost:53172/NorthwindWebService.asmx";
		}
		
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateEmployee", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Employee CreateEmployee(NorthwindWeb.Business.Employee employee)
		{
		object[] results = this.Invoke("CreateEmployee", new object[] { employee });
			return ((NorthwindWeb.Business.Employee)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadEmployee", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Employee ReadEmployee(int employeeId)
		{
		object[] results = this.Invoke("ReadEmployee", new object[] { employeeId });
			return ((NorthwindWeb.Business.Employee)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateEmployee", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Employee UpdateEmployee(NorthwindWeb.Business.Employee employee)
		{
		object[] results = this.Invoke("UpdateEmployee", new object[] { employee });
			return ((NorthwindWeb.Business.Employee)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteEmployee", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteEmployee(NorthwindWeb.Business.Employee employee)
		{
		object[] results = this.Invoke("DeleteEmployee", new object[] { employee });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchEmployee", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Employee[] SearchEmployee(string lastName, string firstName, string title)
		{
		object[] results = this.Invoke("SearchEmployee", new object[] { lastName, firstName, title });
			return ((NorthwindWeb.Business.Employee[])(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateOrder", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Order CreateOrder(NorthwindWeb.Business.Order order)
		{
		object[] results = this.Invoke("CreateOrder", new object[] { order });
			return ((NorthwindWeb.Business.Order)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadOrder", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Order ReadOrder(int orderId)
		{
		object[] results = this.Invoke("ReadOrder", new object[] { orderId });
			return ((NorthwindWeb.Business.Order)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateOrder", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Order UpdateOrder(NorthwindWeb.Business.Order order)
		{
		object[] results = this.Invoke("UpdateOrder", new object[] { order });
			return ((NorthwindWeb.Business.Order)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteOrder", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteOrder(NorthwindWeb.Business.Order order)
		{
		object[] results = this.Invoke("DeleteOrder", new object[] { order });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchOrder", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Order[] SearchOrder(NorthwindWeb.Business.Employee employee, System.DateTime dateFrom, System.DateTime dateTo)
		{
		object[] results = this.Invoke("SearchOrder", new object[] { employee, dateFrom, dateTo });
			return ((NorthwindWeb.Business.Order[])(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateCustomer", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Customer CreateCustomer(NorthwindWeb.Business.Customer customer)
		{
		object[] results = this.Invoke("CreateCustomer", new object[] { customer });
			return ((NorthwindWeb.Business.Customer)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadCustomer", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Customer ReadCustomer(string customerId)
		{
		object[] results = this.Invoke("ReadCustomer", new object[] { customerId });
			return ((NorthwindWeb.Business.Customer)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateCustomer", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Customer UpdateCustomer(NorthwindWeb.Business.Customer customer)
		{
		object[] results = this.Invoke("UpdateCustomer", new object[] { customer });
			return ((NorthwindWeb.Business.Customer)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteCustomer", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteCustomer(NorthwindWeb.Business.Customer customer)
		{
		object[] results = this.Invoke("DeleteCustomer", new object[] { customer });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchCustomer", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Customer[] SearchCustomer(string companyName, string contactName, string contactTitle)
		{
		object[] results = this.Invoke("SearchCustomer", new object[] { companyName, contactName, contactTitle });
			return ((NorthwindWeb.Business.Customer[])(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateShipper", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Shipper CreateShipper(NorthwindWeb.Business.Shipper shipper)
		{
		object[] results = this.Invoke("CreateShipper", new object[] { shipper });
			return ((NorthwindWeb.Business.Shipper)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadShipper", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Shipper ReadShipper(int shipperId)
		{
		object[] results = this.Invoke("ReadShipper", new object[] { shipperId });
			return ((NorthwindWeb.Business.Shipper)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateShipper", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Shipper UpdateShipper(NorthwindWeb.Business.Shipper shipper)
		{
		object[] results = this.Invoke("UpdateShipper", new object[] { shipper });
			return ((NorthwindWeb.Business.Shipper)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteShipper", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteShipper(NorthwindWeb.Business.Shipper shipper)
		{
		object[] results = this.Invoke("DeleteShipper", new object[] { shipper });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchShipper", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Shipper[] SearchShipper(string companyName, string phone)
		{
		object[] results = this.Invoke("SearchShipper", new object[] { companyName, phone });
			return ((NorthwindWeb.Business.Shipper[])(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateProduct", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Product CreateProduct(NorthwindWeb.Business.Product product)
		{
		object[] results = this.Invoke("CreateProduct", new object[] { product });
			return ((NorthwindWeb.Business.Product)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadProduct", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Product ReadProduct(int productId)
		{
		object[] results = this.Invoke("ReadProduct", new object[] { productId });
			return ((NorthwindWeb.Business.Product)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateProduct", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Product UpdateProduct(NorthwindWeb.Business.Product product)
		{
		object[] results = this.Invoke("UpdateProduct", new object[] { product });
			return ((NorthwindWeb.Business.Product)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteProduct", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteProduct(NorthwindWeb.Business.Product product)
		{
		object[] results = this.Invoke("DeleteProduct", new object[] { product });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchProduct", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Product[] SearchProduct(NorthwindWeb.Business.Category category, NorthwindWeb.Business.Supplier supplier)
		{
		object[] results = this.Invoke("SearchProduct", new object[] { category, supplier });
			return ((NorthwindWeb.Business.Product[])(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateSupplier", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Supplier CreateSupplier(NorthwindWeb.Business.Supplier supplier)
		{
		object[] results = this.Invoke("CreateSupplier", new object[] { supplier });
			return ((NorthwindWeb.Business.Supplier)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadSupplier", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Supplier ReadSupplier(int supplierId)
		{
		object[] results = this.Invoke("ReadSupplier", new object[] { supplierId });
			return ((NorthwindWeb.Business.Supplier)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateSupplier", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Supplier UpdateSupplier(NorthwindWeb.Business.Supplier supplier)
		{
		object[] results = this.Invoke("UpdateSupplier", new object[] { supplier });
			return ((NorthwindWeb.Business.Supplier)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteSupplier", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteSupplier(NorthwindWeb.Business.Supplier supplier)
		{
		object[] results = this.Invoke("DeleteSupplier", new object[] { supplier });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchSupplier", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Supplier[] SearchSupplier(string companyName, string contactName, string counrty)
		{
		object[] results = this.Invoke("SearchSupplier", new object[] { companyName, contactName, counrty });
			return ((NorthwindWeb.Business.Supplier[])(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/CreateCategory", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Category CreateCategory(NorthwindWeb.Business.Category category)
		{
		object[] results = this.Invoke("CreateCategory", new object[] { category });
			return ((NorthwindWeb.Business.Category)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/ReadCategory", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Category ReadCategory(int categoryId)
		{
		object[] results = this.Invoke("ReadCategory", new object[] { categoryId });
			return ((NorthwindWeb.Business.Category)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/UpdateCategory", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Category UpdateCategory(NorthwindWeb.Business.Category category)
		{
		object[] results = this.Invoke("UpdateCategory", new object[] { category });
			return ((NorthwindWeb.Business.Category)(results[0]));
		
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/DeleteCategory", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void DeleteCategory(NorthwindWeb.Business.Category category)
		{
		object[] results = this.Invoke("DeleteCategory", new object[] { category });
		}
	
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.northwind.com/SearchCategory", RequestNamespace = "http://www.northwind.com", ResponseNamespace = "http://www.northwind.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public NorthwindWeb.Business.Category[] SearchCategory(string categoryName, string description)
		{
		object[] results = this.Invoke("SearchCategory", new object[] { categoryName, description });
			return ((NorthwindWeb.Business.Category[])(results[0]));
		
		}
	
		}
		}
