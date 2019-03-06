namespace VenueMaker.Dialogs
{
    partial class ChangeBeaconForNodeDialog
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
            this.UuidLabel = new System.Windows.Forms.Label();
            this.UuidTB = new System.Windows.Forms.TextBox();
            this.MajorLabel = new System.Windows.Forms.Label();
            this.MajorTB = new System.Windows.Forms.TextBox();
            this.MinorLabel = new System.Windows.Forms.Label();
            this.MinorTB = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.InputBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InputBS)).BeginInit();
            this.SuspendLayout();
            // 
            // UuidLabel
            // 
            this.UuidLabel.AutoSize = true;
            this.UuidLabel.Location = new System.Drawing.Point(12, 12);
            this.UuidLabel.Name = "UuidLabel";
            this.UuidLabel.Size = new System.Drawing.Size(32, 15);
            this.UuidLabel.TabIndex = 0;
            this.UuidLabel.Text = "&Uuid";
            // 
            // UuidTB
            // 
            this.UuidTB.Location = new System.Drawing.Point(15, 30);
            this.UuidTB.Name = "UuidTB";
            this.UuidTB.Size = new System.Drawing.Size(241, 23);
            this.UuidTB.TabIndex = 1;
            // 
            // MajorLabel
            // 
            this.MajorLabel.AutoSize = true;
            this.MajorLabel.Location = new System.Drawing.Point(12, 60);
            this.MajorLabel.Name = "MajorLabel";
            this.MajorLabel.Size = new System.Drawing.Size(38, 15);
            this.MajorLabel.TabIndex = 2;
            this.MajorLabel.Text = "Ma&jor";
            // 
            // MajorTB
            // 
            this.MajorTB.Location = new System.Drawing.Point(15, 78);
            this.MajorTB.Name = "MajorTB";
            this.MajorTB.Size = new System.Drawing.Size(100, 23);
            this.MajorTB.TabIndex = 3;
            // 
            // MinorLabel
            // 
            this.MinorLabel.AutoSize = true;
            this.MinorLabel.Location = new System.Drawing.Point(121, 60);
            this.MinorLabel.Name = "MinorLabel";
            this.MinorLabel.Size = new System.Drawing.Size(39, 15);
            this.MinorLabel.TabIndex = 4;
            this.MinorLabel.Text = "M&inor";
            // 
            // MinorTB
            // 
            this.MinorTB.Location = new System.Drawing.Point(124, 78);
            this.MinorTB.Name = "MinorTB";
            this.MinorTB.Size = new System.Drawing.Size(100, 23);
            this.MinorTB.TabIndex = 5;
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.OkBtn.Location = new System.Drawing.Point(100, 123);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "&Byt";
            this.OkBtn.UseVisualStyleBackColor = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Control;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(181, 123);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // ChangeBeaconForNodeDialog
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(267, 154);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.MinorTB);
            this.Controls.Add(this.MinorLabel);
            this.Controls.Add(this.MajorTB);
            this.Controls.Add(this.MajorLabel);
            this.Controls.Add(this.UuidTB);
            this.Controls.Add(this.UuidLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChangeBeaconForNodeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Byt fyr på nod";
            this.Load += new System.EventHandler(this.ChangeBeaconForNodeDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InputBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UuidLabel;
        private System.Windows.Forms.TextBox UuidTB;
        private System.Windows.Forms.Label MajorLabel;
        private System.Windows.Forms.TextBox MajorTB;
        private System.Windows.Forms.Label MinorLabel;
        private System.Windows.Forms.TextBox MinorTB;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.BindingSource InputBS;
    }
}