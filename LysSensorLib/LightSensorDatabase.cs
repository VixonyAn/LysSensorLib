using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class LightSensorDatabase
    {
        private readonly LightSensorDBContext _context;

        public LightSensorDatabase(LightSensorDBContext context)
        {
            _context = context;
        }

        public LogEntry Add(LogEntry l)
        {
            _context.LogEntries.Add(l);
            _context.SaveChanges();
            return l;
        }

        public LogEntry? Delete(int id)
        {
            LogEntry? logEntry = GetById(id);
            if (logEntry is null)
            {
                return null;
            }
            _context.LogEntries.Remove(logEntry);
            _context.SaveChanges();
            return logEntry;
        }

        public IEnumerable<LogEntry> Get()
        {
            throw new NotImplementedException();
        }

        public LogEntry? GetById(int id)
        {
            return _context.LogEntries.Find(id);
        }
    }
}
