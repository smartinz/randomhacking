using System;

namespace OptionParser
{
	public class Option
	{
		public string Prototype { get; set; }
		public string Description { get; set; }
		public Action<string> Action { get; set; }
	}
}