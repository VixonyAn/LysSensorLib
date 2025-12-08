using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LysSensorLib
{
    public class PiDataDBContext : DbContext
    {
     
         public PiDataDBContext(DbContextOptions<PiDataDBContext> options) : base(options)
         {

         }
         public DbSet<PiData> PiData { get; set; }
        
    }
}
