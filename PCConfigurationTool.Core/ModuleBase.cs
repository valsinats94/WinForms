using PCConfigurationTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;

namespace PCConfigurationTool.Core
{
    public abstract class ModuleBase : UnityContainerExtension, IModule
    {
        public abstract void RegisterServices();
    }
}
