using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Database.Services.Database
{
    public class PCConfigurationDatabaseService : IPCConfigurationDatabaseService
    {
        public void Add(IPCConfiguration configuration)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                context.PCConfigurations.Add(configuration as PCConfiguration);
                context.SaveChanges();
            }
        }

        public void Delete(IPCConfiguration configuration)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                PCConfiguration pCConfigurationToDelete = context.PCConfigurations.FirstOrDefault(c => c.ID == (configuration as PCConfiguration).ID);
                pCConfigurationToDelete.Status = Core.Common.EntityStatus.Deleted;

                context.SaveChanges();
            }
        }
    }
}
