using System;
using PCConfigurationTool.BusinessLayer.ViewModels;
using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using Unity;

namespace PCConfigurationTool.BusinessLayer
{
    public class BusinessLayerModule : IModule
    {
        IUnityContainer container;

        public BusinessLayerModule(IUnityContainer container)
        {
            this.container = container;

            RegisterServices();
            RegisterViewModels();
        }

        private void RegisterViewModels()
        {
            container.RegisterType<IAddComponentViewModel, AddComponentViewModel>();
        }

        public void RegisterServices()
        {
            
        }
    }
}
