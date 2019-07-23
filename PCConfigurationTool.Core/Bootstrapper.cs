using PCConfigurationTool.Core.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            IContainer container = new SimpleInjectorContainer();

            container.RegisterSingleton<IContainer, SimpleInjectorContainer>();
            container.Verify(VerificationOption.VerifyOnly);
        }
    }
}
