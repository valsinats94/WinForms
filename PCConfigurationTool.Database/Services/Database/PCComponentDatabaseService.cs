﻿using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace PCConfigurationTool.Database.Services.Database
{
    public class PCComponentDatabaseService : IPCComponentDatabaseService
    {
        #region Methods

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
                PCComponent pCComponentToDelete = context.PCComponents.FirstOrDefault(c => c.ID == (component as PCComponent).ID);
                pCComponentToDelete.Status = Core.Common.EntityStatus.Deleted;

                context.SaveChanges();
            }
        }

        public IEnumerable<IPCComponent> GetCurrentPCComponents()
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                var components = context.PCComponents.Where(c => c.Status == Core.Common.EntityStatus.Current);

                return components.ToList();
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

        public bool CheckForExistingCode(string code)
        {
            using (PCConfigurationContext context = new PCConfigurationContext())
            {
                return context.PCComponents.Any(pc => pc.Code.Equals(code, System.StringComparison.OrdinalIgnoreCase));
            }
        }

        #endregion
    }
}
