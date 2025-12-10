namespace LysSensorLib
{
    public interface IPiDataRepositoryDB
    {
        List<PiData> GetAll();
        PiData? Get();
        PiData Add(PiData p);
    }
}