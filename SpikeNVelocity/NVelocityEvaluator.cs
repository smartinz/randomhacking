using System.Collections.Generic;
using System.IO;
using NVelocity;
using NVelocity.App;

namespace SpikeNVelocity
{
	/// <summary>
	/// Howto get and compile NVelocity
	///	install subversion commandline interface (not tortoise!). This is needed to set library version correctly
	/// Checkout the full casle project
	///		svn co https://svn.castleproject.org/svn/castle/trunk
	/// Build castle project
	///		build.cmd
	/// You should have NVelocity.dll in the folder
	///		build\net-3.5\release
	/// "Revision" part of the DLL file version correspond to the SVN revision, for example
	///		NVelocity.dll 1.0.3.5700 => has been built with sources revision 5700
	/// </summary>
	public class NVelocityEvaluator
	{
		public string Evaluate(string template, IDictionary<string, object> context)
		{
			var velocityContext = new VelocityContext();
			foreach (var keyValuePair in context)
			{
				velocityContext.Put(keyValuePair.Key, keyValuePair.Value);
			}
			var velocity = new VelocityEngine();
			velocity.Init();
			var writer = new StringWriter();
			velocity.Evaluate(velocityContext, writer, null, template);
			return writer.GetStringBuilder().ToString();
		}
	}
}