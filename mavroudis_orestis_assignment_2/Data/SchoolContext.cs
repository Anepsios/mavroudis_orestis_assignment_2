using mavroudis_orestis_assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace mavroudis_orestis_assignment_2.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // de 8elw plh8untikous
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}