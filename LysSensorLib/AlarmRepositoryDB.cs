using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class AlarmRepositoryDB
    {
        private string connectionString = Secret.ConnectionString;

        public LogEntry Add(Alarm a)
        {
            throw new NotImplementedException();
            //husk tilføj logentry når alarmen går af
        }

        public LogEntry? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogEntry> GetAll()
        {
            throw new NotImplementedException();
        }

        public LogEntry? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public LogEntry? Update(int id, LogEntry data)
        {
            throw new NotImplementedException();
        }
    }
}
