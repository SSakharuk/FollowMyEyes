using System.Collections.Generic;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FollowMyEyes.UI
{
	public partial class ConfigurationWindow : Form
	{
		public ConfigurationWindow()
		{
			InitializeComponent();
		}

		private void _checkEyes_CheckedChanged(object sender, System.EventArgs e)
		{
			 presenter.UpdateDetectionOptions(_checkEyes.Checked, _checkFaceRecognition.Checked);
		}

		private void _checkFaceRecognition_CheckedChanged(object sender, System.EventArgs e)
		{
			presenter.UpdateDetectionOptions(_checkEyes.Checked, _checkFaceRecognition.Checked);
		}

		public Dictionary<string, List<Image<Gray, byte>>> FaceImages { get; set; }
	}
}