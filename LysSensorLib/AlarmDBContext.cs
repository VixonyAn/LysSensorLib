using Microsoft.EntityFrameworkCore;

namespace LysSensorLib
{
    public class AlarmDBContext : DbContext
    {
        public AlarmDBContext(DbContextOptions<AlarmDBContext> options) : base(options)
        {

        }
        public DbSet<Alarm> AlarmData { get; set; }
    }
}