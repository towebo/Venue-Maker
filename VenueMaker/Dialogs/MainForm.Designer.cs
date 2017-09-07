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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newVenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVenueFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVenueMenuItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVenueFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pushToCloudMenuItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenVenueDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenGraphMLDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveVenueDialog = new System.Windows.Forms.SaveFileDialog();
            this.VenueBS = new System.Windows.Forms.BindingSource(this.components);
            this.VenueNameLabel = new System.Windows.Forms.Label();
            this.VenueNameTB = new System.Windows.Forms.TextBox();
            this.VenueIDLabel = new System.Windows.Forms.Label();
            this.VenueIDTB = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressTB = new System.Windows.Forms.TextBox();
            this.ZipLabel = new System.Windows.Forms.Label();
            this.ZipTB = new System.Windows.Forms.TextBox();
            this.CityLabel = new System.Windows.Forms.Label();
            this.CityTB = new System.Windows.Forms.TextBox();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.CountryTB = new System.Windows.Forms.TextBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.PoiTabPage = new System.Windows.Forms.TabPage();
            this.AutoPlayMediaCB = new System.Windows.Forms.CheckBox();
            this.MediaDescrTB = new System.Windows.Forms.TextBox();
            this.MediaDescLabel = new System.Windows.Forms.Label();
            this.PickMediaFileButton = new System.Windows.Forms.Button();
            this.MediaFileTB = new System.Windows.Forms.TextBox();
            this.MediaFileLabel = new System.Windows.Forms.Label();
            this.MoveInfoDownButton = new System.Windows.Forms.Button();
            this.MoveInfoUpButton = new System.Windows.Forms.Button();
            this.RemovePOIInfoButton = new System.Windows.Forms.Button();
            this.AddPOIInfoButton = new System.Windows.Forms.Button();
            this.POIInfoEndsTB = new System.Windows.Forms.TextBox();
            this.POIInfoEndsLabel = new System.Windows.Forms.Label();
            this.POIInfoStartsTB = new System.Windows.Forms.TextBox();
            this.POIInfoStartsLabel = new System.Windows.Forms.Label();
            this.POIInfoCatCombo = new System.Windows.Forms.ComboBox();
            this.POIInfoCatLabel = new System.Windows.Forms.Label();
            this.POIInformationTB = new System.Windows.Forms.TextBox();
            this.POIInfoLabel = new System.Windows.Forms.Label();
            this.POIInfosLB = new System.Windows.Forms.ListBox();
            this.POIsListLabel = new System.Windows.Forms.Label();
            this.POIsLB = new System.Windows.Forms.ListBox();
            this.ExitsTabPabe = new System.Windows.Forms.TabPage();
            this.POIsBS = new System.Windows.Forms.BindingSource(this.components);
            this.POIInfosBS = new System.Windows.Forms.BindingSource(this.components);
            this.VenueDescriptionLabel = new System.Windows.Forms.Label();
            this.VenueDescriptionTB = new System.Windows.Forms.TextBox();
            this.VisibilityLabel = new System.Windows.Forms.Label();
            this.VisibilityCombo = new System.Windows.Forms.ComboBox();
            this.OpenMediaFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VenueBS)).BeginInit();
            this.Tabs.SuspendLayout();
            this.PoiTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.POIsBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POIInfosBS)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MainMenuStrip.Size = new System.Drawing.Size(1129, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVenueToolStripMenuItem,
            this.openVenueFileToolStripMenuItem,
            this.saveVenueMenuItemToolStripMenuItem,
            this.saveVenueFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.pushToCloudMenuItemToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeAppToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "&Arkiv";
            // 
            // newVenueToolStripMenuItem
            // 
            this.newVenueToolStripMenuItem.Name = "newVenueToolStripMenuItem";
            this.newVenueToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newVenueToolStripMenuItem.Text = "&Ny";
            this.newVenueToolStripMenuItem.Click += new System.EventHandler(this.newVenueToolStripMenuItem_Click);
            // 
            // openVenueFileToolStripMenuItem
            // 
            this.openVenueFileToolStripMenuItem.Name = "openVenueFileToolStripMenuItem";
            this.openVenueFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openVenueFileToolStripMenuItem.Text = "&Öppna";
            this.openVenueFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openVenueFileToolStripMenuItem.Click += new System.EventHandler(this.openVenueFileToolStripMenuItem_Click);
            // 
            // saveVenueMenuItemToolStripMenuItem
            // 
            this.saveVenueMenuItemToolStripMenuItem.Name = "saveVenueMenuItemToolStripMenuItem";
            this.saveVenueMenuItemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveVenueMenuItemToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveVenueMenuItemToolStripMenuItem.Text = "&Spara";
            this.saveVenueMenuItemToolStripMenuItem.Click += new System.EventHandler(this.SaveMenuItems_Click);
            // 
            // saveVenueFileToolStripMenuItem
            // 
            this.saveVenueFileToolStripMenuItem.Name = "saveVenueFileToolStripMenuItem";
            this.saveVenueFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveVenueFileToolStripMenuItem.Text = "Spara so&m";
            this.saveVenueFileToolStripMenuItem.Click += new System.EventHandler(this.SaveMenuItems_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // pushToCloudMenuItemToolStripMenuItem
            // 
            this.pushToCloudMenuItemToolStripMenuItem.Name = "pushToCloudMenuItemToolStripMenuItem";
            this.pushToCloudMenuItemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.pushToCloudMenuItemToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pushToCloudMenuItemToolStripMenuItem.Text = "Ladda upp till molnet";
            this.pushToCloudMenuItemToolStripMenuItem.Click += new System.EventHandler(this.pushToCloudMenuItemToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.closeAppToolStripMenuItem.Text = "&Avsluta";
            this.closeAppToolStripMenuItem.Click += new System.EventHandler(this.closeAppToolStripMenuItem_Click);
            // 
            // OpenVenueDialog
            // 
            this.OpenVenueDialog.DefaultExt = "venue";
            this.OpenVenueDialog.FileName = "openFileDialog1";
            this.OpenVenueDialog.Filter = "Venue Files (*.venue)|*.venue";
            // 
            // OpenGraphMLDialog
            // 
            this.OpenGraphMLDialog.DefaultExt = "graphml";
            this.OpenGraphMLDialog.FileName = "openFileDialog1";
            this.OpenGraphMLDialog.Filter = "Graphs (*.graphml)|graphml";
            // 
            // SaveVenueDialog
            // 
            this.SaveVenueDialog.DefaultExt = "venue";
            this.SaveVenueDialog.Filter = "Venues (*.venue)|*.venue";
            // 
            // VenueNameLabel
            // 
            this.VenueNameLabel.AutoSize = true;
            this.VenueNameLabel.Location = new System.Drawing.Point(14, 43);
            this.VenueNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.VenueNameLabel.Name = "VenueNameLabel";
            this.VenueNameLabel.Size = new System.Drawing.Size(40, 15);
            this.VenueNameLabel.TabIndex = 1;
            this.VenueNameLabel.Text = "&Namn";
            // 
            // VenueNameTB
            // 
            this.VenueNameTB.Location = new System.Drawing.Point(14, 61);
            this.VenueNameTB.Margin = new System.Windows.Forms.Padding(5);
            this.VenueNameTB.Name = "VenueNameTB";
            this.VenueNameTB.Size = new System.Drawing.Size(226, 23);
            this.VenueNameTB.TabIndex = 2;
            // 
            // VenueIDLabel
            // 
            this.VenueIDLabel.AutoSize = true;
            this.VenueIDLabel.Location = new System.Drawing.Point(14, 88);
            this.VenueIDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.VenueIDLabel.Name = "VenueIDLabel";
            this.VenueIDLabel.Size = new System.Drawing.Size(18, 15);
            this.VenueIDLabel.TabIndex = 3;
            this.VenueIDLabel.Text = "&ID";
            // 
            // VenueIDTB
            // 
            this.VenueIDTB.Location = new System.Drawing.Point(14, 105);
            this.VenueIDTB.Margin = new System.Windows.Forms.Padding(5);
            this.VenueIDTB.Name = "VenueIDTB";
            this.VenueIDTB.Size = new System.Drawing.Size(188, 23);
            this.VenueIDTB.TabIndex = 4;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(14, 130);
            this.AddressLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(42, 15);
            this.AddressLabel.TabIndex = 5;
            this.AddressLabel.Text = "A&dress";
            // 
            // AddressTB
            // 
            this.AddressTB.Location = new System.Drawing.Point(14, 150);
            this.AddressTB.Margin = new System.Windows.Forms.Padding(5);
            this.AddressTB.Name = "AddressTB";
            this.AddressTB.Size = new System.Drawing.Size(188, 23);
            this.AddressTB.TabIndex = 6;
            // 
            // ZipLabel
            // 
            this.ZipLabel.AutoSize = true;
            this.ZipLabel.Location = new System.Drawing.Point(14, 175);
            this.ZipLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ZipLabel.Name = "ZipLabel";
            this.ZipLabel.Size = new System.Drawing.Size(41, 15);
            this.ZipLabel.TabIndex = 7;
            this.ZipLabel.Text = "&Postnr";
            // 
            // ZipTB
            // 
            this.ZipTB.Location = new System.Drawing.Point(19, 195);
            this.ZipTB.Margin = new System.Windows.Forms.Padding(5);
            this.ZipTB.Name = "ZipTB";
            this.ZipTB.Size = new System.Drawing.Size(72, 23);
            this.ZipTB.TabIndex = 8;
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(96, 175);
            this.CityLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(24, 15);
            this.CityLabel.TabIndex = 9;
            this.CityLabel.Text = "&Ort";
            // 
            // CityTB
            // 
            this.CityTB.Location = new System.Drawing.Point(96, 195);
            this.CityTB.Margin = new System.Windows.Forms.Padding(5);
            this.CityTB.Name = "CityTB";
            this.CityTB.Size = new System.Drawing.Size(183, 23);
            this.CityTB.TabIndex = 10;
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Location = new System.Drawing.Point(14, 220);
            this.CountryLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(33, 15);
            this.CountryLabel.TabIndex = 11;
            this.CountryLabel.Text = "&Land";
            // 
            // CountryTB
            // 
            this.CountryTB.Location = new System.Drawing.Point(19, 240);
            this.CountryTB.Margin = new System.Windows.Forms.Padding(5);
            this.CountryTB.Name = "CountryTB";
            this.CountryTB.Size = new System.Drawing.Size(163, 23);
            this.CountryTB.TabIndex = 12;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.PoiTabPage);
            this.Tabs.Controls.Add(this.ExitsTabPabe);
            this.Tabs.Location = new System.Drawing.Point(288, 43);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(834, 547);
            this.Tabs.TabIndex = 17;
            // 
            // PoiTabPage
            // 
            this.PoiTabPage.Controls.Add(this.AutoPlayMediaCB);
            this.PoiTabPage.Controls.Add(this.MediaDescrTB);
            this.PoiTabPage.Controls.Add(this.MediaDescLabel);
            this.PoiTabPage.Controls.Add(this.PickMediaFileButton);
            this.PoiTabPage.Controls.Add(this.MediaFileTB);
            this.PoiTabPage.Controls.Add(this.MediaFileLabel);
            this.PoiTabPage.Controls.Add(this.MoveInfoDownButton);
            this.PoiTabPage.Controls.Add(this.MoveInfoUpButton);
            this.PoiTabPage.Controls.Add(this.RemovePOIInfoButton);
            this.PoiTabPage.Controls.Add(this.AddPOIInfoButton);
            this.PoiTabPage.Controls.Add(this.POIInfoEndsTB);
            this.PoiTabPage.Controls.Add(this.POIInfoEndsLabel);
            this.PoiTabPage.Controls.Add(this.POIInfoStartsTB);
            this.PoiTabPage.Controls.Add(this.POIInfoStartsLabel);
            this.PoiTabPage.Controls.Add(this.POIInfoCatCombo);
            this.PoiTabPage.Controls.Add(this.POIInfoCatLabel);
            this.PoiTabPage.Controls.Add(this.POIInformationTB);
            this.PoiTabPage.Controls.Add(this.POIInfoLabel);
            this.PoiTabPage.Controls.Add(this.POIInfosLB);
            this.PoiTabPage.Controls.Add(this.POIsListLabel);
            this.PoiTabPage.Controls.Add(this.POIsLB);
            this.PoiTabPage.Location = new System.Drawing.Point(4, 24);
            this.PoiTabPage.Name = "PoiTabPage";
            this.PoiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PoiTabPage.Size = new System.Drawing.Size(826, 519);
            this.PoiTabPage.TabIndex = 0;
            this.PoiTabPage.Text = "POI";
            this.PoiTabPage.UseVisualStyleBackColor = true;
            // 
            // AutoPlayMediaCB
            // 
            this.AutoPlayMediaCB.AutoSize = true;
            this.AutoPlayMediaCB.Location = new System.Drawing.Point(326, 477);
            this.AutoPlayMediaCB.Name = "AutoPlayMediaCB";
            this.AutoPlayMediaCB.Size = new System.Drawing.Size(184, 19);
            this.AutoPlayMediaCB.TabIndex = 20;
            this.AutoPlayMediaCB.Text = "Spela upp medua automatiskt";
            this.AutoPlayMediaCB.UseVisualStyleBackColor = true;
            // 
            // MediaDescrTB
            // 
            this.MediaDescrTB.Location = new System.Drawing.Point(326, 448);
            this.MediaDescrTB.Name = "MediaDescrTB";
            this.MediaDescrTB.Size = new System.Drawing.Size(407, 23);
            this.MediaDescrTB.TabIndex = 19;
            // 
            // MediaDescLabel
            // 
            this.MediaDescLabel.AutoSize = true;
            this.MediaDescLabel.Location = new System.Drawing.Point(326, 430);
            this.MediaDescLabel.Name = "MediaDescLabel";
            this.MediaDescLabel.Size = new System.Drawing.Size(119, 15);
            this.MediaDescLabel.TabIndex = 18;
            this.MediaDescLabel.Text = "Beskrivning av media";
            // 
            // PickMediaFileButton
            // 
            this.PickMediaFileButton.Location = new System.Drawing.Point(648, 403);
            this.PickMediaFileButton.Name = "PickMediaFileButton";
            this.PickMediaFileButton.Size = new System.Drawing.Size(75, 23);
            this.PickMediaFileButton.TabIndex = 17;
            this.PickMediaFileButton.Text = "&Välj";
            this.PickMediaFileButton.UseVisualStyleBackColor = true;
            this.PickMediaFileButton.Click += new System.EventHandler(this.PickMediaFileButton_Click);
            // 
            // MediaFileTB
            // 
            this.MediaFileTB.Location = new System.Drawing.Point(326, 404);
            this.MediaFileTB.Name = "MediaFileTB";
            this.MediaFileTB.Size = new System.Drawing.Size(316, 23);
            this.MediaFileTB.TabIndex = 16;
            // 
            // MediaFileLabel
            // 
            this.MediaFileLabel.AutoSize = true;
            this.MediaFileLabel.Location = new System.Drawing.Point(326, 386);
            this.MediaFileLabel.Name = "MediaFileLabel";
            this.MediaFileLabel.Size = new System.Drawing.Size(50, 15);
            this.MediaFileLabel.TabIndex = 15;
            this.MediaFileLabel.Text = "&Mediafil";
            // 
            // MoveInfoDownButton
            // 
            this.MoveInfoDownButton.Location = new System.Drawing.Point(729, 127);
            this.MoveInfoDownButton.Name = "MoveInfoDownButton";
            this.MoveInfoDownButton.Size = new System.Drawing.Size(75, 23);
            this.MoveInfoDownButton.TabIndex = 24;
            this.MoveInfoDownButton.Text = "Flytta ner";
            this.MoveInfoDownButton.UseVisualStyleBackColor = true;
            this.MoveInfoDownButton.Click += new System.EventHandler(this.MoveInfoUpButton_Click);
            // 
            // MoveInfoUpButton
            // 
            this.MoveInfoUpButton.Location = new System.Drawing.Point(729, 98);
            this.MoveInfoUpButton.Name = "MoveInfoUpButton";
            this.MoveInfoUpButton.Size = new System.Drawing.Size(75, 23);
            this.MoveInfoUpButton.TabIndex = 23;
            this.MoveInfoUpButton.Text = "Flytta upp";
            this.MoveInfoUpButton.UseVisualStyleBackColor = true;
            this.MoveInfoUpButton.Click += new System.EventHandler(this.MoveInfoUpButton_Click);
            // 
            // RemovePOIInfoButton
            // 
            this.RemovePOIInfoButton.Location = new System.Drawing.Point(729, 53);
            this.RemovePOIInfoButton.Name = "RemovePOIInfoButton";
            this.RemovePOIInfoButton.Size = new System.Drawing.Size(75, 23);
            this.RemovePOIInfoButton.TabIndex = 22;
            this.RemovePOIInfoButton.Text = "&Ta bort";
            this.RemovePOIInfoButton.UseVisualStyleBackColor = true;
            this.RemovePOIInfoButton.Click += new System.EventHandler(this.RemovePOIInfoButton_Click);
            // 
            // AddPOIInfoButton
            // 
            this.AddPOIInfoButton.Location = new System.Drawing.Point(729, 21);
            this.AddPOIInfoButton.Name = "AddPOIInfoButton";
            this.AddPOIInfoButton.Size = new System.Drawing.Size(75, 23);
            this.AddPOIInfoButton.TabIndex = 21;
            this.AddPOIInfoButton.Text = "&Lägg till";
            this.AddPOIInfoButton.UseVisualStyleBackColor = true;
            this.AddPOIInfoButton.Click += new System.EventHandler(this.AddPOIInfoButton_Click);
            // 
            // POIInfoEndsTB
            // 
            this.POIInfoEndsTB.Location = new System.Drawing.Point(504, 360);
            this.POIInfoEndsTB.Name = "POIInfoEndsTB";
            this.POIInfoEndsTB.Size = new System.Drawing.Size(100, 23);
            this.POIInfoEndsTB.TabIndex = 10;
            // 
            // POIInfoEndsLabel
            // 
            this.POIInfoEndsLabel.AutoSize = true;
            this.POIInfoEndsLabel.Location = new System.Drawing.Point(501, 342);
            this.POIInfoEndsLabel.Name = "POIInfoEndsLabel";
            this.POIInfoEndsLabel.Size = new System.Drawing.Size(100, 15);
            this.POIInfoEndsLabel.TabIndex = 9;
            this.POIInfoEndsLabel.Text = "Aktiv till och med";
            // 
            // POIInfoStartsTB
            // 
            this.POIInfoStartsTB.Location = new System.Drawing.Point(326, 360);
            this.POIInfoStartsTB.Name = "POIInfoStartsTB";
            this.POIInfoStartsTB.Size = new System.Drawing.Size(170, 23);
            this.POIInfoStartsTB.TabIndex = 8;
            // 
            // POIInfoStartsLabel
            // 
            this.POIInfoStartsLabel.AutoSize = true;
            this.POIInfoStartsLabel.Location = new System.Drawing.Point(326, 342);
            this.POIInfoStartsLabel.Name = "POIInfoStartsLabel";
            this.POIInfoStartsLabel.Size = new System.Drawing.Size(108, 15);
            this.POIInfoStartsLabel.TabIndex = 7;
            this.POIInfoStartsLabel.Text = "Aktiv från och med";
            // 
            // POIInfoCatCombo
            // 
            this.POIInfoCatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.POIInfoCatCombo.FormattingEnabled = true;
            this.POIInfoCatCombo.Location = new System.Drawing.Point(326, 316);
            this.POIInfoCatCombo.Name = "POIInfoCatCombo";
            this.POIInfoCatCombo.Size = new System.Drawing.Size(212, 23);
            this.POIInfoCatCombo.TabIndex = 6;
            // 
            // POIInfoCatLabel
            // 
            this.POIInfoCatLabel.AutoSize = true;
            this.POIInfoCatLabel.Location = new System.Drawing.Point(326, 298);
            this.POIInfoCatLabel.Name = "POIInfoCatLabel";
            this.POIInfoCatLabel.Size = new System.Drawing.Size(51, 15);
            this.POIInfoCatLabel.TabIndex = 5;
            this.POIInfoCatLabel.Text = "&Kategori";
            // 
            // POIInformationTB
            // 
            this.POIInformationTB.Location = new System.Drawing.Point(326, 197);
            this.POIInformationTB.Multiline = true;
            this.POIInformationTB.Name = "POIInformationTB";
            this.POIInformationTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.POIInformationTB.Size = new System.Drawing.Size(397, 98);
            this.POIInformationTB.TabIndex = 4;
            // 
            // POIInfoLabel
            // 
            this.POIInfoLabel.AutoSize = true;
            this.POIInfoLabel.Location = new System.Drawing.Point(326, 179);
            this.POIInfoLabel.Name = "POIInfoLabel";
            this.POIInfoLabel.Size = new System.Drawing.Size(70, 15);
            this.POIInfoLabel.TabIndex = 3;
            this.POIInfoLabel.Text = "&Information";
            // 
            // POIInfosLB
            // 
            this.POIInfosLB.FormattingEnabled = true;
            this.POIInfosLB.ItemHeight = 15;
            this.POIInfosLB.Location = new System.Drawing.Point(326, 21);
            this.POIInfosLB.Name = "POIInfosLB";
            this.POIInfosLB.Size = new System.Drawing.Size(397, 154);
            this.POIInfosLB.TabIndex = 2;
            // 
            // POIsListLabel
            // 
            this.POIsListLabel.AutoSize = true;
            this.POIsListLabel.Location = new System.Drawing.Point(6, 3);
            this.POIsListLabel.Name = "POIsListLabel";
            this.POIsListLabel.Size = new System.Drawing.Size(98, 15);
            this.POIsListLabel.TabIndex = 1;
            this.POIsListLabel.Text = "Points Of Interest";
            // 
            // POIsLB
            // 
            this.POIsLB.FormattingEnabled = true;
            this.POIsLB.ItemHeight = 15;
            this.POIsLB.Location = new System.Drawing.Point(6, 21);
            this.POIsLB.Name = "POIsLB";
            this.POIsLB.Size = new System.Drawing.Size(315, 319);
            this.POIsLB.TabIndex = 0;
            // 
            // ExitsTabPabe
            // 
            this.ExitsTabPabe.Location = new System.Drawing.Point(4, 24);
            this.ExitsTabPabe.Name = "ExitsTabPabe";
            this.ExitsTabPabe.Padding = new System.Windows.Forms.Padding(3);
            this.ExitsTabPabe.Size = new System.Drawing.Size(826, 519);
            this.ExitsTabPabe.TabIndex = 1;
            this.ExitsTabPabe.Text = "Utgångar";
            this.ExitsTabPabe.UseVisualStyleBackColor = true;
            // 
            // VenueDescriptionLabel
            // 
            this.VenueDescriptionLabel.AutoSize = true;
            this.VenueDescriptionLabel.Location = new System.Drawing.Point(14, 268);
            this.VenueDescriptionLabel.Name = "VenueDescriptionLabel";
            this.VenueDescriptionLabel.Size = new System.Drawing.Size(68, 15);
            this.VenueDescriptionLabel.TabIndex = 13;
            this.VenueDescriptionLabel.Text = "&Beskrivning";
            // 
            // VenueDescriptionTB
            // 
            this.VenueDescriptionTB.AcceptsReturn = true;
            this.VenueDescriptionTB.Location = new System.Drawing.Point(14, 286);
            this.VenueDescriptionTB.Multiline = true;
            this.VenueDescriptionTB.Name = "VenueDescriptionTB";
            this.VenueDescriptionTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VenueDescriptionTB.Size = new System.Drawing.Size(278, 222);
            this.VenueDescriptionTB.TabIndex = 14;
            // 
            // VisibilityLabel
            // 
            this.VisibilityLabel.AutoSize = true;
            this.VisibilityLabel.Location = new System.Drawing.Point(14, 511);
            this.VisibilityLabel.Name = "VisibilityLabel";
            this.VisibilityLabel.Size = new System.Drawing.Size(157, 15);
            this.VisibilityLabel.TabIndex = 15;
            this.VisibilityLabel.Text = "Synlighet i listan över platser";
            // 
            // VisibilityCombo
            // 
            this.VisibilityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VisibilityCombo.FormattingEnabled = true;
            this.VisibilityCombo.Location = new System.Drawing.Point(14, 527);
            this.VisibilityCombo.Name = "VisibilityCombo";
            this.VisibilityCombo.Size = new System.Drawing.Size(177, 23);
            this.VisibilityCombo.TabIndex = 16;
            // 
            // OpenMediaFileDialog
            // 
            this.OpenMediaFileDialog.Filter = "|*.jpg;*.jpeg;*.png;*.pgif;*.wav;*.m4a;**.mp3|relifaideMBilder (*.jpg, *.jpeg, *." +
    "png)|*.jpg;*.jpeg;*.png|Ljudfiler (*.wav, *.mp3, *.m4a)|*.wav;*.m4a;*.mp3|Alla f" +
    "iler (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1129, 602);
            this.Controls.Add(this.VisibilityCombo);
            this.Controls.Add(this.VisibilityLabel);
            this.Controls.Add(this.VenueDescriptionTB);
            this.Controls.Add(this.VenueDescriptionLabel);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.CountryTB);
            this.Controls.Add(this.CountryLabel);
            this.Controls.Add(this.CityTB);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.ZipTB);
            this.Controls.Add(this.ZipLabel);
            this.Controls.Add(this.AddressTB);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.VenueIDTB);
            this.Controls.Add(this.VenueIDLabel);
            this.Controls.Add(this.VenueNameTB);
            this.Controls.Add(this.VenueNameLabel);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Venue Maker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VenueBS)).EndInit();
            this.Tabs.ResumeLayout(false);
            this.PoiTabPage.ResumeLayout(false);
            this.PoiTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.POIsBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POIInfosBS)).EndInit();
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
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressTB;
        private System.Windows.Forms.Label ZipLabel;
        private System.Windows.Forms.TextBox ZipTB;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.TextBox CityTB;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.TextBox CountryTB;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage PoiTabPage;
        private System.Windows.Forms.TabPage ExitsTabPabe;
        private System.Windows.Forms.ListBox POIsLB;
        private System.Windows.Forms.ListBox POIInfosLB;
        private System.Windows.Forms.Label POIsListLabel;
        private System.Windows.Forms.TextBox POIInformationTB;
        private System.Windows.Forms.Label POIInfoLabel;
        private System.Windows.Forms.Label POIInfoCatLabel;
        private System.Windows.Forms.ComboBox POIInfoCatCombo;
        private System.Windows.Forms.BindingSource POIsBS;
        private System.Windows.Forms.BindingSource POIInfosBS;
        private System.Windows.Forms.Label POIInfoStartsLabel;
        private System.Windows.Forms.TextBox POIInfoStartsTB;
        private System.Windows.Forms.Label POIInfoEndsLabel;
        private System.Windows.Forms.TextBox POIInfoEndsTB;
        private System.Windows.Forms.Button AddPOIInfoButton;
        private System.Windows.Forms.Button RemovePOIInfoButton;
        private System.Windows.Forms.Button MoveInfoUpButton;
        private System.Windows.Forms.Button MoveInfoDownButton;
        private System.Windows.Forms.ToolStripMenuItem pushToCloudMenuItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveVenueMenuItemToolStripMenuItem;
        private System.Windows.Forms.Label VenueDescriptionLabel;
        private System.Windows.Forms.TextBox VenueDescriptionTB;
        private System.Windows.Forms.Label MediaFileLabel;
        private System.Windows.Forms.TextBox MediaFileTB;
        private System.Windows.Forms.Button PickMediaFileButton;
        private System.Windows.Forms.Label MediaDescLabel;
        private System.Windows.Forms.TextBox MediaDescrTB;
        private System.Windows.Forms.Label VisibilityLabel;
        private System.Windows.Forms.ComboBox VisibilityCombo;
        private System.Windows.Forms.OpenFileDialog OpenMediaFileDialog;
        private System.Windows.Forms.CheckBox AutoPlayMediaCB;
    }
}