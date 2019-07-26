using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public class PCConfigurationViewModel : PCConfigurationBaseViewModel
    {
        #region Methods

        public override decimal CalculateTotalConfigurationPrice()
        {
            return PCComponents.Sum(c => c.Price);
        }

        #endregion
    }
}
