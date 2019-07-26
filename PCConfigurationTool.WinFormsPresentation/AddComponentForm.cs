using PCConfigurationTool.Core.Interfaces.ViewModels;
using PCConfigurationTool.Core.Interfaces.Views;
using System;
using System.Windows.Forms;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class AddComponentForm : Form, IAddComponentView
    {
        #region Declaration

        IUnityContainer container;
        IAddComponentViewModel addComponentViewModel;

        #endregion

        #region Initialization
        public AddComponentForm(IUnityContainer container)
        {
            this.container = container;
            addComponentViewModel = container.Resolve<IAddComponentViewModel>();
            InitializeComponent();
        }

        #endregion

        #region Properties

        public IAddComponentViewModel AddComponentViewModel
        {
            get
            {                
                return addComponentViewModel;
            }
        }

        #endregion

        #region Methods

        private void txtNumericDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnAddComponent_Click(object sender, System.EventArgs e)
        {
            IAddComponentViewModel addComponentViewModel = container.Resolve<IAddComponentViewModel>();
            addComponentViewModel.Description = rtbxDescription.Text;
            //addComponentViewModel.Image = 
            addComponentViewModel.Manufacturer = tbxManufacturer.Text;
            addComponentViewModel.Name = tbxName.Text;

            // TODO UI валидация за decimal
            decimal componentPrice;
            if (!decimal.TryParse(tbxPrice.Text, out componentPrice))
            {
                MessageBox.Show("Invalid price format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            addComponentViewModel.Price = componentPrice;
            addComponentViewModel.Status = Core.Common.EntityStatus.Current;

            if (addComponentViewModel.Save())
                ClearForm();
        }

        private void ClearForm()
        {
            rtbxDescription.Text = string.Empty;
            tbxManufacturer.Text = string.Empty;
            tbxManufacturer.Text = string.Empty;
            tbxName.Text = string.Empty;
            tbxPrice.Text = string.Empty;
        }

        #endregion
    }
}
