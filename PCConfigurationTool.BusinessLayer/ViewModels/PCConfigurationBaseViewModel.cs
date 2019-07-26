using PCConfigurationTool.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.BusinessLayer.ViewModels
{
    public abstract class PCConfigurationBaseViewModel
    {
        #region Declarations

        private IList<IPCComponent> pcComponents;

        #endregion

        #region Properties

        protected IList<IPCComponent> PCComponents
        {
            get
            {
                if (pcComponents == null)
                    pcComponents = new List<IPCComponent>();

                return pcComponents;
            }
        }

        #endregion

        #region Methods

        public abstract decimal CalculateTotalConfigurationPrice();
        
        #endregion


    }
}
