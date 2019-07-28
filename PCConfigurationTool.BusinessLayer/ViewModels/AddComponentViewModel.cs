using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.Services;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using Unity;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class AddComponentViewModel : IAddComponentViewModel
    {
        #region Declarations

        private IUnityContainer container;

        private string code;

        #endregion

        #region Initialization

        public AddComponentViewModel(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                if (value == code)
                    return;

                if (CodeExistsValidation(value) != ValidationResult.NoError)
                    return;

                code = value;
            }
        }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public EntityStatus Status { get; set; }

        public byte[] Image { get; set; }

        #endregion

        #region Methods

        private ValidationResult CodeExistsValidation(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new ValidationResult(ErrorLevel.Critical, "Code is mandatory to be entered!");

            if (container.Resolve<IPCComponentDatabaseService>().CheckForExistingCode(value))
                return new ValidationResult(ErrorLevel.Critical, "Already exists component with entered code");

            return ValidationResult.NoError;
        }

        public IList<ValidationResult> Validate()
        {
            IList<ValidationResult> result = new List<ValidationResult>();

            ValidationResult validationResult = CodeExistsValidation(Code);
            if (validationResult != ValidationResult.NoError)
                result.Add(validationResult);
            
            return new List<ValidationResult>();
        }

        public bool Save()
        {
            IList<ValidationResult> validations = Validate();
            if (validations.Count > 0)
            {
                return false;
            }

            IPCComponent pCComponent = container.Resolve<IPCComponent>();
            pCComponent.Description = Description;
            pCComponent.Manufacturer = Manufacturer;
            pCComponent.Name = Name;
            pCComponent.Code = Code;
            pCComponent.Price = Price;
            pCComponent.Image = Image;
            pCComponent.Status = Status;

            container.Resolve<IPCComponentDatabaseService>().Add(pCComponent);

            return true;
        }

        #endregion
    }
}
