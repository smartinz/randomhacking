using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nexida.CodeGen.FileWriteStrategies
{
	public enum TextPartType
	{
		Region,
		Placeholder,
		FreeText
	}

	public class TextPart
	{
		public string Name;
		public TextPartType Type;
		public string Content;

		public TextPart(string name, TextPartType type, string content)
		{
			Name = name;
			Type = type;
			Content = content;
		}
	}

	public class TextMergeFileWriteStrategy : IFileWriteStrategy
	{
		private const RegexOptions Options = RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant;
		private const string StartPattern = "^.*?__NEXIDA_CODEGEN_REGION_(?<type>START|PLACEHOLDER|END)\\s*[\\\"|\\'](?<name>.*?)[\\\"|\\'].*$";

		public void Write(string content, string fileName) {}

		public string Merge(string src, string dest)
		{
			IList<TextPart> srcParts = Split(src);
			IList<TextPart> destParts = Split(dest);
			return Merge(srcParts, destParts);
		}

		public string Merge(IList<TextPart> srcParts, IList<TextPart> destParts)
		{
			var sb = new StringBuilder();
			foreach(TextPart srcPart in srcParts)
			{
				if(srcPart.Type == TextPartType.FreeText)
				{
					sb.Append(srcPart.Content);
				}
				if(srcPart.Type == TextPartType.Region)
				{
					sb.Append(srcPart.Content);
				}
				if(srcPart.Type == TextPartType.Placeholder)
				{
					TextPart destPart = destParts.FirstOrDefault(p => p.Name == srcPart.Name);
					if(destPart != null)
					{
						sb.Append(destPart.Content);
					}
				}
			}
			return sb.ToString();
		}

		public IList<TextPart> Split(string str)
		{
			str = str.Replace("\r\n", "\n");
			List<Match> startMatches = Regex.Matches(str, StartPattern, Options).Cast<Match>().ToList();
			var parts = new List<TextPart>();
			if(startMatches.Count() == 0)
			{
				parts.Add(new TextPart("", TextPartType.FreeText, str));
				NormalizeNewLines(parts);
				return parts;
			}
			if(startMatches.First().Index > 0)
			{
				parts.Add(new TextPart("", TextPartType.FreeText, str.Substring(0, startMatches.First().Index)));
			}
			for(int i = 0; i < startMatches.Count; i++)
			{
				Match startMatch = startMatches[i].Groups["type"].Value == "START" ? startMatches[i] : null;
				Match placeholderMatch = startMatches[i].Groups["type"].Value == "PLACEHOLDER" ? startMatches[i] : null;
				if(startMatch != null)
				{
					if(i >= startMatches.Count - 1)
					{
						throw new ApplicationException("Region not closed: " + startMatch.Value);
					}
					Match endMatch = startMatches[++i];
					if(endMatch.Groups["type"].Value != "END" || endMatch.Groups["name"].Value != startMatch.Groups["name"].Value)
					{
						throw new ApplicationException("Region cannot contain inner regions: " + startMatch.Value);
					}
					parts.Add(new TextPart(startMatch.Groups["name"].Value, TextPartType.Region, str.Substring(startMatch.Index, endMatch.Index + endMatch.Length - startMatch.Index)));
				}
				if(placeholderMatch != null)
				{
					parts.Add(new TextPart(placeholderMatch.Groups["name"].Value, TextPartType.Placeholder, placeholderMatch.Value));
				}
			}
			if(startMatches.Last().Index + startMatches.Last().Length + 1 < str.Length)
			{
				parts.Add(new TextPart("", TextPartType.FreeText, str.Substring(startMatches.Last().Index + startMatches.Last().Length)));
			}
			NormalizeNewLines(parts);
			return parts;
		}

		static private void NormalizeNewLines(IEnumerable<TextPart> parts)
		{
			foreach(TextPart part in parts)
			{
				part.Name = part.Name.Replace("\n", Environment.NewLine);
				part.Content = part.Content.Replace("\n", Environment.NewLine);
			}
		}
	}
}