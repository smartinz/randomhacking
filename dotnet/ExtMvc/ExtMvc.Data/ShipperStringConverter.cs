using System;
using ExtMvc.Domain;
using Nexida.Infrastructure;

namespace ExtMvc.Data
{
	public class ShipperStringConverter : IStringConverter<Shipper>
	{
		private const char KeySeparator = '\\';
		private readonly ShipperRepository _repository;

		public ShipperStringConverter(ShipperRepository repository)
		{
			_repository = repository;
		}

		public string ToString(Shipper obj)
		{
			return obj.ShipperId.ToString();
		}

		public Shipper FromString(string str)
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
			foreach(string key in keys)
			{
				if(key.Trim() == string.Empty)
				{
					throw new ArgumentException("One of the provided keys is empty.", "keyValues");
				}
			}

			if(keys.Length != expectedNumberOfKeys)
			{
				throw new ArgumentException("The number of keys provided does not match the number of expected keys for this object.", "keyValues");
			}

			return keys;
		}
	}
}