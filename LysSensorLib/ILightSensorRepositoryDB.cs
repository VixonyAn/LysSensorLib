
namespace LysSensorLib
{
	public interface ILightSensorRepositoryDB
	{
		LogEntry Add(LogEntry l);
		LogEntry? Delete(int id);
		IEnumerable<LogEntry> Get(long? date = null, bool? descending = null);
		LogEntry? GetById(int id);
	}
}