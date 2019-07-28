namespace PCConfigurationTool.WinFormsPresentation
{
    partial class EntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.btnCreateConfiguration = new System.Windows.Forms.Button();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateConfiguration
            // 
            this.btnCreateConfiguration.Location = new System.Drawing.Point(37, 98);
            this.btnCreateConfiguration.Name = "btnCreateConfiguration";
            this.btnCreateConfiguration.Size = new System.Drawing.Size(343, 181);
            this.btnCreateConfiguration.TabIndex = 0;
            this.btnCreateConfiguration.Text = "Create Configuration";
            this.btnCreateConfiguration.UseVisualStyleBackColor = true;
            this.btnCreateConfiguration.Click += new System.EventHandler(this.btnCreateConfiguration_Click);
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(417, 98);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(343, 181);
            this.btnAddComponent.TabIndex = 1;
            this.btnAddComponent.Text = "Add New PC Component";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            this.btnAddComponent.Click += new System.EventHandler(this.btnAddComponent_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(606, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 54);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddComponent);
            this.Controls.Add(this.btnCreateConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome To PC Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateConfiguration;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnClose;
    }
}