using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web.Services;
using System.Xml.Serialization;

namespace WebServiceMasterDetail
{
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class MasterService : WebService
	{
		private readonly string _dataFile;

		public MasterService()
		{
			_dataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
			_dataFile = Path.Combine(_dataFile, "Masters.xml");
		}

		[WebMethod]
		public Master Create(Master master)
		{
			List<Master> masters = Load();
			master.Id = masters.Count > 0 ? masters.Max(m => m.Id) + 1 : 1;
			masters.Add(master);
			Save(masters);
			return master;
		}

		[WebMethod]
		public Master Read(int id)
		{
			return Load().Single(m => m.Id == id);
		}

		[WebMethod]
		public Master Update(Master master)
		{
			List<Master> masters = Load();
			masters.RemoveAll(m => m.Id == master.Id);
			Save(masters);
			return Create(master);
		}

		[WebMethod]
		public void Delete(Master master)
		{
			List<Master> masters = Load();
			masters.RemoveAll(m => m.Id == master.Id);
			Save(masters);
		}

		[WebMethod]
		public Master[] Search(string field1, string field2)
		{
			IQueryable<Master> queryable = Load().AsQueryable();
			if(!string.IsNullOrEmpty(field1))
			{
				queryable.Where(m => m.Field1 == field1);
			}
			if(!string.IsNullOrEmpty(field2))
			{
				queryable.Where(m => m.Field1 == field2);
			}
			return queryable.ToArray();
		}

		private List<Master> Load()
		{
			var s = new XmlSerializer(typeof(List<Master>));
			List<Master> masters;
			using(var streamReader = new StreamReader(_dataFile))
			{
				masters = (List<Master>)s.Deserialize(streamReader);
			}
			return masters;
		}

		private void Save(List<Master> masters)
		{
			using(var streamWriter = new StreamWriter(_dataFile))
			{
				new XmlSerializer(typeof(List<Master>)).Serialize(streamWriter, masters);
			}
		}
	}
}