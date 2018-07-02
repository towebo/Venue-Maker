namespace VenueMaker.Dialogs
{
    partial class SetPermissionsDialog
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
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.VenueIdLabel = new System.Windows.Forms.Label();
            this.VenueIdTB = new System.Windows.Forms.TextBox();
            this.PermitChk = new System.Windows.Forms.CheckBox();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ReadOnlyChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(12, 12);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(74, 15);
            this.EmailLabel.TabIndex = 0;
            this.EmailLabel.Text = "&E-postadress";
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(15, 30);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(144, 23);
            this.EmailTB.TabIndex = 1;
            // 
            // VenueIdLabel
            // 
            this.VenueIdLabel.AutoSize = true;
            this.VenueIdLabel.Location = new System.Drawing.Point(12, 56);
            this.VenueIdLabel.Name = "VenueIdLabel";
            this.VenueIdLabel.Size = new System.Drawing.Size(52, 15);
            this.VenueIdLabel.TabIndex = 2;
            this.VenueIdLabel.Text = "&Venue Id";
            // 
            // VenueIdTB
            // 
            this.VenueIdTB.Location = new System.Drawing.Point(15, 74);
            this.VenueIdTB.Name = "VenueIdTB";
            this.VenueIdTB.Size = new System.Drawing.Size(113, 23);
            this.VenueIdTB.TabIndex = 3;
            // 
            // PermitChk
            // 
            this.PermitChk.AutoSize = true;
            this.PermitChk.Checked = true;
            this.PermitChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PermitChk.Location = new System.Drawing.Point(15, 103);
            this.PermitChk.Name = "PermitChk";
            this.PermitChk.Size = new System.Drawing.Size(83, 19);
            this.PermitChk.TabIndex = 4;
            this.PermitChk.Text = "&Ge tillgång";
            this.PermitChk.UseVisualStyleBackColor = true;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ApplyBtn.Location = new System.Drawing.Point(15, 176);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyBtn.TabIndex = 6;
            this.ApplyBtn.Text = "&Ange";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(96, 176);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // ReadOnlyChk
            // 
            this.ReadOnlyChk.AutoSize = true;
            this.ReadOnlyChk.Location = new System.Drawing.Point(15, 128);
            this.ReadOnlyChk.Name = "ReadOnlyChk";
            this.ReadOnlyChk.Size = new System.Drawing.Size(96, 19);
            this.ReadOnlyChk.TabIndex = 5;
            this.ReadOnlyChk.Text = "Får inte &spara";
            this.ReadOnlyChk.UseVisualStyleBackColor = true;
            // 
            // SetPermissionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 211);
            this.Controls.Add(this.ReadOnlyChk);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.PermitChk);
            this.Controls.Add(this.VenueIdTB);
            this.Controls.Add(this.VenueIdLabel);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.EmailLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetPermissionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sätt rättigheter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Label VenueIdLabel;
        private System.Windows.Forms.TextBox VenueIdTB;
        private System.Windows.Forms.CheckBox PermitChk;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox ReadOnlyChk;
    }
}