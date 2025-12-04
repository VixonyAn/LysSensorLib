using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class AlarmRepositoryDB : IAlarmRepositoryDB
    {
        private readonly AlarmDBContext _context;

        public AlarmRepositoryDB(AlarmDBContext context)
        {
            _context = context;
        }

        public Alarm Add(Alarm a)
        {
            _context.AlarmData.Add(a);
            a.Id = 0; // Ensure EF Core treats this as a new entity
            _context.SaveChanges();
            return a;
            //husk tilføj logentry når alarmen går af
        }

        public Alarm? Delete(int id)
        {
            Alarm? alarm = GetById(id);
            if (alarm == null)
            {
                return null;
            }
            _context.AlarmData.Remove(alarm);
            _context.SaveChanges();
            return alarm;
        }

        public IEnumerable<Alarm> GetAll()
        {
            return _context.AlarmData.ToList();
        }

        public Alarm? GetById(int id)
        {
            return _context.AlarmData.Find(id);
        }

        public Alarm? Update(int id, Alarm data)
        {
            Alarm? alarm = GetById(id);
            if (alarm == null)
            {
                return null;
            }
            _context.Entry(alarm).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return data;
        }
    }
}
