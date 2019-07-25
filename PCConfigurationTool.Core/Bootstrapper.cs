using PCConfigurationTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Unity;

namespace PCConfigurationTool.Core
{
    public class Bootstrapper
    {
        #region Declarations

        private const string SEARCHPATTERN = "PCConfigurationTool*.dll";

        private IUnityContainer container;

        #endregion

        #region Initialization
        
        public Bootstrapper(IUnityContainer container)
        {
            this.container = container;
            
            InitializeModules();
            InitializeTools();
        }

        #endregion

        #region Properties
                
        [ImportMany]
        public List<IModule> Modules { get; set; }

        public CompositionContainer CompositionContainer { get; private set; }

        #endregion

        #region Methods
        
        private void InitializeTools()
        {
            container.RegisterType<IFormManager, FormManager>();
        }

        private void InitializeModules()
        {
            var modulestmp = Modules;
            var catalog = new AggregateCatalog();
            
            catalog.Catalogs.Add(new DirectoryCatalog(@".\", SEARCHPATTERN));

            foreach (DirectoryCatalog catalogItem in catalog.Catalogs.ToList())
            {
                foreach (var loadedFile in catalogItem.LoadedFiles)
                {
                    RegisterComponents(Assembly.LoadFrom(loadedFile));
                }

            }
            
            //////TODO
            //////Search for PlugIns - approx same approach can be used
            //CompositionContainer = new CompositionContainer(catalog);
            //CompositionContainer.ComposeParts(this);

            //Type type = typeof(IModule);
            //IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            //                                            .SelectMany(s => s.GetTypes())
            //                                            .Where(p => type.IsAssignableFrom(p));
            //var a = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes());
            //var b = AppDomain.CurrentDomain.GetAssemblies()
            //                                            .SelectMany(s => s.GetTypes()
            //                                            .Where(p => p.BaseType == type));
        }

        private void RegisterComponents(Assembly assembly)
        {
            Type type = typeof(IModule);

            IEnumerable<Type> modules = assembly.GetTypes().Where(p => type.IsAssignableFrom(p));

            if (modules.Count() > 1)
                throw new Exception($"You have more than one module class defined in {assembly.FullName}");

            if (modules.Count() == 1 && !(modules.FirstOrDefault().IsInterface || modules.FirstOrDefault().IsAbstract))
                Activator.CreateInstance(modules.FirstOrDefault(), container);
        }

        #endregion
    }
}
