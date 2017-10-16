namespace VenueMaker.Dialogs
{
    partial class NewEdgeDialog
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
            this.FromEdgeLabel = new System.Windows.Forms.Label();
            this.FromNodeCombo = new System.Windows.Forms.ComboBox();
            this.ToNodeLabel = new System.Windows.Forms.Label();
            this.ToNodeCombo = new System.Windows.Forms.ComboBox();
            this.BeginningLabel = new System.Windows.Forms.Label();
            this.BeginningTB = new System.Windows.Forms.TextBox();
            this.StartHeadingLabel = new System.Windows.Forms.Label();
            this.StartHeadingTB = new System.Windows.Forms.TextBox();
            this.EndHeadingLabel = new System.Windows.Forms.Label();
            this.EndHeadingTB = new System.Windows.Forms.TextBox();
            this.TravelTimeLabel = new System.Windows.Forms.Label();
            this.TravelTimeTB = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.InfoBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InfoBS)).BeginInit();
            this.SuspendLayout();
            // 
            // FromEdgeLabel
            // 
            this.FromEdgeLabel.AutoSize = true;
            this.FromEdgeLabel.Location = new System.Drawing.Point(12, 12);
            this.FromEdgeLabel.Name = "FromEdgeLabel";
            this.FromEdgeLabel.Size = new System.Drawing.Size(30, 15);
            this.FromEdgeLabel.TabIndex = 0;
            this.FromEdgeLabel.Text = "&Från";
            // 
            // FromNodeCombo
            // 
            this.FromNodeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FromNodeCombo.FormattingEnabled = true;
            this.FromNodeCombo.Location = new System.Drawing.Point(15, 30);
            this.FromNodeCombo.Name = "FromNodeCombo";
            this.FromNodeCombo.Size = new System.Drawing.Size(196, 23);
            this.FromNodeCombo.TabIndex = 1;
            // 
            // ToNodeLabel
            // 
            this.ToNodeLabel.AutoSize = true;
            this.ToNodeLabel.Location = new System.Drawing.Point(12, 56);
            this.ToNodeLabel.Name = "ToNodeLabel";
            this.ToNodeLabel.Size = new System.Drawing.Size(23, 15);
            this.ToNodeLabel.TabIndex = 2;
            this.ToNodeLabel.Text = "&Till";
            // 
            // ToNodeCombo
            // 
            this.ToNodeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToNodeCombo.FormattingEnabled = true;
            this.ToNodeCombo.Location = new System.Drawing.Point(15, 74);
            this.ToNodeCombo.Name = "ToNodeCombo";
            this.ToNodeCombo.Size = new System.Drawing.Size(196, 23);
            this.ToNodeCombo.TabIndex = 3;
            // 
            // BeginningLabel
            // 
            this.BeginningLabel.AutoSize = true;
            this.BeginningLabel.Location = new System.Drawing.Point(12, 100);
            this.BeginningLabel.Name = "BeginningLabel";
            this.BeginningLabel.Size = new System.Drawing.Size(70, 15);
            this.BeginningLabel.TabIndex = 4;
            this.BeginningLabel.Text = "&Information";
            // 
            // BeginningTB
            // 
            this.BeginningTB.Location = new System.Drawing.Point(15, 118);
            this.BeginningTB.Name = "BeginningTB";
            this.BeginningTB.Size = new System.Drawing.Size(196, 23);
            this.BeginningTB.TabIndex = 5;
            // 
            // StartHeadingLabel
            // 
            this.StartHeadingLabel.AutoSize = true;
            this.StartHeadingLabel.Location = new System.Drawing.Point(12, 144);
            this.StartHeadingLabel.Name = "StartHeadingLabel";
            this.StartHeadingLabel.Size = new System.Drawing.Size(72, 15);
            this.StartHeadingLabel.TabIndex = 6;
            this.StartHeadingLabel.Text = "&Startriktning";
            // 
            // StartHeadingTB
            // 
            this.StartHeadingTB.Location = new System.Drawing.Point(15, 162);
            this.StartHeadingTB.Name = "StartHeadingTB";
            this.StartHeadingTB.Size = new System.Drawing.Size(100, 23);
            this.StartHeadingTB.TabIndex = 7;
            // 
            // EndHeadingLabel
            // 
            this.EndHeadingLabel.AutoSize = true;
            this.EndHeadingLabel.Location = new System.Drawing.Point(119, 144);
            this.EndHeadingLabel.Name = "EndHeadingLabel";
            this.EndHeadingLabel.Size = new System.Drawing.Size(71, 15);
            this.EndHeadingLabel.TabIndex = 8;
            this.EndHeadingLabel.Text = "S&Lutriktning";
            // 
            // EndHeadingTB
            // 
            this.EndHeadingTB.Location = new System.Drawing.Point(122, 162);
            this.EndHeadingTB.Name = "EndHeadingTB";
            this.EndHeadingTB.Size = new System.Drawing.Size(100, 23);
            this.EndHeadingTB.TabIndex = 9;
            // 
            // TravelTimeLabel
            // 
            this.TravelTimeLabel.AutoSize = true;
            this.TravelTimeLabel.Location = new System.Drawing.Point(225, 144);
            this.TravelTimeLabel.Name = "TravelTimeLabel";
            this.TravelTimeLabel.Size = new System.Drawing.Size(39, 15);
            this.TravelTimeLabel.TabIndex = 10;
            this.TravelTimeLabel.Text = "&Restid";
            // 
            // TravelTimeTB
            // 
            this.TravelTimeTB.Location = new System.Drawing.Point(228, 162);
            this.TravelTimeTB.Name = "TravelTimeTB";
            this.TravelTimeTB.Size = new System.Drawing.Size(100, 23);
            this.TravelTimeTB.TabIndex = 11;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(172, 210);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "L&ä\'gg till";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(253, 210);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Avbryt";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // NewEdgeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(336, 239);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TravelTimeTB);
            this.Controls.Add(this.TravelTimeLabel);
            this.Controls.Add(this.EndHeadingTB);
            this.Controls.Add(this.EndHeadingLabel);
            this.Controls.Add(this.StartHeadingTB);
            this.Controls.Add(this.StartHeadingLabel);
            this.Controls.Add(this.BeginningTB);
            this.Controls.Add(this.BeginningLabel);
            this.Controls.Add(this.ToNodeCombo);
            this.Controls.Add(this.ToNodeLabel);
            this.Controls.Add(this.FromNodeCombo);
            this.Controls.Add(this.FromEdgeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewEdgeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ny vägbeskrivning";
            this.Load += new System.EventHandler(this.NewEdgeDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FromEdgeLabel;
        private System.Windows.Forms.ComboBox FromNodeCombo;
        private System.Windows.Forms.Label ToNodeLabel;
        private System.Windows.Forms.ComboBox ToNodeCombo;
        private System.Windows.Forms.Label BeginningLabel;
        private System.Windows.Forms.TextBox BeginningTB;
        private System.Windows.Forms.Label StartHeadingLabel;
        private System.Windows.Forms.TextBox StartHeadingTB;
        private System.Windows.Forms.Label EndHeadingLabel;
        private System.Windows.Forms.TextBox EndHeadingTB;
        private System.Windows.Forms.Label TravelTimeLabel;
        private System.Windows.Forms.TextBox TravelTimeTB;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.BindingSource InfoBS;
    }
}