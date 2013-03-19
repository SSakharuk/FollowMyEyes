using FollowMyEyes.Data;

namespace FollowMyEyes.Logic
{
	public class ConfigurationLogic
	{
		public Configuration GetDefaultConfiguration()
		{
			var configuration = new Configuration();
			SetDefaultConfiguration(configuration);
			return configuration;
		}

		private void SetDefaultConfiguration(Configuration configuration)
		{
			configuration.WindowWidth = 640;
			configuration.WindowHeight = 480;
			configuration.Name = "Configuration Window";
			configuration.DetailsDescription = "None";
			configuration.ActionButtonName = "Follow Eyes";
			configuration.ProcessesLabel = "Available Processes";
			configuration.DetectionDelay = 0.1d;
			configuration.ProcessesList = ProcessesLogic.GetProcesses();
		}
	}
}