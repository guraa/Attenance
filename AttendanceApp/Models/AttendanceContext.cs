using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AttendanceApp
{
    public class AttendanceContext : DbContext
    {
        public DbSet<Enrolled> Enrolled { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Participation> Participation { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Init> Init { get; set; }
    }
}