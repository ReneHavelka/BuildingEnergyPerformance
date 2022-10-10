namespace Application.Common.Interfaces
{
	public interface IIndex
	{
		IEnumerable<KeyValuePair<string, string>>? IssueKeyValue { get; }
	}
}
