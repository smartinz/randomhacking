using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Selenium;

namespace WebApplication.Tests
{
	[TestFixture]
	public class AcceptanceTest
	{
		[Test]
		public void BuildDeployAnTest()
		{
			var processStartInfo = new ProcessStartInfo{
				FileName = @"C:\Windows\Microsoft.NET\Framework\v3.5\MSBuild.exe",
				Arguments = @"/nologo /clp:ErrorsOnly WebApplication\WebApplication.csproj",
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			Process buildProcess = Process.Start(processStartInfo);
			buildProcess.WaitForExit();
			Assert.AreEqual(0, buildProcess.ExitCode, "Compilation error: " + buildProcess.StandardOutput.ReadToEnd());

			Process webServerProcess = Process.Start(new ProcessStartInfo{
				FileName = @"C:\Program Files\Common Files\microsoft shared\DevServer\9.0\WebDev.WebServer.EXE",
				Arguments = "/port:12345 /path:\"" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApplication") + "\"",
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			});

			Process seleniumRcProcess = Process.Start(new ProcessStartInfo{
				FileName = "java.exe",
				Arguments = @"-jar selenium-server\selenium-server.jar",
				WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			});

			ISelenium selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:12345");
			selenium.Start();

			selenium.Open("/");
			selenium.Type("inputTextBox", "Test input");
			selenium.Click("actionButton");
			selenium.WaitForPageToLoad("30000");
			Assert.IsTrue(selenium.IsTextPresent("Test input"));

			try
			{
				selenium.Stop();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}

			seleniumRcProcess.Kill();
			webServerProcess.Kill();
		}
	}
}