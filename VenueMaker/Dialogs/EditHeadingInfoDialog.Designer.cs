namespace VenueMaker.Dialogs
{
    partial class EditHeadingInfoDialog
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
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.HeadingTB = new System.Windows.Forms.TextBox();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.InfoTB = new System.Windows.Forms.TextBox();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.ImageTB = new System.Windows.Forms.TextBox();
            this.ImageDescriptionLabel = new System.Windows.Forms.Label();
            this.ImageDescriptionTB = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.PickImageBtn = new System.Windows.Forms.Button();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.HeadingInfoBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingInfoBS)).BeginInit();
            this.SuspendLayout();
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.AutoSize = true;
            this.HeadingLabel.Location = new System.Drawing.Point(12, 12);
            this.HeadingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(97, 15);
            this.HeadingLabel.TabIndex = 0;
            this.HeadingLabel.Text = "&Riktning (0 - 360)";
            // 
            // HeadingTB
            // 
            this.HeadingTB.Location = new System.Drawing.Point(15, 30);
            this.HeadingTB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.HeadingTB.Name = "HeadingTB";
            this.HeadingTB.Size = new System.Drawing.Size(48, 23);
            this.HeadingTB.TabIndex = 1;
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Location = new System.Drawing.Point(12, 56);
            this.InformationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(70, 15);
            this.InformationLabel.TabIndex = 2;
            this.InformationLabel.Text = "&Information";
            // 
            // InfoTB
            // 
            this.InfoTB.Location = new System.Drawing.Point(15, 74);
            this.InfoTB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.InfoTB.Name = "InfoTB";
            this.InfoTB.Size = new System.Drawing.Size(370, 23);
            this.InfoTB.TabIndex = 3;
            // 
            // ImageLabel
            // 
            this.ImageLabel.AutoSize = true;
            this.ImageLabel.Location = new System.Drawing.Point(12, 100);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(27, 15);
            this.ImageLabel.TabIndex = 4;
            this.ImageLabel.Text = "&Bild";
            // 
            // ImageTB
            // 
            this.ImageTB.Location = new System.Drawing.Point(15, 118);
            this.ImageTB.Name = "ImageTB";
            this.ImageTB.Size = new System.Drawing.Size(185, 23);
            this.ImageTB.TabIndex = 5;
            // 
            // ImageDescriptionLabel
            // 
            this.ImageDescriptionLabel.AutoSize = true;
            this.ImageDescriptionLabel.Location = new System.Drawing.Point(12, 144);
            this.ImageDescriptionLabel.Name = "ImageDescriptionLabel";
            this.ImageDescriptionLabel.Size = new System.Drawing.Size(88, 15);
            this.ImageDescriptionLabel.TabIndex = 7;
            this.ImageDescriptionLabel.Text = "Bi&ldbeskrivning";
            // 
            // ImageDescriptionTB
            // 
            this.ImageDescriptionTB.Location = new System.Drawing.Point(15, 162);
            this.ImageDescriptionTB.Name = "ImageDescriptionTB";
            this.ImageDescriptionTB.Size = new System.Drawing.Size(370, 23);
            this.ImageDescriptionTB.TabIndex = 8;
            // 
            // SaveBtn
            // 
            this.SaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveBtn.Location = new System.Drawing.Point(226, 202);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "&Spara";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(310, 202);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 10;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // PickImageBtn
            // 
            this.PickImageBtn.Location = new System.Drawing.Point(206, 117);
            this.PickImageBtn.Name = "PickImageBtn";
            this.PickImageBtn.Size = new System.Drawing.Size(75, 23);
            this.PickImageBtn.TabIndex = 6;
            this.PickImageBtn.Text = "&Välj";
            this.PickImageBtn.UseVisualStyleBackColor = true;
            this.PickImageBtn.Click += new System.EventHandler(this.PickImageBtn_Click);
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.DefaultExt = "png";
            this.OpenImageDialog.Filter = "Alla bildfiler|*.png;*.jpg;*.jpeg";
            // 
            // EditHeadingInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(397, 236);
            this.ControlBox = false;
            this.Controls.Add(this.PickImageBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ImageDescriptionTB);
            this.Controls.Add(this.ImageDescriptionLabel);
            this.Controls.Add(this.ImageTB);
            this.Controls.Add(this.ImageLabel);
            this.Controls.Add(this.InfoTB);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.HeadingTB);
            this.Controls.Add(this.HeadingLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditHeadingInfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vad finns ditåt";
            this.Load += new System.EventHandler(this.EditHeadingInfoDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeadingInfoBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.TextBox HeadingTB;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.TextBox InfoTB;
        private System.Windows.Forms.BindingSource HeadingInfoBS;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.TextBox ImageTB;
        private System.Windows.Forms.Label ImageDescriptionLabel;
        private System.Windows.Forms.TextBox ImageDescriptionTB;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button PickImageBtn;
        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
    }
}