using System.Windows.Forms;
using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.UI
{
	public class WindowViewLoader : IViewLoader
	{
		private readonly IData _data;
		private Form _lastView;

		public WindowViewLoader(IData data)
		{
			_data = data;
		}

		public Form LastView
		{
			get { return _lastView; }
		}

		#region IViewLoader Members

		public void LoadView()
		{
			var view = new ConfigurationWindow();
			var presenter = new ConfigurationPresenter(_data, this);
			view.Presenter = presenter;
			presenter.View = view;
			presenter.UpdateWindowControls();
			LoadView(view);
		}

		#endregion

		private void LoadView(Form view)
		{
			view.Show();
			_lastView = view;
		}
	}
}