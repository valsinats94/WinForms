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
            this.btnCreateConfiguration = new System.Windows.Forms.Button();
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.btnLoadConfigurations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateConfiguration
            // 
            this.btnCreateConfiguration.Location = new System.Drawing.Point(70, 60);
            this.btnCreateConfiguration.Name = "btnCreateConfiguration";
            this.btnCreateConfiguration.Size = new System.Drawing.Size(300, 150);
            this.btnCreateConfiguration.TabIndex = 0;
            this.btnCreateConfiguration.Text = "Create Configuration";
            this.btnCreateConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnAddComponent
            // 
            this.btnAddComponent.Location = new System.Drawing.Point(420, 62);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(318, 148);
            this.btnAddComponent.TabIndex = 1;
            this.btnAddComponent.Text = "Add New PC Component";
            this.btnAddComponent.UseVisualStyleBackColor = true;
            // 
            // btnLoadConfigurations
            // 
            this.btnLoadConfigurations.Location = new System.Drawing.Point(230, 253);
            this.btnLoadConfigurations.Name = "btnLoadConfigurations";
            this.btnLoadConfigurations.Size = new System.Drawing.Size(318, 150);
            this.btnLoadConfigurations.TabIndex = 2;
            this.btnLoadConfigurations.Text = "Show Configrations";
            this.btnLoadConfigurations.UseVisualStyleBackColor = true;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadConfigurations);
            this.Controls.Add(this.btnAddComponent);
            this.Controls.Add(this.btnCreateConfiguration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome To PC Configuration";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateConfiguration;
        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.Button btnLoadConfigurations;
    }
}