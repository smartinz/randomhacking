using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AssemblaTimeTracker
{
	public class HttpXml
	{
		private const string ContentType = "application/xml";

		private readonly string _userName;
		private readonly string _password;

		public HttpXml(string userName, string password)
		{
			_userName = userName;
			_password = password;
		}

		public XDocument HttpGetXml(string url)
		{
			HttpWebRequest req = CreateRequest(url);
			return GetResponse(req);
		}

		private HttpWebRequest CreateRequest(string url)
		{
			var req = (HttpWebRequest)WebRequest.Create(url);
			req.Accept = ContentType;
			req.Credentials = new NetworkCredential(_userName, _password); //.GetCredential(new Uri(url), "Basic");
			req.PreAuthenticate = true;
			return req;
		}

		private XDocument GetResponse(HttpWebRequest req)
		{
			using(var resp = (HttpWebResponse)req.GetResponse())
			{
				if(resp.StatusCode != HttpStatusCode.OK)
				{
					throw new ApplicationException(string.Format("Response status was {0}", resp.StatusCode));
				}
				if(!resp.ContentType.Contains(ContentType))
				{
					throw new ApplicationException(string.Format("Expected response of type '{0}' but received response of type '{1}", ContentType, resp.ContentType));
				}

				string response = new StreamReader(resp.GetResponseStream()).ReadToEnd();
				File.WriteAllText(@"C:\Users\ggherardi\temp\out.xml", response);

				return XDocument.Load(XmlReader.Create(new StringReader(response)));
			}
		}

		public XDocument HttpPostXml(string url, string content)
		{
			HttpWebRequest req = CreateRequest(url);
			req.Method = "POST";
			req.ContentType = ContentType;

			byte[] bytes = Encoding.UTF8.GetBytes(content);
			req.ContentLength = bytes.Length;
			using (Stream post = req.GetRequestStream())
			{
				post.Write(bytes, 0, bytes.Length);
			}

			return GetResponse(req);
		}
	}
}