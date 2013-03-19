namespace FollowMyEyes.ModelTemplate
{
	public interface IProcessInfo
	{
		int ProcessId { get; set; }
		string ProcessName { get; set; }
		string ProcessMainWindowTitle { get; set; }
	}
}