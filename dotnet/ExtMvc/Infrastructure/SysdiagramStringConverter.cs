using System;

namespace ExtMvc.Infrastructure
{
	public class SysdiagramStringConverter
	{
		const char KeySeparator = '\\';
		private readonly ExtMvc.Data.SysdiagramRepository _repository;

		public SysdiagramStringConverter(ExtMvc.Data.SysdiagramRepository repository)
		{
			_repository = repository;
		}

		public string ToString(ExtMvc.Domain.Sysdiagram obj)
		{
			return obj.DiagramId.ToString();
		}

		public ExtMvc.Domain.Sysdiagram FromString(string str)
		{
			string[] keys = ParseKeys(str, 1);
			return _repository.Read(Convert.ToInt32(keys[0]));
		}
		
		/// <summary>
		/// Parses the keys.
		/// </summary>
		/// <param name="keyValues">The key values.</param>
		/// <param name="expectedNumberOfKeys">The expected number of keys.</param>
		/// <returns>The array containing the keys.</returns>
		public static string[] ParseKeys(string keyValues, int expectedNumberOfKeys)
		{
			string[] keys = keyValues.Split(KeySeparator);
			foreach (string key in keys)
			{
				if (key.Trim() == string.Empty)
					throw new ArgumentException("One of the provided keys is empty.", "keyValues");
			}

			if (keys.Length != expectedNumberOfKeys)
				throw new ArgumentException("The number of keys provided does not match the number of expected keys for this object.", "keyValues");

			return keys;
		}
	}
}