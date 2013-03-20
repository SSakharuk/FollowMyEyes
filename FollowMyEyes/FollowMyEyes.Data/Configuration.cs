using System.Collections.Generic;
using Emgu.CV;
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
		public IImage Image { get; set; }
		public string ActionButtonName { get; set; }
		public string ProcessesLabel { get; set; }
		public IEnumerable<IProcessInfo> ProcessesList { get; set; }

		#endregion
	}
}