using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class PiDataRepositoryDB
    {
        private readonly PiDataDBContext _context;
        public PiDataRepositoryDB(PiDataDBContext context)
        {
            _context = context;
        }

        public PiData? Get()
        {
            return _context.PiData.LastOrDefault();
        }

    }
}
