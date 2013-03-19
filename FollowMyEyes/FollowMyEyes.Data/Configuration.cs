using System.Collections.Generic;
using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.Data
{
	public class Configuration : IData
	{
		#region IData Members

		public int WindowWidth { get; set; }
		public int WindowHeight { get; set; }
		public string Name { get; set; }
		public string DetailsDescription { get; set; }
		public double DetectionDelay { get; set; }
		public string ActionButtonName { get; set; }
		public string ProcessesLabel { get; set; }
		public IEnumerable<string> ProcessesName { get; set; }

		public void SetDefaultConfiguration()
		{
			WindowWidth = 640;
			WindowHeight = 480;
			Name = "Configuration Window";
			DetailsDescription = "None";
			ActionButtonName = "Follow Eyes";
			ProcessesLabel = "Available Processes";
			DetectionDelay = 0.1d;
			ProcessesName = ProcessesInfo.GetProcesses();
		}
			


		#endregion

		
	}
}