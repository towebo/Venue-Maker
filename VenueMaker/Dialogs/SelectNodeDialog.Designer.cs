namespace VenueMaker.Dialogs
{
    partial class SelectNodeDialog
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
            this.NodeListLabel = new System.Windows.Forms.Label();
            this.NodesLB = new System.Windows.Forms.ListBox();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.NodesBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NodesBS)).BeginInit();
            this.SuspendLayout();
            // 
            // NodeListLabel
            // 
            this.NodeListLabel.AutoSize = true;
            this.NodeListLabel.Location = new System.Drawing.Point(12, 12);
            this.NodeListLabel.Name = "NodeListLabel";
            this.NodeListLabel.Size = new System.Drawing.Size(40, 15);
            this.NodeListLabel.TabIndex = 0;
            this.NodeListLabel.Text = "&Noder";
            // 
            // NodesLB
            // 
            this.NodesLB.FormattingEnabled = true;
            this.NodesLB.ItemHeight = 15;
            this.NodesLB.Location = new System.Drawing.Point(15, 30);
            this.NodesLB.Name = "NodesLB";
            this.NodesLB.Size = new System.Drawing.Size(291, 439);
            this.NodesLB.TabIndex = 1;
            // 
            // SelectBtn
            // 
            this.SelectBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectBtn.Location = new System.Drawing.Point(150, 475);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectBtn.TabIndex = 2;
            this.SelectBtn.Text = "&Välj";
            this.SelectBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(231, 475);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SelectNodeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(320, 516);
            this.ControlBox = false;
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.NodesLB);
            this.Controls.Add(this.NodeListLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectNodeDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Välj nod";
            this.Load += new System.EventHandler(this.SelectNodeDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NodesBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NodeListLabel;
        private System.Windows.Forms.ListBox NodesLB;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.BindingSource NodesBS;
    }
}