﻿using System;
using System.Windows.Forms;
using FollowMyEyes.Logic;
using FollowMyEyes.ModelTemplate;
using FollowMyEyes.UI;

namespace FollowMyEyes.Main
{
	internal static class StartApplication
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			IData data = new ConfigurationLogic().GetDefaultConfiguration();
			var windowViewLoader = new WindowViewLoader(data);
			windowViewLoader.LoadView();
			Application.Run(windowViewLoader.LastView);
		}
	}
}