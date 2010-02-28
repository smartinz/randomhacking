using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SpikeJson
{
	[TestFixture]
	public class JsonTest
	{
		[Test]
		public void Test()
		{
			var customers = new Dictionary<int, Customer>{
				{1, new Customer{Id = 1, Name = "Cust 1"}},
				{2, new Customer{Id = 2, Name = "Cust 2"}},
				{3, new Customer{Id = 3, Name = "Cust 3"}},
			};
			var items = new Dictionary<int, Item>{
				{1, new Item{Id = 1, Description = "Computer"}},
				{2, new Item{Id = 2, Description = "Smartphone"}}
			};
			var db = new Db(new Dictionary<Type, object>{
				{typeof (Customer), customers},
				{typeof (Item), items},
			});
			var invoice = new Invoice{
				Id = 1,
				Date = DateTime.Now,
				Description = "Shopping",
				Customer = db.Get<Customer>(1),
				Customers = new List<Customer>{
					db.Get<Customer>(2),
					db.Get<Customer>(3),
				},
				Items = new List<InvoiceItem>{
					new InvoiceItem{
						Id = 1,
						Quantity = 1,
						Price = 1000,
						Item = db.Get<Item>(1)
					},
					new InvoiceItem{
						Id = 2,
						Quantity = 1,
						Price = 500,
						Item = db.Get<Item>(2)
					},
				}
			};
			CustomerReferenceJsonConverter.Db = ItemReferenceJsonConverter.Db = db;
			string json = JsonConvert.SerializeObject(invoice, Formatting.Indented);
			var deserializedInvoice = JsonConvert.DeserializeObject<Invoice>(json);
		}
	}

	public class Db
	{
		private readonly IDictionary<Type, object> _dictionary;

		public Db(IDictionary<Type, object> dictionary)
		{
			_dictionary = dictionary;
		}

		public object Get(Type type, int id)
		{
			if (type == typeof(Customer))
			{
				return Get<Customer>(id);
			}
			if (type == typeof(Item))
			{
				return Get<Item>(id);
			}
			throw new Exception();
		}

		public T Get<T>(int id)
		{
			return ((IDictionary<int, T>) _dictionary[typeof (T)])[id];
		}

		public int GetId(object value)
		{
			if (value.GetType() == typeof(Customer))
			{
				return ((Customer) value).Id;
			}
			if (value.GetType() == typeof(Item))
			{
				return ((Item) value).Id;
			}
			throw new Exception();
		}
	}

	public class Invoice
	{
		[JsonConverter(typeof(CustomerReferenceJsonConverter))]
		public Customer Customer;

		[JsonConverter(typeof(CustomerReferenceJsonConverter))]
		public IList<Customer> Customers = new List<Customer>();

		public DateTime Date;
		public string Description;
		public int Id;
		public List<InvoiceItem> Items;
	}

	public class Customer
	{
		public int Id;
		public string Name;
	}

	public class InvoiceItem
	{
		public int Id;
		[JsonConverter(typeof(ItemReferenceJsonConverter))]
		public Item Item;
		public int Price;
		public int Quantity;
	}

	public class Item
	{
		public string Description;
		public int Id;
	}
}