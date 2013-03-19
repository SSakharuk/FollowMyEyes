namespace FollowMyEyes.UI
{
	public interface IConfigurationView
	{
		ConfigurationPresenter Presenter { set; }

		int WindowWidth { set; }

		int WindowHeight { set; }

		string WindowName { set; }

		string ActionButtonName { set; }
	}
}