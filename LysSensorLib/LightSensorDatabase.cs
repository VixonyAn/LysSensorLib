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

        public IEnumerable<LogEntry> Get(
            DateTime? date = null, // Dette er vores søge/filter for dato
            bool? descending = null) //Sort by TimeTurnedOn.Date ascending by default.
        {
            IQueryable<LogEntry> query = _context.LogEntries;

            if (date != null)
            {
                DateTime targetDate = date.Value.Date;
                query = query.Where(le => le.TimeTurnedOn.Date == targetDate);
            }
            if (descending != null)
            {
                query = (bool)descending
                ? query.OrderByDescending(le => le.TimeTurnedOn.Date)
                : query.OrderBy(le => le.TimeTurnedOn.Date);
            }

            return query.ToList();
        }

        public LogEntry? GetById(int id)
        {
            return _context.LogEntries.Find(id);
        }
    }
}
