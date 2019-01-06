namespace VenueMaker.Dialogs
{
    partial class MapPropertiesDialog
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
            this.components = new System.ComponentModel.Container();
            this.MapTitleLabel = new System.Windows.Forms.Label();
            this.MapTitleTB = new System.Windows.Forms.TextBox();
            this.MapBS = new System.Windows.Forms.BindingSource(this.components);
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.SelectMapImageBtn = new System.Windows.Forms.Button();
            this.OpenMapDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MapBS)).BeginInit();
            this.SuspendLayout();
            // 
            // MapTitleLabel
            // 
            this.MapTitleLabel.AutoSize = true;
            this.MapTitleLabel.Location = new System.Drawing.Point(12, 12);
            this.MapTitleLabel.Name = "MapTitleLabel";
            this.MapTitleLabel.Size = new System.Drawing.Size(30, 15);
            this.MapTitleLabel.TabIndex = 0;
            this.MapTitleLabel.Text = "&Titel";
            // 
            // MapTitleTB
            // 
            this.MapTitleTB.Location = new System.Drawing.Point(15, 30);
            this.MapTitleTB.Name = "MapTitleTB";
            this.MapTitleTB.Size = new System.Drawing.Size(181, 23);
            this.MapTitleTB.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveBtn.Location = new System.Drawing.Point(138, 135);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "&Spara";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(219, 135);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(12, 56);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(50, 15);
            this.FileNameLabel.TabIndex = 2;
            this.FileNameLabel.Text = "&Filnamn";
            // 
            // FileNameTB
            // 
            this.FileNameTB.Location = new System.Drawing.Point(15, 74);
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.ReadOnly = true;
            this.FileNameTB.Size = new System.Drawing.Size(151, 23);
            this.FileNameTB.TabIndex = 3;
            // 
            // SelectMapImageBtn
            // 
            this.SelectMapImageBtn.Location = new System.Drawing.Point(172, 73);
            this.SelectMapImageBtn.Name = "SelectMapImageBtn";
            this.SelectMapImageBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectMapImageBtn.TabIndex = 4;
            this.SelectMapImageBtn.Text = "&Välj";
            this.SelectMapImageBtn.UseVisualStyleBackColor = true;
            this.SelectMapImageBtn.Click += new System.EventHandler(this.SelectMapImageBtn_Click);
            // 
            // OpenMapDialog
            // 
            this.OpenMapDialog.DefaultExt = "png";
            this.OpenMapDialog.Filter = "Kartbilder (*.png, *.jpg)|*.png;*.jpg|Alla filer (*.*)|*.*";
            this.OpenMapDialog.Title = "Välj kartbild";
            // 
            // MapPropertiesDialog
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(306, 170);
            this.Controls.Add(this.SelectMapImageBtn);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.MapTitleTB);
            this.Controls.Add(this.MapTitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MapPropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kartegenskaper";
            this.Load += new System.EventHandler(this.MapPropertiesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MapBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MapTitleLabel;
        private System.Windows.Forms.TextBox MapTitleTB;
        private System.Windows.Forms.BindingSource MapBS;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Button SelectMapImageBtn;
        private System.Windows.Forms.OpenFileDialog OpenMapDialog;
    }
}