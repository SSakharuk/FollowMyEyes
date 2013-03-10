using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.UI
{
	public class ConfigurationPresenter
	{
		private readonly IData _data;
		private IViewLoader _viewLoader;

		public ConfigurationPresenter(IData data, IViewLoader viewLoader)
		{
			_data = data;
			_viewLoader = viewLoader;
		}

		public IConfigurationView View { get; set; }

		public IData Data
		{
			get { return _data; }
		}
	}
}