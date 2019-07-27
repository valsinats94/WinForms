using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Database.Models;
using System.Linq;

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

        public byte[] GetImageByComponent(IPCComponent component)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                PCComponent pCComponent = component as PCComponent;
                PCComponent resultComponent = context.PCComponents.FirstOrDefault(c => c.ID == pCComponent.ID);

                return resultComponent?.Image;
            }
        }
    }
}
