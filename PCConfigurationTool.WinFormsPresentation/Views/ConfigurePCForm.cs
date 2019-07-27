using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using PCConfigurationTool.Core.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class ConfigurePCForm : Form, IConfigurePCView
    {
        #region Declaration

        private IUnityContainer container;
        private IConfigurePCViewModel configurePCViewModel;
        private ICollection<IPCComponent> pCComponents;

        #endregion

        #region Initialization

        public ConfigurePCForm(IUnityContainer container)
        {
            this.container = container;
            configurePCViewModel = container.Resolve<IConfigurePCViewModel>();
            InitializeComponent();
        }

        #endregion

        #region Properties

        private IConfigurePCViewModel ConfigurePCViewModel
        {
            get
            {
                return configurePCViewModel;
            }
        }

        public ICollection<IPCComponent> PCComponents
        {
            get
            {
                return ConfigurePCViewModel.PCComponents;
            }
        }

        #endregion

        #region Methods



        #endregion
    }
}
