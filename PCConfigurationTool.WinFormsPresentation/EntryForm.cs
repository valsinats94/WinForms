using PCConfigurationTool.Core.Interfaces;
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
    public partial class EntryForm : Form, IEntryView
    {
        #region Declaration

        IUnityContainer container;

        #endregion

        #region Initialization

        public EntryForm(IUnityContainer container)
        {
            this.container = container;

            InitializeComponent();
        }

        #endregion

        #region Methods

        private void btnCreateConfiguration_Click(object sender, EventArgs e)
        {
            ConfigurePCForm configurePCForm = container.Resolve<IConfigurePCView>() as ConfigurePCForm;
            container.Resolve<IFormManager>().ShowModelessForm<ConfigurePCForm>(configurePCForm);
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            AddComponentForm addComponentForm = container.Resolve<IAddComponentView>() as AddComponentForm;
            container.Resolve<IFormManager>().ShowModelessForm<AddComponentForm>(addComponentForm);            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion
    }
}
