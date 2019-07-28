using PCConfigurationTool.Core.Interfaces.ViewModels;
using PCConfigurationTool.Core.Interfaces.Views;
using PCConfigurationTool.WinFormsPresentation.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using Unity;
using ImageConverter = PCConfigurationTool.Core.Common.Helpers.ImageConverter;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class AddComponentForm : FormBase, IAddComponentView
    {
        #region Declaration

        private IUnityContainer container;

        #endregion

        #region Initialization
        public AddComponentForm(IUnityContainer container)
        {
            this.container = container;
            InitializeComponent();
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region Events

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

        private void btnAddComponent_Click(object sender, System.EventArgs e)
        {
            IAddComponentViewModel addComponentViewModel = container.Resolve<IAddComponentViewModel>();
            addComponentViewModel.Description = rtbxDescription.Text;
            addComponentViewModel.Image = ImageConverter.CopyImageToByteArray(picComponentPicture.Image);
            addComponentViewModel.Manufacturer = tbxManufacturer.Text;
            addComponentViewModel.Name = tbxName.Text;
            addComponentViewModel.Code = tbxCode.Text;

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
                                          new[] { addComponentViewModel.Name
                                                , addComponentViewModel.Description
                                                , addComponentViewModel.Manufacturer
                                                , addComponentViewModel.Price.ToString()})
                               { Tag = addComponentViewModel });
                ClearForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ltvComponents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumericDecimal_KeyPress(sender, e);
        }

        #endregion       

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
    }
}
