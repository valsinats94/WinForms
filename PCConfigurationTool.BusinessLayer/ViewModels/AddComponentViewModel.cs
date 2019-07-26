using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using System.Collections.Generic;
using Unity;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class AddComponentViewModel : IAddComponentViewModel
    {
        #region Declarations

        IUnityContainer container;

        #endregion

        #region Initialization

        public AddComponentViewModel(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public EntityStatus Status { get; set; }

        public byte[] Image { get; set; }

        #endregion

        #region Methods

        public IList<ValidationResult> Validate()
        {
            return new List<ValidationResult>();
        }

        public bool Save()
        {
            if (Validate().Count > 0)
            {
                return false;
            }

            IPCComponent pCComponent = container.Resolve<IPCComponent>();
            pCComponent.Description = Description;
            pCComponent.Manufacturer = Manufacturer;
            pCComponent.Name = Name;
            pCComponent.Price = Price;
            pCComponent.Status = Status;

            //container.Resolve<IDatabaseService>().Save();

            return true;
        }

        #endregion
    }
}
