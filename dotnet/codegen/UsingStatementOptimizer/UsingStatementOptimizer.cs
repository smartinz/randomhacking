using System.Collections.Generic;
using System.Linq;

namespace UsingStatementOptimizer
{
	public class UsingStatementOptimizer
	{
		private readonly Dictionary<string, string[]> _names = new Dictionary<string, string[]>();

		public IList<string> GetViewData()
		{
			return _names.Select(n => n.Value[0]).Distinct().ToList();
		}

		public string ShortenName(string fullName)
		{
			if(!_names.ContainsKey(fullName))
			{
				string[] fullNameSplitted = fullName.Split('.');
				for(int startIndex = fullNameSplitted.Length - 1, count = 1; startIndex > 0; startIndex--, count++)
				{
					string name = string.Join(".", fullNameSplitted, startIndex, count);
					if(!_names.Select(ns => ns.Value[1]).Contains(name))
					{
						_names.Add(fullName, new[]{ string.Join(".", fullNameSplitted, 0, startIndex), name });
						break;
					}
				}
			}
			return _names[fullName][1];
		}
	}
}