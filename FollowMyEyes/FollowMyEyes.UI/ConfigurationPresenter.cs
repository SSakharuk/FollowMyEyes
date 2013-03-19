using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.UI
{
	public class ConfigurationPresenter
	{
		private readonly IData _data;
		private IViewLoader _viewLoader;
		private IConfigurationView _view;

		public ConfigurationPresenter(IData data, IViewLoader viewLoader)
		{
			this._view = _view;
			_data = data;
			_viewLoader = viewLoader;
		}

		public IConfigurationView View
		{
			get { return _view; }
			set { _view = value; }
		}

		public IData Data
		{
			get { return _data; }
		}

		public void UpdateWindowValues()
		{
			UpdateWindowWidth();
			UpdateWindowHeight();
			UpdateWindowName();
			UpdateActionButtonText();
		}

		private void UpdateWindowWidth()
		{
			_view.WindowWidth = Data.WindowWidth;
		}

		private void UpdateWindowHeight()
		{
			_view.WindowHeight = Data.WindowHeight;
		}

		private void UpdateWindowName()
		{
			_view.WindowName = Data.Name;
		}

		private void UpdateActionButtonText()
		{
			_view.ActionButtonName = Data.ActionButtonName;
		}
	}
}