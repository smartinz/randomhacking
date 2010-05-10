using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ExtMvc.Infrastructure
{
	public class PropertyError
	{
		public PropertyError()
		{
			Errors = new ModelErrorCollection();
			Properties = new Dictionary<string, PropertyError>();
			Indexes = new Dictionary<int, PropertyError>();
		}

		public ModelErrorCollection Errors { get; set; }
		public Dictionary<string, PropertyError> Properties { get; set; }
		public Dictionary<int, PropertyError> Indexes { get; set; }

		public PropertyError this[string property]
		{
			get
			{
				if(!Properties.ContainsKey(property))
				{
					Properties.Add(property, new PropertyError());
				}
				return Properties[property];
			}
		}

		public PropertyError this[int index]
		{
			get
			{
				if(!Indexes.ContainsKey(index))
				{
					Indexes.Add(index, new PropertyError());
				}
				return Indexes[index];
			}
		}

		public string BuildMessage()
		{
			return string.Join(". ", Errors.Select(e => e.Exception == null ? e.ErrorMessage : e.Exception.Message));
		}
	}
}