using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Config;
using NUnit.Framework;

namespace Conversation.Tests
{
	[SetUpFixture]
	public class SetUpFixture
	{
		static public MemoryAppender SqlOperationsAppender;

		[SetUp]
		public void SetUp()
		{
			XmlConfigurator.Configure(new FileInfo("log4net.cfg.xml"));
			SqlOperationsAppender = (MemoryAppender)LogManager.GetRepository().GetAppenders().Single(a => a.Name == "sql-operations");
		}
	}
}