using PCConfigurationTool.Core.Interfaces;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public class WinFormsPresentationModule : IModule
    {
        public WinFormsPresentationModule(IUnityContainer container)
        {
            RegisterServices();
        }

        public void RegisterServices()
        {
            
        }
    }
}
