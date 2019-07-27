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
            this.lsAvailableComponents = new System.Windows.Forms.ListView();
            this.cbPCComponents = new System.Windows.Forms.ComboBox();
            this.lsAddedComponents = new System.Windows.Forms.ListView();
            this.lblTotalPriceLabel = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbCoefficient = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsAvailableComponents
            // 
            this.lsAvailableComponents.Location = new System.Drawing.Point(12, 12);
            this.lsAvailableComponents.Name = "lsAvailableComponents";
            this.lsAvailableComponents.Size = new System.Drawing.Size(775, 125);
            this.lsAvailableComponents.TabIndex = 0;
            this.lsAvailableComponents.UseCompatibleStateImageBehavior = false;
            // 
            // cbPCComponents
            // 
            this.cbPCComponents.FormattingEnabled = true;
            this.cbPCComponents.Location = new System.Drawing.Point(12, 159);
            this.cbPCComponents.Name = "cbPCComponents";
            this.cbPCComponents.Size = new System.Drawing.Size(211, 21);
            this.cbPCComponents.TabIndex = 1;
            // 
            // lsAddedComponents
            // 
            this.lsAddedComponents.Location = new System.Drawing.Point(13, 199);
            this.lsAddedComponents.Name = "lsAddedComponents";
            this.lsAddedComponents.Size = new System.Drawing.Size(775, 125);
            this.lsAddedComponents.TabIndex = 2;
            this.lsAddedComponents.UseCompatibleStateImageBehavior = false;
            // 
            // lblTotalPriceLabel
            // 
            this.lblTotalPriceLabel.AutoSize = true;
            this.lblTotalPriceLabel.Location = new System.Drawing.Point(649, 341);
            this.lblTotalPriceLabel.Name = "lblTotalPriceLabel";
            this.lblTotalPriceLabel.Size = new System.Drawing.Size(58, 13);
            this.lblTotalPriceLabel.TabIndex = 3;
            this.lblTotalPriceLabel.Text = "Total Price";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(713, 341);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 13);
            this.lblTotalPrice.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(610, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 57);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(430, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(174, 57);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chbCoefficient
            // 
            this.chbCoefficient.AutoSize = true;
            this.chbCoefficient.Location = new System.Drawing.Point(502, 340);
            this.chbCoefficient.Name = "chbCoefficient";
            this.chbCoefficient.Size = new System.Drawing.Size(76, 17);
            this.chbCoefficient.TabIndex = 7;
            this.chbCoefficient.Text = "Coefficient";
            this.chbCoefficient.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 338);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 8;
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(229, 159);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(41, 21);
            this.btnAddComponent.TabIndex = 9;
            this.btnAddComponent.Text = "Add";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            // 
            // ConfigurePCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddComponent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chbCoefficient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblTotalPriceLabel);
            this.Controls.Add(this.lsAddedComponents);
            this.Controls.Add(this.cbPCComponents);
            this.Controls.Add(this.lsAvailableComponents);
            this.Name = "ConfigurePCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigurePCForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsAvailableComponents;
        private System.Windows.Forms.ComboBox cbPCComponents;
        private System.Windows.Forms.ListView lsAddedComponents;
        private System.Windows.Forms.Label lblTotalPriceLabel;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chbCoefficient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddComponent;
    }
}