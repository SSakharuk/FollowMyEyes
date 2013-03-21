using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FollowMyEyes.Logic
{
	public class DetectionLogic
	{
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		public static IImage GetImageFromCamera(Capture capture, HaarCascade haarCascade)
		{
			Image<Bgr, byte> frame;
			frame = capture.QueryFrame();
			//using (frame = capture.QueryFrame())
			{
				if (frame != null)
				{
					Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
					MCvAvgComp[][] faces = grayFrame.DetectHaarCascade(haarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640/4, 480/3));

					foreach (MCvAvgComp face in faces[0])
						frame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
				}
			}
			return frame;
		}

		public static void CheckEyesDetection(Capture capture, HaarCascade haarCascade)
		{
			using (Image<Bgr, byte> frame = capture.QueryFrame())
			{
				if (frame != null)
				{
					Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
					MCvAvgComp[][] faces = grayFrame.DetectHaarCascade(haarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640/4, 480/3));

					if(faces[0].Length >0)
					{
						System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("notepad");
						if (p.Length > 0)
						{
							SetForegroundWindow(p[0].MainWindowHandle);
						}
					}
				}
			}
		}
	}
}