using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FollowMyEyes.Data;

namespace FollowMyEyes.Logic
{
	public class ConfigurationController
	{
		public Configuration GetDefaultConfiguration()
		{
			var configuration = new Configuration();
			configuration.SetDefaultConfiguration();
			return configuration;
		}
	}
}
