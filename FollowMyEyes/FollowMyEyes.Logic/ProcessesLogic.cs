using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using FollowMyEyes.Data;
using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.Logic
{
	public class ProcessesLogic
	{
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		public static IEnumerable<IProcessInfo> GetProcesses()
		{
			Process[] processes = Process.GetProcesses();
			return (from process in processes
			        where process.MainWindowHandle != IntPtr.Zero
			        select
				        new ProcessesInfo
					        {
						        ProcessId = process.Id,
						        ProcessMainWindowTitle = process.MainWindowTitle,
						        ProcessName = process.ProcessName
					        }).Cast<IProcessInfo>().ToList();
		}
	}
}