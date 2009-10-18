using System.Collections;
using System.Linq;
using System.Text;

namespace UsingStatementOptimizer
{
	static public class TestUtils
	{
		static public string DumpToString(object o)
		{
			var sb = new StringBuilder();
			DumpToString(o, sb, 0);
			return sb.ToString();
		}

		static private void DumpToString(object o, StringBuilder sb, int indent)
		{
			if(o is IDictionary)
			{
				sb.AppendLine();
				var dictionary = (IDictionary)o;
				foreach(string key in dictionary.Keys.Cast<string>().OrderBy(s => s))
				{
					sb.Append(new string('\t', indent) + key + ": ");
					DumpToString(dictionary[key], sb, indent + 1);
				}
			}
			else if(o is IList)
			{
				sb.AppendLine();
				var list = (IList)o;
				for(int i = 0; i < list.Count; i++)
				{
					sb.Append(new string('\t', indent) + i + ": ");
					DumpToString(list[i], sb, indent + 1);
				}
			}
			else
			{
				sb.AppendLine((o ?? "NULL").ToString());
			}
		}
	}
}