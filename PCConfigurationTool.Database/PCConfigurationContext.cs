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

        public PCConfigurationContext()
            :base("name=PCConfigurationConnectionString")
        {
        }

        public DbSet<PCComponent> PCComponents { get; set; }

        public DbSet<PCConfiguration> PCConfigurations { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PCComponent>()
                .HasKey(pcc => pcc.ID);

            builder.Entity<PCConfiguration>()
                .HasKey(pccon => pccon.ID)
                .HasMany(pccon => pccon.PCComponents)
                .WithMany(comp => comp.PCConfigurations)
                .Map(concomp =>
                {
                    concomp.MapLeftKey("PCConfigurationRefID");
                    concomp.MapRightKey("PCComponentRefID");
                    concomp.ToTable("PCConfigurationComponent");
                });
        }
    }
}
