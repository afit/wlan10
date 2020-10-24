// Netshell.cs in Wlan10/Wlan10
// Created 2016/08/27
// Copyright ©2016 Bertware (bertware.net)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Printing.IndexedProperties;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using Net.Bertware.Wlan10.Model;

namespace Net.Bertware.Wlan10.Controller
{
	/// <summary>
	///     Netshell interactions
	/// </summary>
	public static class Netshell
	{
		private const string CmdList = "wlan sh profiles";

		public static ObservableCollection<WlanNetwork> GetNetworks()
		{
			ObservableCollection<WlanNetwork> results = new ObservableCollection<WlanNetwork>();

			foreach (String network in GetNetworkNames( NetshellCmd(CmdList) ))
			{
				results.Add(new WlanNetwork(network));
			}
			return results;
		}

		public static ObservableCollection<String> GetNetworkNames( String output )
        {
			// This'll give us chunks of network names, separated by LFs.
			MatchCollection m = Regex.Matches(
				// Strip the CRs out, leaving only LFs behind. We do this because people leave
				// sample output in UNIX format in the issue tracker. Easier to assume this is
				// simply UNIX-formatted rather than handling both LF and CRLF throughout.
				output.Replace("\r", ""), "(?s)---\n(.*?)\n\n"
			);

			ObservableCollection<String> networks = new ObservableCollection<String>();

			foreach (Match mx in m)
			{
				string[] names = mx.Groups[1].Value.Split("\n");

				foreach (String name in names ) { 
					if (name.Contains(":"))
					{
						String network = name.Split(": ")[1];
						Console.WriteLine(network);
						networks.Add(network);
					}
				}
			}

			return networks;
		}

		public static string NetshellCmd(string cmd)
		{
			// Start the child process.
			Process p = new Process();

			// Redirect the output stream of the child process.
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;

			// The default codepage (and console output) in your Windows is almost certainly not Unicode.
			// If you're alive in 2017 you likely see network SSIDs with lovely international characters,
			// emoji and other good stuff. So we need to do something. Alas, you can't set console output
			// encoding of a Windows app in debug mode according to Jon Skeet:
			//    https://stackoverflow.com/a/18580114/83089
			//
			// Ideally we'd use the following, but if you try to run it in VisualStudio, it'll throw:
			//    System.Console.OutputEncoding = System.Text.Encoding.UTF8;
			//
			// If we use the PowerShell chcp command to set the console's output with our process object,
			// the codepage will reset before our next command. The solution? Chain commands with cmd.exe.
			// Nasty, but it works.
			p.StartInfo.FileName = "cmd.exe";
			p.StartInfo.Arguments = "/C chcp 65001 && netsh " + cmd;
			p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
			p.StartInfo.CreateNoWindow = true;
			p.Start();

			// Do not wait for the child process to exit before
			// reading to the end of its redirected stream.
			// p.WaitForExit();

			// Read the output stream first and then wait.
			string output = p.StandardOutput.ReadToEnd();
			p.WaitForExit();
			return output;
		}
	}
}