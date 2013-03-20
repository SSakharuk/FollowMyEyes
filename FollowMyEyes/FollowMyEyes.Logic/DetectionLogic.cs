using System;
using System.Drawing;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FollowMyEyes.Logic
{
	public class DetectionLogic
	{
		private Capture _capture;
		private DispatcherTimer _dispatcherTimer;
		private HaarCascade _haarCascade;

		public IImage GetImageFromCamera()
		{
			_capture = new Capture();
			_haarCascade = new HaarCascade(@"haarcascade_frontalface_alt.xml");
			_dispatcherTimer.Tick += TimerTick;
			_dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
			_dispatcherTimer.Start();
			return null;
		}

		private void TimerTick(object sender, EventArgs e)
		{
			using (Image<Bgr, byte> frame = _capture.QueryFrame())
			{
				if (frame != null)
				{
					Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
					MCvAvgComp[][] faces = grayFrame.DetectHaarCascade(_haarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
					                                                   new Size(640, 480));

					foreach (MCvAvgComp face in faces[0])
						frame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
				}
			}
		}
	}
}