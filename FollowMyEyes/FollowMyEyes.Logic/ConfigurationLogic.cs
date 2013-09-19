using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Emgu.CV;
using Emgu.CV.Structure;
using FollowMyEyes.Data;
using System.Diagnostics;

namespace FollowMyEyes.Logic
{
	public class ConfigurationLogic
	{
		public Configuration GetDefaultConfiguration()
		{
			var configuration = new Configuration();
			SetDefaultConfiguration(configuration);
			return configuration;
		}

		private void SetDefaultConfiguration(Configuration configuration)
		{
			configuration.WindowWidth = 1080;
			configuration.WindowHeight = 480;
			configuration.Name = "Configuration Window";
			configuration.DetailsDescription = "None";
			configuration.ActionButtonName = "Follow Eyes";
			configuration.ProcessesLabel = "Available Processes";
			configuration.DetectionDelay = 0.1d;
			configuration.ProcessesList = ProcessesLogic.GetProcesses();
			configuration.FaceImages = GetImages();
		}

		private Dictionary<string, List<Image<Gray, byte>>> GetImages()
		{
			string executingFile = System.Reflection.Assembly.GetEntryAssembly().Location;
			string exeecutingPath = executingFile.Substring(0, executingFile.LastIndexOf(@"\"));

			string path = string.Format(@"{0}\{1}", exeecutingPath, "Faces");
			
			string[] faceImages = Directory.GetFiles(path, "*.bmp");


			var dictionary = new Dictionary<string, List<Image<Gray, byte>>>();

			foreach (var faceImage in faceImages)
			{
				string fileName = Path.GetFileName(faceImage);
				string name = fileName.Substring(fileName.IndexOf('_') + 1, fileName.IndexOf('.') - fileName.IndexOf('_') - 1);
				
				if (!dictionary.ContainsKey(name))
				{
					var list = new List<Image<Gray, byte>> {new Image<Gray, byte>(faceImage)};
					dictionary.Add(name, list);
				}
				else
				{
					var currentList = dictionary[name];
					currentList.Add(new Image<Gray, byte>(faceImage));
				}																		
			}

			return dictionary;
		}
	}
}