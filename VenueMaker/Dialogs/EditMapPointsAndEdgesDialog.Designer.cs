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
            this.MapCombo = new System.Windows.Forms.ComboBox();
            this.MapLabel = new System.Windows.Forms.Label();
            this.Statusbar = new System.Windows.Forms.StatusStrip();
            this.MousePositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapsBS = new System.Windows.Forms.BindingSource(this.components);
            this.MapPanel = new System.Windows.Forms.Panel();
            this.MapPB = new System.Windows.Forms.PictureBox();
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
            this.ToolbarPanel.Controls.Add(this.MapCombo);
            this.ToolbarPanel.Controls.Add(this.MapLabel);
            this.ToolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolbarPanel.Name = "ToolbarPanel";
            this.ToolbarPanel.Size = new System.Drawing.Size(800, 53);
            this.ToolbarPanel.TabIndex = 0;
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
            this.MousePositionLabel.Size = new System.Drawing.Size(27, 17);
            this.MousePositionLabel.Text = "x: y:";
            // 
            // MapPanel
            // 
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
    }
}