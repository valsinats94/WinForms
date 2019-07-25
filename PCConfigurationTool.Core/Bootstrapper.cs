using PCConfigurationTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PCConfigurationTool.Core
{
    public class Bootstrapper
    {
        private IUnityContainer container;

        [Export]
        public CompositionContainer CompositionContainer { get; private set; }

        public Bootstrapper(IUnityContainer container)
        {
            this.container = container;

            //container.RegisterSingleton<IContainer, SimpleInjectorContainer>();

            InitializeModules();
            InitializeTools();
        }

        private void InitializeTools()
        {
            DependancyInjector.Register<IFormManager, FormManager>();
            //DependancyInjector.AddExtension<ModuleBase>();
            //container.RegisterSingleton<IFormManager, FormManager>();
        }

        private void InitializeModules()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            CompositionContainer = new CompositionContainer(catalog);
            CompositionContainer.ComposeParts(this);

            var a = CompositionContainer.GetExportedValues<IModule>();

            //Type type = typeof(IModule);
            //IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            //                                            .SelectMany(s => s.GetTypes())
            //                                            .Where(p => type.IsAssignableFrom(p));
            //var a = AppDomain.CurrentDomain.GetAssemblies();
            //var b = AppDomain.CurrentDomain.GetAssemblies()
            //                                            .SelectMany(s => s.GetTypes()
            //                                            .Where(p => p.BaseType == type));
        }
    }
}
