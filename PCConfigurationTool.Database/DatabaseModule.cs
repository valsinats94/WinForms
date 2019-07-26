using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Database.Models;
using PCConfigurationTool.Database.Services.Database;
using System.Composition;
using Unity;

namespace PCConfigurationTool.Database
{
    [Export(typeof(IModule))]
    public class DatabaseModule : IModule
    {
        IUnityContainer container;

        public DatabaseModule(IUnityContainer container)
        {
            this.container = container;
            RegisterServices();
            RegisterModels();
        }

        public void RegisterServices()
        {
            container.RegisterType<IDatabaseService, DatabaseService>();
        }

        private void RegisterModels()
        {
            container.RegisterType<IPCComponent, PCComponent>();
        }
    }
}
