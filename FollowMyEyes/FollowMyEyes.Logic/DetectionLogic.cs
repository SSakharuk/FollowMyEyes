using System;
using System.Diagnostics;
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

		public static IImage GetImageFromCamera(Capture capture, HaarCascade faceHaarCascade, HaarCascade eyeHaarCascade)
		{
			Image<Bgr, byte> frame;
			frame = capture.QueryFrame();
			{
				if (frame != null)
				{
					Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
					MCvAvgComp[][] faces = grayFrame.DetectHaarCascade(faceHaarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640/6, 480/6));

					MCvAvgComp[][] eyes = grayFrame.DetectHaarCascade(eyeHaarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640 / 32, 480 / 32));

					foreach (MCvAvgComp face in faces[0])
					{
						frame.Draw(face.rect, new Bgr(0, 256, 0), 3);
					}

					foreach (MCvAvgComp eye in eyes[0])
					{
						frame.Draw(eye.rect, new Bgr(0, 0, 256), 3);
					}	
				}
			}
			return frame;
		}

		public static void CheckEyesDetection(Capture capture, HaarCascade faceHaarCascade, HaarCascade eyeHaarCascade, int processId)
		{
			using (Image<Bgr, byte> frame = capture.QueryFrame())
			{
				if (frame != null)
				{
					Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
					MCvAvgComp[][] faces = grayFrame.DetectHaarCascade(faceHaarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640/6, 480/6));

					if(faces[0].Length >0)
					{
						Process p = Process.GetProcessById(processId);
						SetForegroundWindow(p.MainWindowHandle);
					}
				}
			}
		}
	}
}