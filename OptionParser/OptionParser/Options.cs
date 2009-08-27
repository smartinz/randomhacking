using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OptionParser
{
	public class Options : List<Option> // Dictionary<string, Action<string>>
	{
		public Action<string> MalformedArgumentAction { get; set; }

		public Options Add(string prototype, string description, Action<string> action)
		{
			Add(new Option{ Prototype = prototype, Description = description, Action = action });
			return this;
		}

		public IDictionary<string, string> Parse(IEnumerable<string> args)
		{
			var ret = new Dictionary<string, string>();
			foreach(string arg in args)
			{
				Match match = Regex.Match(arg, @"^(?<flag>--|-|/)(?<name>[^:=]+)(?<sep>[:=])(?<value>.*)$");
				if(!match.Success)
				{
					if(MalformedArgumentAction != null)
					{
						MalformedArgumentAction.Invoke(arg);
					}
					continue;
				}
				string name = match.Groups["name"].Value;
				string value = match.Groups["value"].Value;
				bool actionFound = false;
				foreach(Option action in this)
				{
					Match actionMatch = Regex.Match(arg, action.Prototype);
					if(actionMatch.Success)
					{
						action.Action.Invoke(value);
						actionFound = true;
						break;
					}
				}
				if(!actionFound)
				{
					ret.Add(name, value);
				}
			}
			return ret;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach(Option option in this)
			{
				sb.AppendFormat("{0}\t{1}", option.Prototype, option.Description ?? "");
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}