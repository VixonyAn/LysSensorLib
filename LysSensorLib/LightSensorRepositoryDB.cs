using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{ // Also a LogEntryDatabase
	public class LightSensorRepositoryDB : ILightSensorRepositoryDB
	{
		private readonly LightSensorDBContext _context;

		public LightSensorRepositoryDB(LightSensorDBContext context)
		{
			_context = context;
		}

		public LogEntry Add(LogEntry l)
		{
			_context.LightData.Add(l);
			l.Id = 0; // Ensure EF Core treats this as a new entity
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
			_context.LightData.Remove(logEntry);
			_context.SaveChanges();
			return logEntry;
		}

		public IEnumerable<LogEntry> Get(
			DateTime? date = null, // Dette er vores søge/filter for dato
			bool? descending = null) //Sort by TimeTurnedOn.Date ascending by default.
		{
			IQueryable<LogEntry> query = _context.LightData;

			if (date != null)
			{
				DateTime targetDate = date.Value.Date;
				query = query.Where(le => le.TimeTurnedOn == targetDate);
			}
			if (descending != null)
			{
				query = (bool)descending
				? query.OrderByDescending(le => le.TimeTurnedOn)
				: query.OrderBy(le => le.TimeTurnedOn);
			}

			return query.ToList();
		}

		public LogEntry? GetById(int id)
		{
			return _context.LightData.Find(id);
		}
	}
}
