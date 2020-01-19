namespace VenueMaker.Dialogs
{
    partial class SendNotificationDialog
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.VenueIDLabel = new System.Windows.Forms.Label();
            this.VenueIdTB = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusCombo = new System.Windows.Forms.ComboBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(8, 8);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(73, 15);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "&Meddelande";
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(12, 26);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTB.Size = new System.Drawing.Size(257, 82);
            this.MessageTB.TabIndex = 1;
            // 
            // VenueIDLabel
            // 
            this.VenueIDLabel.AutoSize = true;
            this.VenueIDLabel.Location = new System.Drawing.Point(12, 111);
            this.VenueIDLabel.Name = "VenueIDLabel";
            this.VenueIDLabel.Size = new System.Drawing.Size(43, 15);
            this.VenueIDLabel.TabIndex = 2;
            this.VenueIDLabel.Text = "&PlatsID";
            // 
            // VenueIdTB
            // 
            this.VenueIdTB.Location = new System.Drawing.Point(15, 129);
            this.VenueIdTB.Name = "VenueIdTB";
            this.VenueIdTB.ReadOnly = true;
            this.VenueIdTB.Size = new System.Drawing.Size(100, 23);
            this.VenueIdTB.TabIndex = 3;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(16, 155);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 15);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "S&tatus";
            // 
            // StatusCombo
            // 
            this.StatusCombo.FormattingEnabled = true;
            this.StatusCombo.Items.AddRange(new object[] {
            "info\t"});
            this.StatusCombo.Location = new System.Drawing.Point(19, 173);
            this.StatusCombo.Name = "StatusCombo";
            this.StatusCombo.Size = new System.Drawing.Size(121, 23);
            this.StatusCombo.TabIndex = 5;
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SendButton.Location = new System.Drawing.Point(115, 223);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 6;
            this.SendButton.Text = "&Skicka";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(196, 223);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SendNotificationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(283, 258);
            this.ControlBox = false;
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.StatusCombo);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.VenueIdTB);
            this.Controls.Add(this.VenueIDLabel);
            this.Controls.Add(this.MessageTB);
            this.Controls.Add(this.MessageLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Name = "SendNotificationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skicka pushnotis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Label VenueIDLabel;
        private System.Windows.Forms.TextBox VenueIdTB;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ComboBox StatusCombo;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button CancelBtn;
    }
}