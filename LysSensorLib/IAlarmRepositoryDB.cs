
namespace LysSensorLib
{
    public interface IAlarmRepositoryDB
    {
        Alarm Add(Alarm a);
        Alarm? Delete(int id);
        IEnumerable<Alarm> GetAll();
        Alarm? GetById(int id);
        Alarm? Update(int id, Alarm data);
    }
}