using Emgu.CV;

namespace FollowMyEyes.ModelTemplate
{
	public interface ICameraConfiguration
	{
		double DetectionDelay { get; set; }
		IImage Image { get; set; }
	}
}