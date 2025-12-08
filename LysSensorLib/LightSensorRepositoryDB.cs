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
		private readonly PiDataRepositoryDB piRepo;

        public LightSensorRepositoryDB(LightSensorDBContext context)
		{
			_context = context;
		}

		public LogEntry Add()
		{
			LogEntry l = new LogEntry();
            int? lightvalue = piRepo.Get().LightValue;
            if (lightvalue == null)
            {
                throw new ArgumentException("No light value available from PiDataRepositoryDB.");
            }
			l.LightLevel = lightvalue.Value;
			if (l.LightLevel < 10000)
			{
				l.IsDrawn = true;
				l.LightsOn = true;
            }
            else
			{
				l.IsDrawn = false;
				l.LightsOn = false;
            }
			l.TimeTurnedOn = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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
			long? date = null, // Dette er vores søge/filter for dato
			bool? descending = null) //Sort by TimeTurnedOn.Date ascending by default.
		{
			IQueryable<LogEntry> query = _context.LightData;

			if (date != null)
			{
				long targetDate = date.Value;
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
