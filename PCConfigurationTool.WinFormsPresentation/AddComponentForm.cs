using PCConfigurationTool.Core.Interfaces.ViewModels;
using PCConfigurationTool.Core.Interfaces.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using Unity;
using PCConfigurationTool.Core.Common.Helpers;
using ImageConverter = PCConfigurationTool.Core.Common.Helpers.ImageConverter;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class AddComponentForm : Form, IAddComponentView
    {
        #region Declaration

        private IUnityContainer container;
        private IAddComponentViewModel addComponentViewModel;

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

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Browse Component Images";
            fileDialog.DefaultExt = "img";
            fileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*";
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            DialogResult dr = fileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                btnAddPicture.Visible = false;
                picComponentPicture.Visible = true;

                try
                {
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    Bitmap myBitmap = new Bitmap(fileDialog.FileName);
                    Image myThumbnail = myBitmap.GetThumbnailImage(100, 85, myCallback, IntPtr.Zero);
                    picComponentPicture.Image = myThumbnail;
                }
                catch
                {
                    btnAddPicture.Visible = true;
                    picComponentPicture.Visible = false;
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void btnAddComponent_Click(object sender, System.EventArgs e)
        {
            IAddComponentViewModel addComponentViewModel = container.Resolve<IAddComponentViewModel>();
            addComponentViewModel.Description = rtbxDescription.Text;
            addComponentViewModel.Image = ImageConverter.CopyImageToByteArray(picComponentPicture.Image);
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
            {
                ltvComponents.Items.Add(
                               new ListViewItem(
                                   new string[] { addComponentViewModel.Name
                                                , addComponentViewModel.Description
                                                , addComponentViewModel.Manufacturer
                                                , addComponentViewModel.Price.ToString()}));
                ClearForm();
            }
        }

        private void ClearForm()
        {
            rtbxDescription.Text = string.Empty;
            tbxManufacturer.Text = string.Empty;
            tbxManufacturer.Text = string.Empty;
            tbxName.Text = string.Empty;
            tbxPrice.Text = string.Empty;
        }

        private void SetPCComponentElements()
        {
            rtbxDescription.Text = string.Empty;
            tbxManufacturer.Text = string.Empty;
            tbxManufacturer.Text = string.Empty;
            tbxName.Text = string.Empty;
            tbxPrice.Text = string.Empty;
        }

        #endregion

        private void ltvComponents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
