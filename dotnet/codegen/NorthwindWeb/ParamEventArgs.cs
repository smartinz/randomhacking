using System;

namespace NorthwindWeb
{
	public class ParamEventArgs<T> : EventArgs
	{
		public ParamEventArgs(T param)
		{
			Param = param;
		}

		public ParamEventArgs() { }

		public T Param { get; set; }
	}
}