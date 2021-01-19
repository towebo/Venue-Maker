namespace KWENDA.Views
{
    partial class SignInDialog
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
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.PwLabel = new System.Windows.Forms.Label();
            this.PwTB = new System.Windows.Forms.TextBox();
            this.SignInBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SignUpChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(12, 12);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(41, 15);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "&E-mail";
            // 
            // UserNameTB
            // 
            this.UserNameTB.Location = new System.Drawing.Point(15, 30);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(150, 23);
            this.UserNameTB.TabIndex = 1;
            // 
            // PwLabel
            // 
            this.PwLabel.AutoSize = true;
            this.PwLabel.Location = new System.Drawing.Point(12, 60);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(57, 15);
            this.PwLabel.TabIndex = 2;
            this.PwLabel.Text = "&Password";
            // 
            // PwTB
            // 
            this.PwTB.Location = new System.Drawing.Point(15, 78);
            this.PwTB.Name = "PwTB";
            this.PwTB.Size = new System.Drawing.Size(150, 23);
            this.PwTB.TabIndex = 3;
            this.PwTB.UseSystemPasswordChar = true;
            // 
            // SignInBtn
            // 
            this.SignInBtn.Location = new System.Drawing.Point(15, 123);
            this.SignInBtn.Name = "SignInBtn";
            this.SignInBtn.Size = new System.Drawing.Size(75, 23);
            this.SignInBtn.TabIndex = 4;
            this.SignInBtn.Text = "&Sign In";
            this.SignInBtn.UseVisualStyleBackColor = true;
            this.SignInBtn.Click += new System.EventHandler(this.SignInBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Control;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(100, 123);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // SignUpChk
            // 
            this.SignUpChk.AutoSize = true;
            this.SignUpChk.Location = new System.Drawing.Point(15, 156);
            this.SignUpChk.Name = "SignUpChk";
            this.SignUpChk.Size = new System.Drawing.Size(67, 19);
            this.SignUpChk.TabIndex = 6;
            this.SignUpChk.Text = "Sign Up";
            this.SignUpChk.UseVisualStyleBackColor = true;
            // 
            // SignInDialog
            // 
            this.AcceptButton = this.SignInBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(204, 192);
            this.Controls.Add(this.SignUpChk);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SignInBtn);
            this.Controls.Add(this.PwTB);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.UserNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SignInDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sign In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.Label PwLabel;
        private System.Windows.Forms.TextBox PwTB;
        private System.Windows.Forms.Button SignInBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.CheckBox SignUpChk;
    }
}