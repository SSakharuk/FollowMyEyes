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
		private int _processId;
		private IConfigurationView _view;
		private IViewLoader _viewLoader;
		private Capture _capture;
		private DispatcherTimer _dispatcherTimer;
		private HaarCascade _faceHaarCascade;
		private HaarCascade _eyeHaarCascade;
		private bool _eyeDetection;
		private bool _faceRecognition;

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
			UpdateFaceImages();
			StartCameraDetection();
		}

		public void UpdateDetectionOptions(bool needEyeDetection, bool needFaceRecognition)
		{
			_eyeDetection = needEyeDetection;
			_faceRecognition = needFaceRecognition;
		}

		public void StartFollowEyes(int processId)
		{
			_processId = processId;
			StopCameraDetection();
			CheckEyes();
		}

		#region Reimplement

		// For configuration
		private void CheckEyes()
		{
			_capture = _capture ?? new Capture();
			_faceHaarCascade = _faceHaarCascade ?? new HaarCascade(@"haarcascade_frontalface_alt.xml");
			_dispatcherTimer = _dispatcherTimer ?? new DispatcherTimer();
			_dispatcherTimer.Tick += CheckEyes;
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
			_dispatcherTimer.Start();
		}

		// For usage
		private void StartCameraDetection()
		{
			_capture = _capture ?? new Capture();
			_faceHaarCascade = _faceHaarCascade ?? new HaarCascade(@"haarcascade_frontalface_alt.xml");
			_eyeHaarCascade = _eyeHaarCascade ?? new HaarCascade(@"haarcascade_eye.xml");
			_dispatcherTimer = _dispatcherTimer ?? new DispatcherTimer();
			_dispatcherTimer.Tick += ShowCameraFrame;
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
			_dispatcherTimer.Start();
		}

		#endregion

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
			_view.ImageSource = DetectionLogic.GetImageFromCamera(_capture, _faceHaarCascade, _eyeHaarCascade, _eyeDetection, _faceRecognition, _view.FaceImages);
		}

		private void UpdateFaceImages()
		{
			_view.FaceImages = Data.FaceImages;
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
			DetectionLogic.CheckEyesDetection(_capture, _faceHaarCascade, _processId);
		}

		public void SaveFace(string name)
		{
			_view.FaceImages = DetectionLogic.SaveFace(name, _view.FaceImages);
		}
	}
}