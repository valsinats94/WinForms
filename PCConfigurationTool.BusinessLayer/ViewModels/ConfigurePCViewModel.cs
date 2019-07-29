using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class ConfigurePCViewModel : IConfigurePCViewModel
    {
        #region Declaration

        private IUnityContainer container;

        private ICollection<IPCComponent> pCComponents;
        private IPCComponent selectedComponent;
        private ICollection<IPCComponent> chosenPCComponents;

        #endregion

        #region Initialization

        public ConfigurePCViewModel(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Properties

        public ICollection<IPCComponent> PCComponents
        {
            get
            {
                if (pCComponents == null)
                {
                    pCComponents = InitializeComponents();
                }

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

        private ICollection<IPCComponent> InitializeComponents()
        {
            List<IPCComponent> result = new List<IPCComponent>();
            foreach (IPCComponent component in container.Resolve<IPCComponentDatabaseService>().GetCurrentPCComponents())
            {
                result.Add(component);
            }

            return result;
        }

        public void AddComponentToConfiguration(IPCComponent pCComponent)
        {
            if (pCComponent == null)
                return;

            ChosenPCComponents.Add(pCComponent);
        }

        public bool ApplyChanges()
        {
            PCConfigurationBaseViewModel pCConfigurationViewModel = new PCConfigurationViewModel();
            pCConfigurationViewModel.PCComponents = ChosenPCComponents.ToList();

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

            IPCConfigurationDatabaseService dbService = container.Resolve<IPCConfigurationDatabaseService>();

            IPCConfiguration pcConfiguration = container.Resolve<IPCConfiguration>();
            AddComponents(dbService, pcConfiguration);
            pcConfiguration.TotalPrice = TotalPrice;
            pcConfiguration.ConfigurationType = ConfigurationType;
            pcConfiguration.Status = Status;

            container.Resolve<IPCConfigurationDatabaseService>().Add(pcConfiguration);

            return true;
        }

        private void AddComponents(IPCConfigurationDatabaseService dbService, IPCConfiguration pcConfiguration)
        {
            foreach (IPCComponent component in ChosenPCComponents)
            {
                IPCComponent tmpComponent = container.Resolve<IPCComponentDatabaseService>()
                                                                            .GetCurrentPCComponents()
                                                                            .FirstOrDefault(c => c.Code.Equals(component.Code, System.StringComparison.OrdinalIgnoreCase));
                pcConfiguration.PCComponents.Add(tmpComponent);
            }
        }

        #endregion
    }
}
