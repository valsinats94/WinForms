using PCConfigurationTool.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces.Services
{
    public interface IPCConfigurationDatabaseService
    {
        void Add(IPCConfiguration configuration);

        void Delete(IPCConfiguration configuration);

        IEnumerable<IPCConfiguration> GetActivePCConfigurations();
    }
}
