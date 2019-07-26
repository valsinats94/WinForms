using System;
using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.Views;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public class WinFormsPresentationModule : IModule
    {
        IUnityContainer container;

        public WinFormsPresentationModule(IUnityContainer container)
        {
            this.container = container;

            RegisterServices();
            RegisterMenuItems();
        }

        private void RegisterMenuItems()
        {
            container.RegisterType<IAddComponentView, AddComponentForm>();
        }

        public void RegisterServices()
        {
            
        }
    }
}
