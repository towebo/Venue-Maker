namespace VenueMaker.Dialogs
{
    partial class LoginDialog
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
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.PwLabel = new System.Windows.Forms.Label();
            this.PwTB = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.InfoBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InfoBS)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(12, 12);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(41, 15);
            this.EmailLabel.TabIndex = 0;
            this.EmailLabel.Text = "&E-mail";
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(15, 30);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(148, 23);
            this.EmailTB.TabIndex = 1;
            // 
            // PwLabel
            // 
            this.PwLabel.AutoSize = true;
            this.PwLabel.Location = new System.Drawing.Point(12, 56);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(57, 15);
            this.PwLabel.TabIndex = 2;
            this.PwLabel.Text = "&Password";
            // 
            // PwTB
            // 
            this.PwTB.Location = new System.Drawing.Point(15, 74);
            this.PwTB.Name = "PwTB";
            this.PwTB.Size = new System.Drawing.Size(148, 23);
            this.PwTB.TabIndex = 3;
            this.PwTB.UseSystemPasswordChar = true;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(15, 137);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "&Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(96, 137);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // LoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 173);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PwTB);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.EmailLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Label PwLabel;
        private System.Windows.Forms.TextBox PwTB;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.BindingSource InfoBS;
    }
}