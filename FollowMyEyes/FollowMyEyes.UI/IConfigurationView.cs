using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.UI
{
	public interface IConfigurationView
	{
		ConfigurationPresenter Presenter { set; }

		int WindowWidth { set; }

		int WindowHeight { set; }

		string WindowName { set; }

		string ActionButtonName { set; }

		IEnumerable<IProcessInfo> Processes { set; }

		IImage ImageSource { set; }

		Dictionary<string, List<Image<Gray, byte>>> FaceImages { get; set; }
	}
}