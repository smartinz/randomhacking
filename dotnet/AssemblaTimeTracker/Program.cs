using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AssemblaTimeTracker
{
	static internal class Program
	{
		[STAThread]
		static private void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}