using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Database.Models;

namespace PCConfigurationTool.Database.Services.Database
{
    public class PCComponentDatabaseService : IPCComponentDatabaseService
    {
        public void Add(IPCComponent component)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                context.PCComponents.Add(component as PCComponent);
                context.SaveChanges();
            }
        }

        public void Delete(IPCComponent component)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                context.PCComponents.Remove(component as PCComponent);
                context.SaveChanges();
            }
        }
    }
}
