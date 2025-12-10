namespace LysSensorLib
{
    public interface IPiDataRepositoryDB
    {
        List<PiData> GetAll();
        PiData? GetById(int id);
		PiData? Get();
        PiData Add(PiData p);
        public PiData? Delete(int id);

	}
}