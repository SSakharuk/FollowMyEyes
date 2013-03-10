using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.Data
{
	public class Configuration : IData
	{
		public Configuration()
		{
		}

		public Configuration(int width, int height, string name, string detailsDescription, double detectionDelay)
		{
			Width = width;
			Height = height;
			Name = name;
			DetailsDescription = detailsDescription;
			DetectionDelay = detectionDelay;
		}

		#region IData Members

		public int Width { get; set; }
		public int Height { get; set; }
		public string Name { get; set; }
		public string DetailsDescription { get; set; }
		public double DetectionDelay { get; set; }

		#endregion
	}
}