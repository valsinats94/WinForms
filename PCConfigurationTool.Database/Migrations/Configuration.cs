namespace PCConfigurationTool.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PCConfigurationTool.Database.PCConfigurationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PCConfigurationTool.Database.PCConfigurationContext context)
        {
            context.PCComponents.AddOrUpdate(
                new Models.PCComponent
                {
                    Name = "Intel Pentium 4",
                    Code = "1",
                    Description = "Processor One Core",
                    Manufacturer = "Intel",
                    Price = 20.43m,
                    Status = Core.Common.EntityStatus.Current
                },

                new Models.PCComponent
                {
                    Name = "Intel i7",
                    Code = "2",
                    Description = "Four Physical Cores",
                    Manufacturer = "Intel",
                    Price = 220.99m,
                    Status = Core.Common.EntityStatus.Current
                },

                new Models.PCComponent
                {
                    Name = "Kingston SSD",
                    Code = "3",
                    Description = "Storage 256GB",
                    Manufacturer = "Kingston",
                    Price = 126.25m,
                    Status = Core.Common.EntityStatus.Current
                },

                new Models.PCComponent
                {
                    Name = "NVidia Jetson Nano",
                    Code = "4",
                    Description = "NVIDIA CUDA X",
                    Manufacturer = "NVIDIA",
                    Price = 132.78m,
                    Status = Core.Common.EntityStatus.Current
                },

                new Models.PCComponent
                {
                    Name = "Dominator Platinum",
                    Code = "5",
                    Description = "32GB (4 x 8GB) DDR4 DRAM 3600MHz C18",
                    Manufacturer = "Corsair",
                    Price = 249.99m,
                    Status = Core.Common.EntityStatus.Current
                });
        }
    }
}
