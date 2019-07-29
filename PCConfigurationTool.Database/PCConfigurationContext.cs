using PCConfigurationTool.Database.Models;
using System.Data.Entity;

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
                .HasMany(pccon => pccon.Components)
                .WithMany(comp => comp.Configurations)
                .Map(concomp =>
                {
                    concomp.MapLeftKey("PCConfigurationRefID");
                    concomp.MapRightKey("PCComponentRefID");
                    concomp.ToTable("PCConfigurationComponent");
                });
        }
    }
}
