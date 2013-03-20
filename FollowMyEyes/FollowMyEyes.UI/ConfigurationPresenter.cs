using System;
using System.Drawing;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using FollowMyEyes.Logic;
using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.UI
{
	public class ConfigurationPresenter
	{
		private readonly IData _data;
		private IConfigurationView _view;
		private IViewLoader _viewLoader;
		private Capture _capture;
		private DispatcherTimer _dispatcherTimer;
		private HaarCascade _haarCascade;

		public ConfigurationPresenter(IData data, IViewLoader viewLoader)
		{
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

		public void UpdateWindowControls()
		{
			UpdateWindowWidth();
			UpdateWindowHeight();
			UpdateWindowName();
			UpdateActionButtonText();
			UpdateProcesses();
			StartCameraDetection();
		}

		public void StartFollowEyes()
		{
			StopCameraDetection();
			CheckEyes();

		}

		private void CheckEyes()
		{
			_capture = _capture ?? new Capture();
			_haarCascade = _haarCascade ?? new HaarCascade(@"haarcascade_frontalface_alt.xml");
			_dispatcherTimer = _dispatcherTimer ?? new DispatcherTimer();
			_dispatcherTimer.Tick += CheckEyes;
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
			_dispatcherTimer.Start();
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

		private void UpdateProcesses()
		{
			_view.Processes = Data.ProcessesList;
		}

		private void UpdateImage()
		{
			_view.ImageSource = DetectionLogic.GetImageFromCamera(_capture, _haarCascade);
		}

		private void StartCameraDetection()
		{
			_capture = _capture ?? new Capture();
			_haarCascade = _haarCascade ?? new HaarCascade(@"haarcascade_frontalface_alt.xml");
			_dispatcherTimer =_dispatcherTimer ?? new DispatcherTimer();
			_dispatcherTimer.Tick += ShowCameraFrame;
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
			_dispatcherTimer.Start();
		}

		private void StopCameraDetection()
		{
			_dispatcherTimer.Stop();
			_dispatcherTimer.Tick -= ShowCameraFrame;
		}

		private void ShowCameraFrame(object sender, EventArgs e)
		{
			UpdateImage();
		}

		private void CheckEyes(object sender, EventArgs e)
		{
			DetectionLogic.CheckEyesDetection(_capture, _haarCascade);
		}
	}
}