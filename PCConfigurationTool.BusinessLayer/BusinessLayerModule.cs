using PCConfigurationTool.Core.Interfaces;
using Unity;

namespace PCConfigurationTool.BusinessLayer
{
    public class BusinessLayerModule : IModule
    {
        public BusinessLayerModule(IUnityContainer container)
        {
            RegisterServices();
        }

        public void RegisterServices()
        {
            
        }
    }
}
