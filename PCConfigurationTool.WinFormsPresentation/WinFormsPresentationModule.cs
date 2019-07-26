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
            container.RegisterType<IEntryView, EntryForm>();
            container.RegisterType<IAddComponentView, AddComponentForm>();
            container.RegisterType<IConfigurePCView, ConfigurePCForm>();
        }

        public void RegisterServices()
        {
            
        }
    }
}
