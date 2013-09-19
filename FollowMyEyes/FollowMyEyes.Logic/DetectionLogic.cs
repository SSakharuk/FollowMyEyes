using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FollowMyEyes.Logic
{
	public class DetectionLogic
	{
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		private static bool _canSaveFace = false;
		private static Image<Gray, byte> _frame;
		private static List<string> _nameList = new List<string>();
		private static List<Image<Gray, byte>> _imageList = new List<Image<Gray, byte>>();
		private static int _imageCount;
		private static MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 1, 1);

		public static IImage GetImageFromCamera(Capture capture, HaarCascade faceHaarCascade, HaarCascade eyeHaarCascade, bool needEyeDetection, bool needFaceRecognition, Dictionary<string, List<Image<Gray, byte>>> faceImages)
		{
			Image<Bgr, byte> frame = capture.QueryFrame();
			_canSaveFace = false;
			{
				if (frame != null)
				{
					Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();

					MCvAvgComp[][] faces = grayFrame.DetectHaarCascade(faceHaarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640/6, 480/6));

					if (faces[0].Length == 1)
					{
						_canSaveFace = true;
						_frame = grayFrame.Copy();
					}

					foreach (MCvAvgComp face in faces[0])
					{
						frame.Draw(face.rect, new Bgr(0, 256, 0), 3);

						if (needFaceRecognition)
						{
							int imagesSum = faceImages.Sum(x => x.Value.Count);
							var criteria = new MCvTermCriteria(imagesSum, 0.001);
							var currentFrame = grayFrame.Copy().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

							if (imagesSum != _imageCount)
							{
								_nameList.Clear();
								_imageList.Clear();
								_imageCount = imagesSum;
								foreach (var images in faceImages)
								{
									foreach (var image in images.Value)
									{
										_nameList.Add(images.Key);
										_imageList.Add(image);
									}
								}
							}


							EigenObjectRecognizer recognizer = new EigenObjectRecognizer(_imageList.ToArray(), _nameList.ToArray(), 3000,
							                                                             ref criteria);
							var imageName = recognizer.Recognize(currentFrame);

							if (!string.IsNullOrEmpty(imageName))
							{
								frame.Draw(imageName, ref font, new Point(face.rect.X, face.rect.Y), new Bgr(Color.Cyan));
							}
						}
					}

					if (needEyeDetection)
					{
						MCvAvgComp[][] eyes = grayFrame.DetectHaarCascade(eyeHaarCascade, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
																	   new Size(640 / 32, 480 / 32));

						foreach (MCvAvgComp eye in eyes[0])
						{
							frame.Draw(eye.rect, new Bgr(0, 0, 256), 3);
						}
					}
				}
			}
			return frame;
		}

		public static void CheckEyesDetection(Capture capture, HaarCascade faceHaarCascade, int processId)
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

		public static Dictionary<string, List<Image<Gray, byte>>> SaveFace(string imageName, Dictionary<string, List<Image<Gray, byte>>> faceImages)
		{
			if (_canSaveFace)
			{
				// Save Face
				string executingFile = System.Reflection.Assembly.GetEntryAssembly().Location;
				string exeecutingPath = executingFile.Substring(0, executingFile.LastIndexOf(@"\"));
				string path = string.Format(@"{0}\{1}", exeecutingPath, "Faces");
				var count = Directory.GetFiles(path, "*.bmp").Length + 1;
				_frame = _frame.Resize(100, 100, INTER.CV_INTER_CUBIC);
				_frame.Save(string.Format(@"{0}\{1}_{2}.bmp",path, count.ToString().PadLeft(4, '0'), imageName));

				if (!faceImages.ContainsKey(imageName))
 				{
 					var list = new List<Image<Gray, byte>> { _frame };
 					faceImages.Add(imageName, list);
 				}
 				else
 				{
					var faceList = faceImages[imageName];
					faceList.Add(_frame);
 				}
			}
			return faceImages;
		}
	}
}