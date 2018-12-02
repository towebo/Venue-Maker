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
            this.SaveBtn.Location = new System.Drawing.Point(72, 105);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "&Spara";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(153, 105);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // MapPropertiesDialog
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(240, 140);
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
    }
}