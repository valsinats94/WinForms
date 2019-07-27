using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using System.Collections.Generic;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class ConfigurePCViewModel : IConfigurePCViewModel
    {
        #region Declaration
        
        private ICollection<IPCComponent> pCComponents;
        private IPCComponent selectedComponent;
        private ICollection<IPCComponent> chosenPCComponents;

        #endregion

        #region Initialization

        #endregion

        #region Properties

        public ICollection<IPCComponent> PCComponents
        {
            get
            {
                if (pCComponents == null)
                    pCComponents = new List<IPCComponent>();

                return pCComponents;
            }
        }

        public ICollection<IPCComponent> ChosenPCComponents
        {
            get
            {
                if (chosenPCComponents == null)
                    chosenPCComponents = new List<IPCComponent>();

                return chosenPCComponents;
            }
        }

        public IPCComponent SelectedComponent
        {
            get
            {
                return selectedComponent;
            }
            set
            {
                if (value == selectedComponent)
                    return;

                selectedComponent = value;
            }
        }

        public EntityStatus Status { get; set; }

        public ConfigurationType ConfigurationType { get; set; }

        public decimal? Coefficient { get; set; }

        public decimal TotalPrice { get; set; }
        
        #endregion

        #region Methods

        public void AddComponentToConfiguration(IPCComponent pCComponent)
        {
            if (pCComponent == null)
                return;

            ChosenPCComponents.Add(pCComponent);
        }

        public bool ApplyChanges()
        {
            PCConfigurationBaseViewModel pCConfigurationViewModel = new PCConfigurationViewModel();
            
            if ((ConfigurationType & ConfigurationType.ExtraOrdinary) == ConfigurationType.ExtraOrdinary)
            {
                pCConfigurationViewModel = new ExtraordinaryPCConfiguration(pCConfigurationViewModel, Coefficient ?? 0);
            }

            TotalPrice = pCConfigurationViewModel.CalculateTotalConfigurationPrice();

            return true;
        }

        public IList<ValidationResult> Validate()
        {
            return new List<ValidationResult>();
        }

        public bool Save()
        {
            if (!ApplyChanges())
                return false;

            if (Validate().Count > 0)
                return false;

            return true;
        }

        #endregion
    }
}
