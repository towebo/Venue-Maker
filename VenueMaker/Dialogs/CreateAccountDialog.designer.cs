namespace VenueMaker.Dialogs
{
    partial class CreateAccountDialog
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
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PwTB = new System.Windows.Forms.TextBox();
            this.VerifyPwLabel = new System.Windows.Forms.Label();
            this.VerifyPwTB = new System.Windows.Forms.TextBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.CreateBtn = new System.Windows.Forms.Button();
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
            this.EmailTB.Size = new System.Drawing.Size(213, 23);
            this.EmailTB.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 56);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(57, 15);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "&Password";
            // 
            // PwTB
            // 
            this.PwTB.Location = new System.Drawing.Point(15, 74);
            this.PwTB.Name = "PwTB";
            this.PwTB.Size = new System.Drawing.Size(155, 23);
            this.PwTB.TabIndex = 3;
            this.PwTB.UseSystemPasswordChar = true;
            this.PwTB.TextChanged += new System.EventHandler(this.PwTB_TextChanged);
            // 
            // VerifyPwLabel
            // 
            this.VerifyPwLabel.AutoSize = true;
            this.VerifyPwLabel.Location = new System.Drawing.Point(12, 100);
            this.VerifyPwLabel.Name = "VerifyPwLabel";
            this.VerifyPwLabel.Size = new System.Drawing.Size(89, 15);
            this.VerifyPwLabel.TabIndex = 4;
            this.VerifyPwLabel.Text = "&Verify Password";
            // 
            // VerifyPwTB
            // 
            this.VerifyPwTB.Location = new System.Drawing.Point(15, 118);
            this.VerifyPwTB.Name = "VerifyPwTB";
            this.VerifyPwTB.Size = new System.Drawing.Size(100, 23);
            this.VerifyPwTB.TabIndex = 5;
            this.VerifyPwTB.UseSystemPasswordChar = true;
            this.VerifyPwTB.TextChanged += new System.EventHandler(this.VerifyPwTB_TextChanged);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(12, 155);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(199, 15);
            this.InfoLabel.TabIndex = 6;
            this.InfoLabel.Text = "Information about the information...";
            // 
            // CreateBtn
            // 
            this.CreateBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateBtn.Location = new System.Drawing.Point(72, 186);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateBtn.TabIndex = 7;
            this.CreateBtn.Text = "&Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(153, 186);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // CreateAccountDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(258, 221);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.VerifyPwTB);
            this.Controls.Add(this.VerifyPwLabel);
            this.Controls.Add(this.PwTB);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.EmailLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateAccountDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Account";
            this.Load += new System.EventHandler(this.CreateAccountDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PwTB;
        private System.Windows.Forms.Label VerifyPwLabel;
        private System.Windows.Forms.TextBox VerifyPwTB;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.BindingSource InfoBS;
    }
}