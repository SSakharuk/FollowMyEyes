using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FollowMyEyes.Data
{
	public class ProcessesInfo
	{
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		public static IEnumerable<string> GetProcesses()
		{
			Process[] processes = Process.GetProcesses();
			return processes.Select(process => process.ProcessName).ToList();
		}
	}
}
