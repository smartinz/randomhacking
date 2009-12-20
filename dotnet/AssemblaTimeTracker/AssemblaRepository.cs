using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace AssemblaTimeTracker
{
	public class AssemblaRepository
	{
		private readonly HttpXml _httpXml;

		public AssemblaRepository(HttpXml httpXml)
		{
			_httpXml = httpXml;
		}

		public IDictionary<string, string> GetSpaces()
		{
			XDocument doc = _httpXml.HttpGetXml(@"http://www.assembla.com/spaces/my_spaces");
			var ret = new Dictionary<string, string>();
			foreach(XElement space in doc.Element("spaces").Elements("space"))
			{
				ret.Add(space.Element("id").Value, space.Element("name").Value);
			}
			return ret;
		}

		public IDictionary<string, string> GetActiveTickets(string spaceId)
		{
			string url = string.Format(@"http://www.assembla.com/spaces/{0}/tickets/report/9.xml", spaceId); // http://www.assembla.com/spaces/{0}/tickets?tickets_report_id=9
			XDocument doc = _httpXml.HttpGetXml(url);
			var ret = new Dictionary<string, string>();
			foreach(XElement space in doc.Element("tickets").Elements("ticket"))
			{
				ret.Add(space.Element("number").Value, space.Element("summary").Value);
			}
			return ret;
		}

		public XDocument AddTimeToTicket(string spaceId, string ticketNumber, double hours, string description, DateTime beginAt, DateTime endAt)
		{
			string content = @"
<task>
	<space-id>{0}</space-id>
	<ticket-number type='integer'>{1}</ticket-number>
	<hours type='float'>{2}</hours>
	<description>{3}</description>
	<begin-at type='datetime'>{4}</begin-at>
	<end-at type='datetime'>{5}</end-at>
</task>
";
			content = string.Format(content,
			                        spaceId,
			                        ticketNumber,
			                        hours.ToString("0.0", CultureInfo.InvariantCulture),
			                        description,
			                        beginAt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssK", CultureInfo.InvariantCulture),
			                        endAt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssK", CultureInfo.InvariantCulture));

			return _httpXml.HttpPostXml(@"http://www.assembla.com/user/time_entries/", content);
		}
	}
}