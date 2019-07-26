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
            this.SuspendLayout();
            // 
            // lsAvailableComponents
            // 
            this.lsAvailableComponents.Location = new System.Drawing.Point(12, 12);
            this.lsAvailableComponents.Name = "lsAvailableComponents";
            this.lsAvailableComponents.Size = new System.Drawing.Size(775, 250);
            this.lsAvailableComponents.TabIndex = 0;
            this.lsAvailableComponents.UseCompatibleStateImageBehavior = false;
            // 
            // ConfigurePCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsAvailableComponents);
            this.Name = "ConfigurePCForm";
            this.Text = "ConfigurePCForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsAvailableComponents;
    }
}