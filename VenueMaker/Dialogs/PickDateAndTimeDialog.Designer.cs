namespace VenueMaker.Dialogs
{
    partial class PickDateAndTimeDialog
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
            this.MonthCal = new System.Windows.Forms.MonthCalendar();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.NoValueBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MonthCal
            // 
            this.MonthCal.Location = new System.Drawing.Point(14, 14);
            this.MonthCal.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.MonthCal.Name = "MonthCal";
            this.MonthCal.ShowWeekNumbers = true;
            this.MonthCal.TabIndex = 0;
            // 
            // TimePicker
            // 
            this.TimePicker.CustomFormat = "";
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePicker.Location = new System.Drawing.Point(14, 191);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(128, 23);
            this.TimePicker.TabIndex = 1;
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.DoneBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.DoneBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DoneBtn.Location = new System.Drawing.Point(14, 228);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(75, 23);
            this.DoneBtn.TabIndex = 2;
            this.DoneBtn.Text = "&Välj";
            this.DoneBtn.UseVisualStyleBackColor = false;
            // 
            // NoValueBtn
            // 
            this.NoValueBtn.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NoValueBtn.Location = new System.Drawing.Point(95, 228);
            this.NoValueBtn.Name = "NoValueBtn";
            this.NoValueBtn.Size = new System.Drawing.Size(75, 23);
            this.NoValueBtn.TabIndex = 3;
            this.NoValueBtn.Text = "&Inget värde";
            this.NoValueBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(181, 228);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // PickDateAndTimeDialog
            // 
            this.AcceptButton = this.DoneBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(258, 259);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.NoValueBtn);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.TimePicker);
            this.Controls.Add(this.MonthCal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PickDateAndTimeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Välj datum och tid";
            this.Load += new System.EventHandler(this.PickDateAndTimeDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar MonthCal;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.Button NoValueBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}