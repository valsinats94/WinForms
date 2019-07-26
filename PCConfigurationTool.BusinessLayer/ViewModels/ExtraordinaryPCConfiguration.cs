namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class ExtraordinaryPCConfiguration : PCConfigurationDecorator
    {
        #region Initialization

        public ExtraordinaryPCConfiguration(PCConfigurationBaseViewModel pCConfigurationBase, decimal extraOrdinaryCoefficient)
                : base(pCConfigurationBase)
        {
            ExtraOrdinaryCoefficient = extraOrdinaryCoefficient;
        }

        #endregion

        #region Properties

        public decimal ExtraOrdinaryCoefficient { get; set; }

        #endregion

        #region Methods
       
        public override decimal CalculateTotalConfigurationPrice()
        {
            decimal extraPCConfigPrice = base.CalculateTotalConfigurationPrice();
            return extraPCConfigPrice * ExtraOrdinaryCoefficient;
        }

        #endregion
    }
}
