namespace VenueMaker.Dialogs
{
    partial class EditMapPointsAndEdgesDialog
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
            this.ToolbarPanel = new System.Windows.Forms.Panel();
            this.ClearDirectionPointsBtn = new System.Windows.Forms.Button();
            this.ShowNamesChk = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.MapCombo = new System.Windows.Forms.ComboBox();
            this.MapLabel = new System.Windows.Forms.Label();
            this.Statusbar = new System.Windows.Forms.StatusStrip();
            this.MousePositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapsBS = new System.Windows.Forms.BindingSource(this.components);
            this.MapPanel = new System.Windows.Forms.Panel();
            this.MapPB = new System.Windows.Forms.PictureBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ToolbarPanel.SuspendLayout();
            this.Statusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapsBS)).BeginInit();
            this.MapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPB)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolbarPanel
            // 
            this.ToolbarPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ToolbarPanel.Controls.Add(this.CancelBtn);
            this.ToolbarPanel.Controls.Add(this.ClearDirectionPointsBtn);
            this.ToolbarPanel.Controls.Add(this.ShowNamesChk);
            this.ToolbarPanel.Controls.Add(this.SaveBtn);
            this.ToolbarPanel.Controls.Add(this.MapCombo);
            this.ToolbarPanel.Controls.Add(this.MapLabel);
            this.ToolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolbarPanel.Name = "ToolbarPanel";
            this.ToolbarPanel.Size = new System.Drawing.Size(800, 53);
            this.ToolbarPanel.TabIndex = 0;
            // 
            // ClearDirectionPointsBtn
            // 
            this.ClearDirectionPointsBtn.Location = new System.Drawing.Point(290, 17);
            this.ClearDirectionPointsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ClearDirectionPointsBtn.Name = "ClearDirectionPointsBtn";
            this.ClearDirectionPointsBtn.Size = new System.Drawing.Size(150, 23);
            this.ClearDirectionPointsBtn.TabIndex = 4;
            this.ClearDirectionPointsBtn.Text = "&Rensa vägbeskrivning";
            this.ClearDirectionPointsBtn.UseVisualStyleBackColor = true;
            this.ClearDirectionPointsBtn.Click += new System.EventHandler(this.ClearDirectionPointsBtn_Click);
            // 
            // ShowNamesChk
            // 
            this.ShowNamesChk.AutoSize = true;
            this.ShowNamesChk.Location = new System.Drawing.Point(147, 21);
            this.ShowNamesChk.Name = "ShowNamesChk";
            this.ShowNamesChk.Size = new System.Drawing.Size(122, 17);
            this.ShowNamesChk.TabIndex = 3;
            this.ShowNamesChk.Text = "&Visa nodernas namn";
            this.ShowNamesChk.UseVisualStyleBackColor = true;
            this.ShowNamesChk.CheckedChanged += new System.EventHandler(this.ShowNamesChk_CheckedChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveBtn.Location = new System.Drawing.Point(632, 17);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "&Spara";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // MapCombo
            // 
            this.MapCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapCombo.FormattingEnabled = true;
            this.MapCombo.Location = new System.Drawing.Point(12, 19);
            this.MapCombo.Name = "MapCombo";
            this.MapCombo.Size = new System.Drawing.Size(121, 21);
            this.MapCombo.TabIndex = 1;
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(12, 3);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(32, 13);
            this.MapLabel.TabIndex = 0;
            this.MapLabel.Text = "&Karta";
            // 
            // Statusbar
            // 
            this.Statusbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MousePositionLabel});
            this.Statusbar.Location = new System.Drawing.Point(0, 428);
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.Size = new System.Drawing.Size(800, 22);
            this.Statusbar.TabIndex = 2;
            this.Statusbar.Text = "statusStrip1";
            // 
            // MousePositionLabel
            // 
            this.MousePositionLabel.Name = "MousePositionLabel";
            this.MousePositionLabel.Size = new System.Drawing.Size(28, 17);
            this.MousePositionLabel.Text = "x: y:";
            // 
            // MapPanel
            // 
            this.MapPanel.AutoScroll = true;
            this.MapPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MapPanel.Controls.Add(this.MapPB);
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(0, 53);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(800, 375);
            this.MapPanel.TabIndex = 3;
            // 
            // MapPB
            // 
            this.MapPB.AccessibleDescription = "Karta";
            this.MapPB.Location = new System.Drawing.Point(0, 0);
            this.MapPB.Name = "MapPB";
            this.MapPB.Size = new System.Drawing.Size(100, 100);
            this.MapPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MapPB.TabIndex = 2;
            this.MapPB.TabStop = false;
            this.MapPB.Paint += new System.Windows.Forms.PaintEventHandler(this.MapPB_Paint);
            this.MapPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPB_MouseDown);
            this.MapPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPB_MouseMove);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(713, 17);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Avbryt";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // EditMapPointsAndEdgesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MapPanel);
            this.Controls.Add(this.Statusbar);
            this.Controls.Add(this.ToolbarPanel);
            this.Name = "EditMapPointsAndEdgesDialog";
            this.Text = "EditMapPointsAndEdgesDialog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditMapPointsAndEdgesDialog_FormClosed);
            this.Load += new System.EventHandler(this.EditMapPointsAndEdgesDialog_Load);
            this.ToolbarPanel.ResumeLayout(false);
            this.ToolbarPanel.PerformLayout();
            this.Statusbar.ResumeLayout(false);
            this.Statusbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapsBS)).EndInit();
            this.MapPanel.ResumeLayout(false);
            this.MapPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ToolbarPanel;
        private System.Windows.Forms.StatusStrip Statusbar;
        private System.Windows.Forms.ToolStripStatusLabel MousePositionLabel;
        private System.Windows.Forms.ComboBox MapCombo;
        private System.Windows.Forms.BindingSource MapsBS;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.PictureBox MapPB;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.CheckBox ShowNamesChk;
        private System.Windows.Forms.Button ClearDirectionPointsBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}