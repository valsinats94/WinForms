namespace PCConfigurationTool.WinFormsPresentation
{
    partial class ConfigurePCForm
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
            this.cbPCComponents = new System.Windows.Forms.ComboBox();
            this.lsAddedComponents = new System.Windows.Forms.ListView();
            this.lblTotalPriceLabel = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbCoefficient = new System.Windows.Forms.CheckBox();
            this.tbxCoefficient = new System.Windows.Forms.TextBox();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.lblComponentPrice = new System.Windows.Forms.Label();
            this.rtbxDescription = new System.Windows.Forms.RichTextBox();
            this.lblComponentDescription = new System.Windows.Forms.Label();
            this.tbxManufacturer = new System.Windows.Forms.TextBox();
            this.lblComponentManufacturer = new System.Windows.Forms.Label();
            this.picComponentPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picComponentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPCComponents
            // 
            this.cbPCComponents.FormattingEnabled = true;
            this.cbPCComponents.Location = new System.Drawing.Point(13, 36);
            this.cbPCComponents.Name = "cbPCComponents";
            this.cbPCComponents.Size = new System.Drawing.Size(258, 21);
            this.cbPCComponents.TabIndex = 1;
            // 
            // lsAddedComponents
            // 
            this.lsAddedComponents.Location = new System.Drawing.Point(13, 162);
            this.lsAddedComponents.Name = "lsAddedComponents";
            this.lsAddedComponents.Size = new System.Drawing.Size(775, 127);
            this.lsAddedComponents.TabIndex = 2;
            this.lsAddedComponents.UseCompatibleStateImageBehavior = false;
            // 
            // lblTotalPriceLabel
            // 
            this.lblTotalPriceLabel.AutoSize = true;
            this.lblTotalPriceLabel.Location = new System.Drawing.Point(637, 296);
            this.lblTotalPriceLabel.Name = "lblTotalPriceLabel";
            this.lblTotalPriceLabel.Size = new System.Drawing.Size(61, 13);
            this.lblTotalPriceLabel.TabIndex = 3;
            this.lblTotalPriceLabel.Text = "Total Price:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(701, 296);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 13);
            this.lblTotalPrice.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(557, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(231, 76);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(318, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(231, 76);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chbCoefficient
            // 
            this.chbCoefficient.AutoSize = true;
            this.chbCoefficient.Location = new System.Drawing.Point(490, 295);
            this.chbCoefficient.Name = "chbCoefficient";
            this.chbCoefficient.Size = new System.Drawing.Size(76, 17);
            this.chbCoefficient.TabIndex = 7;
            this.chbCoefficient.Text = "Coefficient";
            this.chbCoefficient.UseVisualStyleBackColor = true;
            this.chbCoefficient.CheckedChanged += new System.EventHandler(this.chbCoefficient_CheckedChanged);
            // 
            // tbxCoefficient
            // 
            this.tbxCoefficient.Location = new System.Drawing.Point(585, 293);
            this.tbxCoefficient.Name = "tbxCoefficient";
            this.tbxCoefficient.Size = new System.Drawing.Size(46, 20);
            this.tbxCoefficient.TabIndex = 8;
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(13, 65);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(258, 80);
            this.btnAddComponent.TabIndex = 9;
            this.btnAddComponent.Text = "Add";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(557, 362);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(231, 76);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tbxPrice
            // 
            this.tbxPrice.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbxPrice.Location = new System.Drawing.Point(396, 125);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.ReadOnly = true;
            this.tbxPrice.Size = new System.Drawing.Size(160, 20);
            this.tbxPrice.TabIndex = 20;
            // 
            // lblComponentPrice
            // 
            this.lblComponentPrice.AutoSize = true;
            this.lblComponentPrice.Location = new System.Drawing.Point(396, 99);
            this.lblComponentPrice.Name = "lblComponentPrice";
            this.lblComponentPrice.Size = new System.Drawing.Size(88, 13);
            this.lblComponentPrice.TabIndex = 19;
            this.lblComponentPrice.Text = "Component Price";
            // 
            // rtbxDescription
            // 
            this.rtbxDescription.Location = new System.Drawing.Point(562, 39);
            this.rtbxDescription.Name = "rtbxDescription";
            this.rtbxDescription.ReadOnly = true;
            this.rtbxDescription.Size = new System.Drawing.Size(224, 106);
            this.rtbxDescription.TabIndex = 18;
            this.rtbxDescription.Text = "";
            // 
            // lblComponentDescription
            // 
            this.lblComponentDescription.AutoSize = true;
            this.lblComponentDescription.Location = new System.Drawing.Point(559, 20);
            this.lblComponentDescription.Name = "lblComponentDescription";
            this.lblComponentDescription.Size = new System.Drawing.Size(117, 13);
            this.lblComponentDescription.TabIndex = 17;
            this.lblComponentDescription.Text = "Component Description";
            // 
            // tbxManufacturer
            // 
            this.tbxManufacturer.Location = new System.Drawing.Point(396, 39);
            this.tbxManufacturer.Name = "tbxManufacturer";
            this.tbxManufacturer.ReadOnly = true;
            this.tbxManufacturer.Size = new System.Drawing.Size(160, 20);
            this.tbxManufacturer.TabIndex = 16;
            // 
            // lblComponentManufacturer
            // 
            this.lblComponentManufacturer.AutoSize = true;
            this.lblComponentManufacturer.Location = new System.Drawing.Point(396, 20);
            this.lblComponentManufacturer.Name = "lblComponentManufacturer";
            this.lblComponentManufacturer.Size = new System.Drawing.Size(127, 13);
            this.lblComponentManufacturer.TabIndex = 15;
            this.lblComponentManufacturer.Text = "Component Manufacturer";
            // 
            // picComponentPicture
            // 
            this.picComponentPicture.Location = new System.Drawing.Point(277, 36);
            this.picComponentPicture.Name = "picComponentPicture";
            this.picComponentPicture.Size = new System.Drawing.Size(102, 109);
            this.picComponentPicture.TabIndex = 12;
            this.picComponentPicture.TabStop = false;
            this.picComponentPicture.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Component Name";
            // 
            // ConfigurePCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.lblComponentPrice);
            this.Controls.Add(this.rtbxDescription);
            this.Controls.Add(this.lblComponentDescription);
            this.Controls.Add(this.tbxManufacturer);
            this.Controls.Add(this.lblComponentManufacturer);
            this.Controls.Add(this.picComponentPicture);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnAddComponent);
            this.Controls.Add(this.tbxCoefficient);
            this.Controls.Add(this.chbCoefficient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblTotalPriceLabel);
            this.Controls.Add(this.lsAddedComponents);
            this.Controls.Add(this.cbPCComponents);
            this.Name = "ConfigurePCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigurePCForm";
            ((System.ComponentModel.ISupportInitialize)(this.picComponentPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbPCComponents;
        private System.Windows.Forms.ListView lsAddedComponents;
        private System.Windows.Forms.Label lblTotalPriceLabel;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chbCoefficient;
        private System.Windows.Forms.TextBox tbxCoefficient;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.Label lblComponentPrice;
        private System.Windows.Forms.RichTextBox rtbxDescription;
        private System.Windows.Forms.Label lblComponentDescription;
        private System.Windows.Forms.TextBox tbxManufacturer;
        private System.Windows.Forms.Label lblComponentManufacturer;
        private System.Windows.Forms.PictureBox picComponentPicture;
        private System.Windows.Forms.Label label1;
    }
}