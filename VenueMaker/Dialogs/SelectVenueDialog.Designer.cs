namespace VenueMaker.Dialogs
{
    partial class SelectVenueDialog
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
            this.VenuesListLabel = new System.Windows.Forms.Label();
            this.VenuesLB = new System.Windows.Forms.ListBox();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.VenuesBS = new System.Windows.Forms.BindingSource(this.components);
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VenuesBS)).BeginInit();
            this.SuspendLayout();
            // 
            // VenuesListLabel
            // 
            this.VenuesListLabel.AutoSize = true;
            this.VenuesListLabel.Location = new System.Drawing.Point(12, 12);
            this.VenuesListLabel.Name = "VenuesListLabel";
            this.VenuesListLabel.Size = new System.Drawing.Size(100, 15);
            this.VenuesListLabel.TabIndex = 0;
            this.VenuesListLabel.Text = "&Tillgänglia platser";
            // 
            // VenuesLB
            // 
            this.VenuesLB.FormattingEnabled = true;
            this.VenuesLB.ItemHeight = 15;
            this.VenuesLB.Location = new System.Drawing.Point(15, 30);
            this.VenuesLB.Name = "VenuesLB";
            this.VenuesLB.Size = new System.Drawing.Size(304, 229);
            this.VenuesLB.TabIndex = 1;
            // 
            // SelectBtn
            // 
            this.SelectBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectBtn.Location = new System.Drawing.Point(163, 265);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectBtn.TabIndex = 2;
            this.SelectBtn.Text = "&Välj";
            this.SelectBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(244, 266);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SelectVenueDialog
            // 
            this.AcceptButton = this.SelectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(331, 301);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.VenuesLB);
            this.Controls.Add(this.VenuesListLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SelectVenueDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Välj Venue";
            this.Load += new System.EventHandler(this.SelectVenueDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VenuesBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VenuesListLabel;
        private System.Windows.Forms.ListBox VenuesLB;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.BindingSource VenuesBS;
        private System.Windows.Forms.Button CancelBtn;
    }
}