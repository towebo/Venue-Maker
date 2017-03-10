namespace VenueMaker.Dialogs
{
    partial class MainForm
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newVenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVenueFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVenueFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenVenueDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenGraphMLDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveVenueDialog = new System.Windows.Forms.SaveFileDialog();
            this.VenueBS = new System.Windows.Forms.BindingSource(this.components);
            this.VenueNameLabel = new System.Windows.Forms.Label();
            this.VenueNameTB = new System.Windows.Forms.TextBox();
            this.VenueIDLabel = new System.Windows.Forms.Label();
            this.VenueIDTB = new System.Windows.Forms.TextBox();
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VenueBS)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(938, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVenueToolStripMenuItem,
            this.openVenueFileToolStripMenuItem,
            this.saveVenueFileToolStripMenuItem,
            this.closeAppToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "&Arkiv";
            // 
            // newVenueToolStripMenuItem
            // 
            this.newVenueToolStripMenuItem.Name = "newVenueToolStripMenuItem";
            this.newVenueToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.newVenueToolStripMenuItem.Text = "&Ny";
            this.newVenueToolStripMenuItem.Click += new System.EventHandler(this.newVenueToolStripMenuItem_Click);
            // 
            // openVenueFileToolStripMenuItem
            // 
            this.openVenueFileToolStripMenuItem.Name = "openVenueFileToolStripMenuItem";
            this.openVenueFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.openVenueFileToolStripMenuItem.Text = "&Öppna";
            this.openVenueFileToolStripMenuItem.Click += new System.EventHandler(this.openVenueFileToolStripMenuItem_Click);
            // 
            // saveVenueFileToolStripMenuItem
            // 
            this.saveVenueFileToolStripMenuItem.Name = "saveVenueFileToolStripMenuItem";
            this.saveVenueFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.saveVenueFileToolStripMenuItem.Text = "&Spara som";
            this.saveVenueFileToolStripMenuItem.Click += new System.EventHandler(this.saveVenueFileToolStripMenuItem_Click);
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.closeAppToolStripMenuItem.Text = "&Avsluta";
            this.closeAppToolStripMenuItem.Click += new System.EventHandler(this.closeAppToolStripMenuItem_Click);
            // 
            // OpenVenueDialog
            // 
            this.OpenVenueDialog.DefaultExt = "json";
            this.OpenVenueDialog.FileName = "openFileDialog1";
            this.OpenVenueDialog.Filter = "Venue Files (*.json)|*.json";
            // 
            // OpenGraphMLDialog
            // 
            this.OpenGraphMLDialog.DefaultExt = "graphml";
            this.OpenGraphMLDialog.FileName = "openFileDialog1";
            this.OpenGraphMLDialog.Filter = "Graphs (*.graphml)|graphml";
            // 
            // SaveVenueDialog
            // 
            this.SaveVenueDialog.DefaultExt = "json";
            this.SaveVenueDialog.Filter = "Venues (*.json)|*.json";
            // 
            // VenueNameLabel
            // 
            this.VenueNameLabel.AutoSize = true;
            this.VenueNameLabel.Location = new System.Drawing.Point(12, 37);
            this.VenueNameLabel.Name = "VenueNameLabel";
            this.VenueNameLabel.Size = new System.Drawing.Size(35, 13);
            this.VenueNameLabel.TabIndex = 1;
            this.VenueNameLabel.Text = "&Namn";
            // 
            // VenueNameTB
            // 
            this.VenueNameTB.Location = new System.Drawing.Point(15, 53);
            this.VenueNameTB.Name = "VenueNameTB";
            this.VenueNameTB.Size = new System.Drawing.Size(195, 20);
            this.VenueNameTB.TabIndex = 2;
            // 
            // VenueIDLabel
            // 
            this.VenueIDLabel.AutoSize = true;
            this.VenueIDLabel.Location = new System.Drawing.Point(12, 76);
            this.VenueIDLabel.Name = "VenueIDLabel";
            this.VenueIDLabel.Size = new System.Drawing.Size(18, 13);
            this.VenueIDLabel.TabIndex = 3;
            this.VenueIDLabel.Text = "&ID";
            // 
            // VenueIDTB
            // 
            this.VenueIDTB.Location = new System.Drawing.Point(15, 91);
            this.VenueIDTB.Name = "VenueIDTB";
            this.VenueIDTB.Size = new System.Drawing.Size(161, 20);
            this.VenueIDTB.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 642);
            this.Controls.Add(this.VenueIDTB);
            this.Controls.Add(this.VenueIDLabel);
            this.Controls.Add(this.VenueNameTB);
            this.Controls.Add(this.VenueNameLabel);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "MainForm";
            this.Text = "Venue Maker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VenueBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenVenueDialog;
        private System.Windows.Forms.OpenFileDialog OpenGraphMLDialog;
        private System.Windows.Forms.ToolStripMenuItem newVenueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVenueFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVenueFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAppToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveVenueDialog;
        private System.Windows.Forms.BindingSource VenueBS;
        private System.Windows.Forms.Label VenueNameLabel;
        private System.Windows.Forms.TextBox VenueNameTB;
        private System.Windows.Forms.Label VenueIDLabel;
        private System.Windows.Forms.TextBox VenueIDTB;
    }
}