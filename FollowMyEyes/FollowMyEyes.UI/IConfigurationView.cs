using System.Collections.Generic;
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
	}
}