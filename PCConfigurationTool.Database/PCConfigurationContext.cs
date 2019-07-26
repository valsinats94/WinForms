using PCConfigurationTool.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Database
{
    public class PCConfigurationContext : DbContext
    {
        protected PCConfigurationContext()
            :base("name=PCConfigurationConnectionString")
        {
           
        }

        public DbSet<PCComponent> PCComponents { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<PCComponent>()
                .HasKey(pcc => pcc.ID);
        }
    }
}
