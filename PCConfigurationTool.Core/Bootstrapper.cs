using PCConfigurationTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PCConfigurationTool.Core
{
    public class Bootstrapper
    {
        private IUnityContainer container;

        public Bootstrapper(IUnityContainer container)
        {
            this.container = container;

            //container.RegisterSingleton<IContainer, SimpleInjectorContainer>();

            InitializeModules();
            InitializeTools();
        }

        private void InitializeTools()
        {
            container.RegisterSingleton<IFormManager, FormManager>();
        }

        private void InitializeModules()
        {
            Type type = typeof(IModule);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                                                        .SelectMany(s => s.GetTypes())
                                                        .Where(p => type.IsAssignableFrom(p));
            var a = AppDomain.CurrentDomain.GetAssemblies();
            var b = AppDomain.CurrentDomain.GetAssemblies()
                                                        .SelectMany(s => s.GetTypes()
                                                        .Where(p => p.BaseType == type));
        }
    }
}
