using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PCConfigurationTool.Database.Services.Database
{
    public class PCConfigurationDatabaseService : IPCConfigurationDatabaseService
    {
        #region Declarations

        private IUnityContainer container;

        #endregion

        #region Initialization

        public PCConfigurationDatabaseService(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Methods

        public void Add(IPCConfiguration configuration)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                context.PCConfigurations.Add(configuration as PCConfiguration);
                foreach(PCComponent component in configuration.PCComponents)
                {
                    IPCComponent tmpComponent = container.Resolve<IPCComponentDatabaseService>()
                                                        .GetCurrentPCComponents()
                                                        .FirstOrDefault(c => c.Code.Equals(component.Code, System.StringComparison.OrdinalIgnoreCase));

                    if (tmpComponent != null && context.Entry(component).State == EntityState.Added)
                        context.Entry(component).State = EntityState.Unchanged;
                }
                
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

        public IEnumerable<IPCConfiguration> GetActivePCConfigurations()
        {
            IEnumerable<IPCConfiguration> result;
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                result = context.PCConfigurations.Where(pcc => pcc.Status == Core.Common.EntityStatus.Current);
            }

            return result;
        }

        #endregion
    }
}
