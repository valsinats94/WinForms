﻿using PCConfigurationTool.Core.Common;
using PCConfigurationTool.Core.Interfaces.Models;
using PCConfigurationTool.Core.Interfaces.ViewModels;
using PCConfigurationTool.Core.Interfaces.Views;
using PCConfigurationTool.WinFormsPresentation.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace PCConfigurationTool.WinFormsPresentation
{
    public partial class ConfigurePCForm : FormBase, IConfigurePCView
    {
        #region Declaration

        private IUnityContainer container;
        private IConfigurePCViewModel configurePCViewModel;

        #endregion

        #region Initialization

        public ConfigurePCForm(IUnityContainer container)
        {
            this.container = container;
            configurePCViewModel = container.Resolve<IConfigurePCViewModel>();
            InitializeComponent();

            InitializaDefaultState();
            InitializaDefaultData();
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

        private void InitializaDefaultData()
        {
            InitializeComponentsToChooseForm();
        }

        private void InitializaDefaultState()
        {
            btnApply.IsAccessible = true;
            btnApply.Enabled = true;
            btnApply.Visible = true;

            btnSave.IsAccessible = false;
            btnSave.Enabled = false;
            btnSave.Visible = false;

            btnAddComponent.Enabled = false;
            tbxCoefficient.Enabled = false;
        }

        private void InitializeComponentsToChooseForm()
        {
            cbPCComponents.DataSource = PCComponents;
            cbPCComponents.DisplayMember = "Name";
            cbPCComponents.SelectedValueChanged += SelectedComponentChangedEvent;
        }

        private void SelectedComponentChangedEvent(object sender, EventArgs e)
        {
            configurePCViewModel.SelectedComponent = cbPCComponents.SelectedValue as IPCComponent;

            if (configurePCViewModel.SelectedComponent != null)
            {
                btnAddComponent.Enabled = true;
                ShowPCComponentDataOnView(configurePCViewModel.SelectedComponent);
            }            
        }

        private void ShowPCComponentDataOnView(IPCComponent selectedComponent)
        {
            if (selectedComponent.Image != null)
            {
                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(Core.Common.Helpers.ImageConverter.GetImageFromByteArray(selectedComponent.Image));
                Image myThumbnail = myBitmap.GetThumbnailImage(102, 109, myCallback, IntPtr.Zero);
                picComponentPicture.Image = myThumbnail;
            }

            tbxManufacturer.Text = selectedComponent.Manufacturer;
            tbxPrice.Text = selectedComponent.Price.ToString();
            rtbxDescription.Text = selectedComponent.Description;
        }

        #endregion

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            if (cbPCComponents.SelectedItem == null || configurePCViewModel.SelectedComponent == null)
                return;               

            configurePCViewModel.AddComponentToConfiguration(configurePCViewModel.SelectedComponent);
        }

        private void chbCoefficient_CheckedChanged(object sender, EventArgs e)
        {            
            tbxCoefficient.Enabled = chbCoefficient.Checked;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (chbCoefficient.Checked)
            {
                configurePCViewModel.ConfigurationType |= ConfigurationType.ExtraOrdinary;
                if (!decimal.TryParse(tbxCoefficient.Text, out decimal tmpCoefficient))
                {
                    MessageBox.Show("Invalid coefficient format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                configurePCViewModel.Coefficient = tmpCoefficient;
            }

            if (!configurePCViewModel.ApplyChanges())
                return;

            btnApply.IsAccessible = false;
            btnApply.Enabled = false;
            btnApply.Visible = false;

            btnSave.IsAccessible = false;
            btnSave.Enabled = true;
            btnSave.Visible = true;

            lblTotalPrice.Text = configurePCViewModel.TotalPrice.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configurePCViewModel.Save();
        }
    }
}
