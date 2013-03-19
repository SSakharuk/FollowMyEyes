using System.Collections.Generic;

namespace FollowMyEyes.ModelTemplate
{
	public interface IConfiguration : IWindowConfiguration, ICameraConfiguration
	{
		string ActionButtonName { get; set; }
		string ProcessesLabel { get; set; }
		IEnumerable<IProcessInfo> ProcessesList { get; set; }
	}
}