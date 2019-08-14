using PCConfigurationTool.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace PCConfigurationTool.Database
{
    public class PCConfigurationContext : DbContext
    {

        public PCConfigurationContext()
            :base("name=PCConfigurationConnectionString")
        {
        }

        public virtual DbSet<PCComponent> PCComponents { get; set; }

        public virtual DbSet<PCConfiguration> PCConfigurations { get; set; }

        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

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

            builder.Entity<ChangeLog>()
                .HasKey(cl => cl.ID);
        }
        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

        public override int SaveChanges()
        {
            IEnumerable<DbEntityEntry> modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();

            DateTime now = DateTime.Now;

            foreach (DbEntityEntry change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();
                    if (originalValue != currentValue)
                    {
                        ChangeLog log = new ChangeLog()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = prop,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now
                        };

                        ChangeLogs.Add(log);
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
