using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class LightSensorDBContext : DbContext
    {
        public LightSensorDBContext(DbContextOptions<LightSensorDBContext> options) : base(options)
        {
            
        }
        public DbSet<LogEntry> LightData { get; set; }
    }
}
