using PCConfigurationTool.Core.Interfaces.ViewModels;
using Unity;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class AddComponentViewModel : IAddComponentViewModel
    {
        IUnityContainer container;

        public AddComponentViewModel(IUnityContainer container)
        {
            this.container = container;
        }
    }
}
