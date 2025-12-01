
namespace LysSensorLib
{
	public interface ILightSensorRepositoryDB
	{
		LogEntry Add(LogEntry l);
		LogEntry? Delete(int id);
		IEnumerable<LogEntry> Get(DateTime? date = null, bool? descending = null);
		LogEntry? GetById(int id);
	}
}