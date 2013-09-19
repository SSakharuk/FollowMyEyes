using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FollowMyEyes.ModelTemplate
{
	public interface IConfiguration : IWindowConfiguration, ICameraConfiguration
	{
		string ActionButtonName { get; set; }
		string ProcessesLabel { get; set; }
		IEnumerable<IProcessInfo> ProcessesList { get; set; }
		Dictionary<string, List<Image<Gray, byte>>> FaceImages { get; set; }
	}
}