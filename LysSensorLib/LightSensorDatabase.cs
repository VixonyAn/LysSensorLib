using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{ // Also a LogEntryDatabase
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

        public IEnumerable<LogEntry> Get(DateTime? date = null) // Dette er vores søge/filter for dato
        {
            IQueryable<LogEntry> query = _context.LogEntries;

            if (date.HasValue)
            {
                DateTime targetDate = date.Value.Date;
                query = query.Where(le => le.TimeTurnedOn.Date == targetDate);
            }
            return query.ToList();
        }

        public LogEntry? GetById(int id)
        {
            return _context.LogEntries.Find(id);
        }
    }
}
