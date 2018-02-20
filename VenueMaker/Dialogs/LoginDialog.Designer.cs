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
            this.VerificationCodeLabel = new System.Windows.Forms.Label();
            this.VerificationCodeTB = new System.Windows.Forms.TextBox();
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
            this.EmailLabel.Text = "&E-post";
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
            this.PwLabel.Size = new System.Drawing.Size(56, 15);
            this.PwLabel.TabIndex = 2;
            this.PwLabel.Text = "L&ösenord";
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
            this.LoginBtn.Location = new System.Drawing.Point(15, 174);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 6;
            this.LoginBtn.Text = "&Logga in";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(96, 174);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // VerificationCodeLabel
            // 
            this.VerificationCodeLabel.AutoSize = true;
            this.VerificationCodeLabel.Location = new System.Drawing.Point(12, 100);
            this.VerificationCodeLabel.Name = "VerificationCodeLabel";
            this.VerificationCodeLabel.Size = new System.Drawing.Size(91, 15);
            this.VerificationCodeLabel.TabIndex = 4;
            this.VerificationCodeLabel.Text = "&Verifikationskod";
            // 
            // VerificationCodeTB
            // 
            this.VerificationCodeTB.Location = new System.Drawing.Point(15, 118);
            this.VerificationCodeTB.Name = "VerificationCodeTB";
            this.VerificationCodeTB.Size = new System.Drawing.Size(100, 23);
            this.VerificationCodeTB.TabIndex = 5;
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(199, 211);
            this.Controls.Add(this.VerificationCodeTB);
            this.Controls.Add(this.VerificationCodeLabel);
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
            this.Text = "Logga in";
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
        private System.Windows.Forms.Label VerificationCodeLabel;
        private System.Windows.Forms.TextBox VerificationCodeTB;
    }
}