using System.Windows.Forms;

namespace PCConfigurationTool.WinFormsPresentation
{
    partial class AddComponentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.ltvComponents = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picComponentPicture = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblComponentManufacturer = new System.Windows.Forms.Label();
            this.tbxManufacturer = new System.Windows.Forms.TextBox();
            this.lblComponentDescription = new System.Windows.Forms.Label();
            this.rtbxDescription = new System.Windows.Forms.RichTextBox();
            this.lblComponentPrice = new System.Windows.Forms.Label();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picComponentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.AccessibleName = " btnAddComponent";
            this.btnAddComponent.AutoSize = true;
            this.btnAddComponent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddComponent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddComponent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddComponent.Location = new System.Drawing.Point(603, 394);
            this.btnAddComponent.Margin = new System.Windows.Forms.Padding(10);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(182, 53);
            this.btnAddComponent.TabIndex = 0;
            this.btnAddComponent.Text = "Add Component";
            this.btnAddComponent.UseVisualStyleBackColor = false;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // ltvComponents
            // 
            this.ltvComponents.Location = new System.Drawing.Point(39, 15);
            this.ltvComponents.Margin = new System.Windows.Forms.Padding(10);
            this.ltvComponents.MinimumSize = new System.Drawing.Size(200, 100);
            this.ltvComponents.Name = "ltvComponents";
            this.ltvComponents.Size = new System.Drawing.Size(714, 219);
            this.ltvComponents.TabIndex = 1;
            this.ltvComponents.UseCompatibleStateImageBehavior = false;
            this.ltvComponents.View = System.Windows.Forms.View.Details;
            this.ltvComponents.SelectedIndexChanged += new System.EventHandler(this.ltvComponents_SelectedIndexChanged);
            // 
            // Name
            // 
            this.Name.Text = "AddComponentForm";
            // 
            // Manufacturer
            // 
            this.Manufacturer.DisplayIndex = 3;
            // 
            // Price
            // 
            this.Price.DisplayIndex = 2;
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // picComponentPicture
            // 
            this.picComponentPicture.Location = new System.Drawing.Point(39, 272);
            this.picComponentPicture.Name = "picComponentPicture";
            this.picComponentPicture.Size = new System.Drawing.Size(100, 85);
            this.picComponentPicture.TabIndex = 2;
            this.picComponentPicture.TabStop = false;
            this.picComponentPicture.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(178, 272);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Component Name";
            // 
            // tbxName
            // 
            this.tbxName.AccessibleName = "tbxName";
            this.tbxName.Location = new System.Drawing.Point(311, 272);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(160, 20);
            this.tbxName.TabIndex = 4;
            // 
            // lblComponentManufacturer
            // 
            this.lblComponentManufacturer.AutoSize = true;
            this.lblComponentManufacturer.Location = new System.Drawing.Point(178, 312);
            this.lblComponentManufacturer.Name = "lblComponentManufacturer";
            this.lblComponentManufacturer.Size = new System.Drawing.Size(127, 13);
            this.lblComponentManufacturer.TabIndex = 5;
            this.lblComponentManufacturer.Text = "Component Manufacturer";
            // 
            // tbxManufacturer
            // 
            this.tbxManufacturer.Location = new System.Drawing.Point(311, 305);
            this.tbxManufacturer.Name = "tbxManufacturer";
            this.tbxManufacturer.Size = new System.Drawing.Size(160, 20);
            this.tbxManufacturer.TabIndex = 6;
            // 
            // lblComponentDescription
            // 
            this.lblComponentDescription.AutoSize = true;
            this.lblComponentDescription.Location = new System.Drawing.Point(506, 272);
            this.lblComponentDescription.Name = "lblComponentDescription";
            this.lblComponentDescription.Size = new System.Drawing.Size(117, 13);
            this.lblComponentDescription.TabIndex = 7;
            this.lblComponentDescription.Text = "Component Description";
            // 
            // rtbxDescription
            // 
            this.rtbxDescription.Location = new System.Drawing.Point(509, 289);
            this.rtbxDescription.Name = "rtbxDescription";
            this.rtbxDescription.Size = new System.Drawing.Size(244, 68);
            this.rtbxDescription.TabIndex = 8;
            this.rtbxDescription.Text = "";
            // 
            // lblComponentPrice
            // 
            this.lblComponentPrice.AutoSize = true;
            this.lblComponentPrice.Location = new System.Drawing.Point(178, 344);
            this.lblComponentPrice.Name = "lblComponentPrice";
            this.lblComponentPrice.Size = new System.Drawing.Size(88, 13);
            this.lblComponentPrice.TabIndex = 9;
            this.lblComponentPrice.Text = "Component Price";
            // 
            // tbxPrice
            // 
            this.tbxPrice.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbxPrice.Location = new System.Drawing.Point(311, 336);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(160, 20);
            this.tbxPrice.TabIndex = 10;
            this.tbxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumericDecimal_KeyPress);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(39, 272);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(100, 85);
            this.btnAddPicture.TabIndex = 11;
            this.btnAddPicture.Text = "Add Component Image";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // AddComponentForm
            // 
            this.AccessibleName = "ltvExistingComponents";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.lblComponentPrice);
            this.Controls.Add(this.rtbxDescription);
            this.Controls.Add(this.lblComponentDescription);
            this.Controls.Add(this.tbxManufacturer);
            this.Controls.Add(this.lblComponentManufacturer);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picComponentPicture);
            this.Controls.Add(this.ltvComponents);
            this.Controls.Add(this.btnAddComponent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(810, 500);
            this.Name = "AddComponentForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddComponentForm";
            ((System.ComponentModel.ISupportInitialize)(this.picComponentPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.ListView ltvComponents;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Manufacturer;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.PictureBox picComponentPicture;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblComponentManufacturer;
        private System.Windows.Forms.TextBox tbxManufacturer;
        private System.Windows.Forms.Label lblComponentDescription;
        private System.Windows.Forms.RichTextBox rtbxDescription;
        private System.Windows.Forms.Label lblComponentPrice;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.Button btnAddPicture;
    }
}