using System;
using System.Windows.Forms;
using FollowMyEyes.Data;
using FollowMyEyes.ModelTemplate;
using FollowMyEyes.UI;

namespace FollowMyEyes.Main
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			IData data = new Configuration();
			var windowViewLoader = new WindowViewLoader(data);
			windowViewLoader.LoadConfigurationView();
			Application.Run(windowViewLoader.LastView);
		}
	}
}