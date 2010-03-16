using System;

namespace SpikeWpf
{
	static public class Program
	{
		[STAThread]
		static public void Main()
		{
			var app = new App();
			app.InitializeComponent();
			app.Run();
		}
	}
}