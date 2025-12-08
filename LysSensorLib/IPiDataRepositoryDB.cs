namespace LysSensorLib
{
    public interface IPiDataRepositoryDB
    {
        PiData? Get();
        PiData Add(PiData p);
    }
}