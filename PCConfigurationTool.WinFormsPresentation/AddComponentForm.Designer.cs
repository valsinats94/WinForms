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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.Color.WhiteSmoke, null);
            this.btnAddComponent = new System.Windows.Forms.Button();
            this.ltvComponents = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Image = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picComponentPicture = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
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
            this.btnAddComponent.Location = new System.Drawing.Point(611, 390);
            this.btnAddComponent.Margin = new System.Windows.Forms.Padding(10);
            this.btnAddComponent.Name = "btnAddComponent";
            this.btnAddComponent.Size = new System.Drawing.Size(182, 53);
            this.btnAddComponent.TabIndex = 0;
            this.btnAddComponent.Text = "Add Component";
            this.btnAddComponent.UseVisualStyleBackColor = false;
            // 
            // ltvComponents
            // 
            this.ltvComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Image,
            this.Name,
            this.Description,
            this.Manufacturer,
            this.Price});
            this.ltvComponents.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.ltvComponents.Location = new System.Drawing.Point(39, 22);
            this.ltvComponents.Margin = new System.Windows.Forms.Padding(10);
            this.ltvComponents.MinimumSize = new System.Drawing.Size(200, 100);
            this.ltvComponents.Name = "ltvComponents";
            this.ltvComponents.Size = new System.Drawing.Size(714, 106);
            this.ltvComponents.TabIndex = 1;
            this.ltvComponents.UseCompatibleStateImageBehavior = false;
            // 
            // Name
            // 
            this.Name.DisplayIndex = 0;
            // 
            // Description
            // 
            this.Description.DisplayIndex = 1;
            // 
            // Price
            // 
            this.Price.DisplayIndex = 2;
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Image
            // 
            this.Image.DisplayIndex = 3;
            // 
            // Manufacturer
            // 
            this.Manufacturer.DisplayIndex = 4;
            // 
            // picComponentPicture
            // 
            this.picComponentPicture.Location = new System.Drawing.Point(39, 164);
            this.picComponentPicture.Name = "picComponentPicture";
            this.picComponentPicture.Size = new System.Drawing.Size(100, 85);
            this.picComponentPicture.TabIndex = 2;
            this.picComponentPicture.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(178, 164);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Component Name";
            // 
            // tbxName
            // 
            this.tbxName.AccessibleName = "tbxName";
            this.tbxName.Location = new System.Drawing.Point(276, 164);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(101, 20);
            this.tbxName.TabIndex = 4;
            // 
            // AddComponentForm
            // 
            this.AccessibleName = "ltvExistingComponents";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picComponentPicture);
            this.Controls.Add(this.ltvComponents);
            this.Controls.Add(this.btnAddComponent);
            this.MinimumSize = new System.Drawing.Size(810, 500);
            this.Name = "AddComponentForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "AddComponentForm";
            ((System.ComponentModel.ISupportInitialize)(this.picComponentPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddComponent;
        private System.Windows.Forms.ListView ltvComponents;
        private System.Windows.Forms.ColumnHeader Image;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Manufacturer;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.PictureBox picComponentPicture;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
    }
}