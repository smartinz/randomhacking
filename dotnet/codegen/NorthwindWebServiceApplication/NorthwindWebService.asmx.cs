using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web.Services;

namespace NorthwindWebServiceApplication
{
	[WebService(Namespace = "http://www.northwind.com")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class NorthwindWebService : WebService
	{
		private readonly string _connectionString = ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ConnectionString;

		[WebMethod]
		public Employee CreateEmployee(Employee employee)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Employees.InsertOnSubmit(employee);
			dc.SubmitChanges();
			return employee;
		}

		[WebMethod]
		public Employee ReadEmployee(int employeeId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Employee> s = from e in dc.Employees
			                         where e.EmployeeID == employeeId
			                         select e;
			return s.First();
		}

		[WebMethod]
		public Employee UpdateEmployee(Employee employee)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Employees.Attach(employee, ReadEmployee(employee.EmployeeID));
			dc.SubmitChanges();
			return employee;
		}

		[WebMethod]
		public void DeleteEmployee(Employee employee)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Employee> s = from e in dc.Employees
			                         where e.EmployeeID == employee.EmployeeID
			                         select e;
			dc.Employees.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Employee[] SearchEmployee(string lastName, string firstName, string title)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Employee> s = from e in dc.Employees
			                         where (string.IsNullOrEmpty(lastName) || e.LastName == lastName)
			                               && (string.IsNullOrEmpty(firstName) || e.FirstName == firstName)
			                               && (string.IsNullOrEmpty(title) || e.Title == title)
			                         select e;
			return s.ToArray();
		}

		[WebMethod]
		public Order CreateOrder(Order order)
		{
			var dc = new DataClassesDataContext(_connectionString);
			if (order.Shipper != null)
			{
				dc.Shippers.Attach(order.Shipper, false);
			}
			if (order.Customer != null)
			{
				dc.Customers.Attach(order.Customer, false);
			}
			if (order.Employee != null)
			{
				dc.Employees.Attach(order.Employee, false);
			}
			dc.Orders.InsertOnSubmit(order);
			dc.SubmitChanges();
			return order;
		}

		[WebMethod]
		public Order ReadOrder(int orderId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Order> s = from e in dc.Orders
			                      where e.OrderID == orderId
			                      select e;
			return s.First();
		}

		[WebMethod]
		public Order UpdateOrder(Order order)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Orders.Attach(order, ReadOrder(order.OrderID));
			dc.SubmitChanges();
			return order;
		}

		[WebMethod]
		public void DeleteOrder(Order order)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Order> s = from e in dc.Orders
			                      where e.OrderID == order.OrderID
			                      select e;
			dc.Orders.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Order[] SearchOrder(Employee employee, DateTime dateFrom, DateTime dateTo)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Order> s = from e in dc.Orders
			                      where (dateFrom == default(DateTime) || e.ShippedDate >= dateFrom)
			                            && (dateTo == default(DateTime) || e.ShippedDate < dateTo)
			                            && (employee == null || e.Employee == employee)
			                      select e;
			return s.ToArray();
		}

		[WebMethod]
		public Customer CreateCustomer(Customer customer)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Customers.InsertOnSubmit(customer);
			dc.SubmitChanges();
			return customer;
		}

		[WebMethod]
		public Customer ReadCustomer(string customerId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Customer> s = from e in dc.Customers
			                         where e.CustomerID == customerId
			                         select e;
			return s.First();
		}

		[WebMethod]
		public Customer UpdateCustomer(Customer customer)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Customers.Attach(customer, ReadCustomer(customer.CustomerID));
			dc.SubmitChanges();
			return customer;
		}

		[WebMethod]
		public void DeleteCustomer(Customer customer)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Customer> s = from e in dc.Customers
			                         where e.CustomerID == customer.CustomerID
			                         select e;
			dc.Customers.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Customer[] SearchCustomer(string companyName, string contactName, string contactTitle)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Customer> s = from e in dc.Customers
			                         where (string.IsNullOrEmpty(companyName) || e.CompanyName == companyName)
			                               && (string.IsNullOrEmpty(contactTitle) || e.ContactTitle == contactTitle)
			                               && (string.IsNullOrEmpty(contactName) || e.ContactName == contactName)
			                         select e;
			return s.ToArray();
		}

		[WebMethod]
		public Shipper CreateShipper(Shipper shipper)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Shippers.InsertOnSubmit(shipper);
			dc.SubmitChanges();
			return shipper;
		}

		[WebMethod]
		public Shipper ReadShipper(int shipperId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Shipper> s = from e in dc.Shippers
			                        where e.ShipperID == shipperId
			                        select e;
			return s.First();
		}

		[WebMethod]
		public Shipper UpdateShipper(Shipper shipper)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Shippers.Attach(shipper, ReadShipper(shipper.ShipperID));
			dc.SubmitChanges();
			return shipper;
		}

		[WebMethod]
		public void DeleteShipper(Shipper shipper)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Shipper> s = from e in dc.Shippers
			                        where e.ShipperID == shipper.ShipperID
			                        select e;
			dc.Shippers.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Shipper[] SearchShipper(string companyName, string phone)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Shipper> s = from e in dc.Shippers
			                        where (string.IsNullOrEmpty(companyName) || e.CompanyName == companyName)
			                              && (string.IsNullOrEmpty(phone) || e.Phone == phone)
			                        select e;
			return s.ToArray();
		}

		[WebMethod]
		public Product CreateProduct(Product product)
		{
			var dc = new DataClassesDataContext(_connectionString);
			if (product.Category != null)
			{
				dc.Categories.Attach(product.Category, false);
			}
			if (product.Supplier != null)
			{
				dc.Suppliers.Attach(product.Supplier, false);
			}
			dc.Products.InsertOnSubmit(product);
			dc.SubmitChanges();
			return product;
		}

		[WebMethod]
		public Product ReadProduct(int productId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Product> s = from e in dc.Products
			                        where e.ProductID == productId
			                        select e;
			return s.First();
		}

		[WebMethod]
		public Product UpdateProduct(Product product)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Products.Attach(product, ReadProduct(product.ProductID));
			dc.SubmitChanges();
			return product;
		}

		[WebMethod]
		public void DeleteProduct(Product product)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Product> s = from e in dc.Products
			                        where e.ProductID == product.ProductID
			                        select e;
			dc.Products.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Product[] SearchProduct(Category category, Supplier supplier)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Product> s = from e in dc.Products
			                        select e;
			IEnumerable<Product> ss = from e in s.ToList()
			                          where (category == null || e.Category.CategoryID == category.CategoryID)
			                                && (supplier == null || e.SupplierID == supplier.SupplierID)
			                          select e;

			try
			{
				return ss.ToArray();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
			return new Product[0];
		}

		[WebMethod]
		public Supplier CreateSupplier(Supplier supplier)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Suppliers.InsertOnSubmit(supplier);
			dc.SubmitChanges();
			return supplier;
		}

		[WebMethod]
		public Supplier ReadSupplier(int supplierId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Supplier> s = from e in dc.Suppliers
			                         where e.SupplierID == supplierId
			                         select e;
			return s.First();
		}

		[WebMethod]
		public Supplier UpdateSupplier(Supplier supplier)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Suppliers.Attach(supplier, ReadSupplier(supplier.SupplierID));
			dc.SubmitChanges();
			return supplier;
		}

		[WebMethod]
		public void DeleteSupplier(Supplier supplier)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Supplier> s = from e in dc.Suppliers
			                         where e.SupplierID == supplier.SupplierID
			                         select e;
			dc.Suppliers.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Supplier[] SearchSupplier(string companyName, string contactName, string counrty)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Supplier> s = from e in dc.Suppliers
			                         where (string.IsNullOrEmpty(companyName) || e.CompanyName == companyName)
			                               && (string.IsNullOrEmpty(contactName) || e.ContactName == contactName)
			                               && (string.IsNullOrEmpty(counrty) || e.Country == counrty)
			                         select e;
			return s.ToArray();
		}

		[WebMethod]
		public Category CreateCategory(Category category)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Categories.InsertOnSubmit(category);
			dc.SubmitChanges();
			return category;
		}

		[WebMethod]
		public Category ReadCategory(int categoryId)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Category> s = from e in dc.Categories
			                         where e.CategoryID == categoryId
			                         select e;
			return s.First();
		}

		[WebMethod]
		public Category UpdateCategory(Category category)
		{
			var dc = new DataClassesDataContext(_connectionString);
			dc.Categories.Attach(category, ReadCategory(category.CategoryID));
			dc.SubmitChanges();
			return category;
		}

		[WebMethod]
		public void DeleteCategory(Category category)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Category> s = from e in dc.Categories
			                         where e.CategoryID == category.CategoryID
			                         select e;
			dc.Categories.DeleteOnSubmit(s.First());
			dc.SubmitChanges();
		}

		[WebMethod]
		public Category[] SearchCategory(string categoryName, string description)
		{
			var dc = new DataClassesDataContext(_connectionString);
			IQueryable<Category> s = from e in dc.Categories
			                         where (string.IsNullOrEmpty(categoryName) || e.CategoryName == categoryName)
			                               && (string.IsNullOrEmpty(description) || e.Description == description)
			                         select e;
			return s.ToArray();
		}
	}
}