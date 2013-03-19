using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.Data
{
	public class ProcessesInfo : IProcessInfo
	{
		#region IProcessInfo Members

		public int ProcessId { get; set; }
		public string ProcessName { get; set; }
		public string ProcessMainWindowTitle { get; set; }

		#endregion
	}
}