namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class PCConfigurationDecorator : PCConfigurationBaseViewModel
    {
        #region Declarations

        private PCConfigurationBaseViewModel pCConfigurationBase;

        #endregion

        #region Initalization

        public PCConfigurationDecorator(PCConfigurationBaseViewModel pCConfigurationBase)
        {
            this.pCConfigurationBase = pCConfigurationBase;
        }

        #endregion

        #region Methods

        public override decimal CalculateTotalConfigurationPrice()
        {
            return pCConfigurationBase.CalculateTotalConfigurationPrice();
        }

        #endregion
    }
}
