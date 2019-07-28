using PCConfigurationTool.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces.Services
{
    public interface IPCComponentDatabaseService
    {
        void Add(IPCComponent component);

        void Delete(IPCComponent component);

        IEnumerable<IPCComponent> GetCurrentPCComponents();

        bool CheckForExistingCode(string code);
    }
}
