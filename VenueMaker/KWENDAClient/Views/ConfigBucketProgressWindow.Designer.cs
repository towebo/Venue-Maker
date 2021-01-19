
namespace ConfigBucket.Views
{
    partial class ConfigBucketProgressWindow
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
            this.BorderPanel = new System.Windows.Forms.Panel();
            this.LogoPB = new System.Windows.Forms.PictureBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.BorderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPB)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderPanel
            // 
            this.BorderPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BorderPanel.Controls.Add(this.LogoPB);
            this.BorderPanel.Controls.Add(this.InfoLabel);
            this.BorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorderPanel.Location = new System.Drawing.Point(0, 0);
            this.BorderPanel.Name = "BorderPanel";
            this.BorderPanel.Size = new System.Drawing.Size(300, 60);
            this.BorderPanel.TabIndex = 0;
            // 
            // LogoPB
            // 
            this.LogoPB.Location = new System.Drawing.Point(8, 4);
            this.LogoPB.Name = "LogoPB";
            this.LogoPB.Size = new System.Drawing.Size(48, 48);
            this.LogoPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LogoPB.TabIndex = 2;
            this.LogoPB.TabStop = false;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Location = new System.Drawing.Point(56, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(240, 56);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "Information about the progress";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfigBucketProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(300, 60);
            this.Controls.Add(this.BorderPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigBucketProgressWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.ConfigBucketProgressWindow_Load);
            this.BorderPanel.ResumeLayout(false);
            this.BorderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderPanel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.PictureBox LogoPB;
    }
}