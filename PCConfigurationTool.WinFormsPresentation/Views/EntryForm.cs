using PCConfigurationTool.Core.Interfaces;
using PCConfigurationTool.Core.Interfaces.Views;
using PCConfigurationTool.WinFormsPresentation.Views;
using System;
using System.Windows.Forms;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class EntryForm : FormBase, IEntryView
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
