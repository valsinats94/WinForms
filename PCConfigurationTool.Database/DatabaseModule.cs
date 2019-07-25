using PCConfigurationTool.Core;
using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Database.Services.Database;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PCConfigurationTool.Database
{
    [Export(typeof(IModule))]
    public class DatabaseModule : ModuleBase
    {
        IUnityContainer container;

        public DatabaseModule(IUnityContainer container)
        {
            this.container = container;
            RegisterServices();
        }

        public override void RegisterServices()
        {
            DependancyInjector.Register<IDatabaseService, DatabaseService>();
        }

        protected override void Initialize()
        {
            RegisterServices();
        }
    }
}
