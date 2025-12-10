using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class PiDataRepositoryDB : IPiDataRepositoryDB
    {
        private readonly PiDataDBContext _context;
        public PiDataRepositoryDB(PiDataDBContext context)
        {
            _context = context;
        }

        public List<PiData> GetAll()
        {
            return _context.PiData.ToList();
        }

        public PiData? Get()
        {
			return _context.PiData.OrderBy(x => x.Id).LastOrDefault();
		}

        public PiData Add(PiData p)
        {
            _context.PiData.Add(p);
            p.Id = 0;
            _context.SaveChanges();
            return p;
        }
    }
}
