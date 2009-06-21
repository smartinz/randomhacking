using System;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using NorthwindWeb.Business;

namespace NorthwindWeb.Data
{
    [WebServiceBinding(Name = "NorthwindWebServiceSoap", Namespace = "http://www.northwind.com")]
    [DesignerCategory("code")]
    public class NorthwindWebService : SoapHttpClientProtocol
    {
        public NorthwindWebService()
        {
            Url = "http://localhost:53172/NorthwindWebService.asmx";
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateEmployee", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Employee CreateEmployee(Employee employee)
        {
            object[] results = Invoke("CreateEmployee", new object[] {employee});
            return ((Employee) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadEmployee", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Employee ReadEmployee(int employeeId)
        {
            object[] results = Invoke("ReadEmployee", new object[] {employeeId});
            return ((Employee) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateEmployee", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Employee UpdateEmployee(Employee employee)
        {
            object[] results = Invoke("UpdateEmployee", new object[] {employee});
            return ((Employee) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteEmployee", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteEmployee(Employee employee)
        {
            object[] results = Invoke("DeleteEmployee", new object[] {employee});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchEmployee", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Employee[] SearchEmployee(string lastName, string firstName, string title)
        {
            object[] results = Invoke("SearchEmployee", new object[] {lastName, firstName, title});
            return ((Employee[]) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateOrder", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Order CreateOrder(Order order)
        {
            object[] results = Invoke("CreateOrder", new object[] {order});
            return ((Order) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadOrder", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Order ReadOrder(int orderId)
        {
            object[] results = Invoke("ReadOrder", new object[] {orderId});
            return ((Order) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateOrder", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Order UpdateOrder(Order order)
        {
            object[] results = Invoke("UpdateOrder", new object[] {order});
            return ((Order) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteOrder", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteOrder(Order order)
        {
            object[] results = Invoke("DeleteOrder", new object[] {order});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchOrder", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Order[] SearchOrder(Employee employee, DateTime dateFrom, DateTime dateTo)
        {
            object[] results = Invoke("SearchOrder", new object[] {employee, dateFrom, dateTo});
            return ((Order[]) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateCustomer", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Customer CreateCustomer(Customer customer)
        {
            object[] results = Invoke("CreateCustomer", new object[] {customer});
            return ((Customer) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadCustomer", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Customer ReadCustomer(string customerId)
        {
            object[] results = Invoke("ReadCustomer", new object[] {customerId});
            return ((Customer) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateCustomer", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Customer UpdateCustomer(Customer customer)
        {
            object[] results = Invoke("UpdateCustomer", new object[] {customer});
            return ((Customer) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteCustomer", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteCustomer(Customer customer)
        {
            object[] results = Invoke("DeleteCustomer", new object[] {customer});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchCustomer", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Customer[] SearchCustomer(string companyName, string contactName, string contactTitle)
        {
            object[] results = Invoke("SearchCustomer", new object[] {companyName, contactName, contactTitle});
            return ((Customer[]) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateShipper", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Shipper CreateShipper(Shipper shipper)
        {
            object[] results = Invoke("CreateShipper", new object[] {shipper});
            return ((Shipper) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadShipper", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Shipper ReadShipper(int shipperId)
        {
            object[] results = Invoke("ReadShipper", new object[] {shipperId});
            return ((Shipper) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateShipper", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Shipper UpdateShipper(Shipper shipper)
        {
            object[] results = Invoke("UpdateShipper", new object[] {shipper});
            return ((Shipper) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteShipper", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteShipper(Shipper shipper)
        {
            object[] results = Invoke("DeleteShipper", new object[] {shipper});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchShipper", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Shipper[] SearchShipper(string companyName, string phone)
        {
            object[] results = Invoke("SearchShipper", new object[] {companyName, phone});
            return ((Shipper[]) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateProduct", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Product CreateProduct(Product product)
        {
            object[] results = Invoke("CreateProduct", new object[] {product});
            return ((Product) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadProduct", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Product ReadProduct(int productId)
        {
            object[] results = Invoke("ReadProduct", new object[] {productId});
            return ((Product) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateProduct", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Product UpdateProduct(Product product)
        {
            object[] results = Invoke("UpdateProduct", new object[] {product});
            return ((Product) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteProduct", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteProduct(Product product)
        {
            object[] results = Invoke("DeleteProduct", new object[] {product});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchProduct", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Product[] SearchProduct(Category category, Supplier supplier)
        {
            object[] results = Invoke("SearchProduct", new object[] {category, supplier});
            return ((Product[]) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateSupplier", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Supplier CreateSupplier(Supplier supplier)
        {
            object[] results = Invoke("CreateSupplier", new object[] {supplier});
            return ((Supplier) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadSupplier", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Supplier ReadSupplier(int supplierId)
        {
            object[] results = Invoke("ReadSupplier", new object[] {supplierId});
            return ((Supplier) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateSupplier", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Supplier UpdateSupplier(Supplier supplier)
        {
            object[] results = Invoke("UpdateSupplier", new object[] {supplier});
            return ((Supplier) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteSupplier", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteSupplier(Supplier supplier)
        {
            object[] results = Invoke("DeleteSupplier", new object[] {supplier});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchSupplier", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Supplier[] SearchSupplier(string companyName, string contactName, string counrty)
        {
            object[] results = Invoke("SearchSupplier", new object[] {companyName, contactName, counrty});
            return ((Supplier[]) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/CreateCategory", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Category CreateCategory(Category category)
        {
            object[] results = Invoke("CreateCategory", new object[] {category});
            return ((Category) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/ReadCategory", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Category ReadCategory(int categoryId)
        {
            object[] results = Invoke("ReadCategory", new object[] {categoryId});
            return ((Category) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/UpdateCategory", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Category UpdateCategory(Category category)
        {
            object[] results = Invoke("UpdateCategory", new object[] {category});
            return ((Category) (results[0]));
        }

        [SoapDocumentMethod("http://www.northwind.com/DeleteCategory", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void DeleteCategory(Category category)
        {
            object[] results = Invoke("DeleteCategory", new object[] {category});
        }

        [SoapDocumentMethod("http://www.northwind.com/SearchCategory", RequestNamespace = "http://www.northwind.com",
            ResponseNamespace = "http://www.northwind.com", Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public Category[] SearchCategory(string categoryName, string description)
        {
            object[] results = Invoke("SearchCategory", new object[] {categoryName, description});
            return ((Category[]) (results[0]));
        }
    }
}