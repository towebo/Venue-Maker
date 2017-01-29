namespace WayfindR
{
    partial class Form1
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
            this.OpenGraphMLDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadButton = new System.Windows.Forms.Button();
            this.NodesBS = new System.Windows.Forms.BindingSource(this.components);
            this.SourceCB = new System.Windows.Forms.ComboBox();
            this.TargetCB = new System.Windows.Forms.ComboBox();
            this.CalcRouteButton = new System.Windows.Forms.Button();
            this.PathBS = new System.Windows.Forms.BindingSource(this.components);
            this.RouteLB = new System.Windows.Forms.ListBox();
            this.TargetNodesBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NodesBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PathBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetNodesBS)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenGraphMLDialog
            // 
            this.OpenGraphMLDialog.DefaultExt = "graphml";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 34);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "&Load data";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SourceCB
            // 
            this.SourceCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceCB.FormattingEnabled = true;
            this.SourceCB.Location = new System.Drawing.Point(12, 79);
            this.SourceCB.Name = "SourceCB";
            this.SourceCB.Size = new System.Drawing.Size(289, 21);
            this.SourceCB.TabIndex = 1;
            // 
            // TargetCB
            // 
            this.TargetCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetCB.FormattingEnabled = true;
            this.TargetCB.Location = new System.Drawing.Point(12, 106);
            this.TargetCB.Name = "TargetCB";
            this.TargetCB.Size = new System.Drawing.Size(289, 21);
            this.TargetCB.TabIndex = 2;
            // 
            // CalcRouteButton
            // 
            this.CalcRouteButton.Location = new System.Drawing.Point(105, 34);
            this.CalcRouteButton.Name = "CalcRouteButton";
            this.CalcRouteButton.Size = new System.Drawing.Size(75, 23);
            this.CalcRouteButton.TabIndex = 3;
            this.CalcRouteButton.Text = "&Calc";
            this.CalcRouteButton.UseVisualStyleBackColor = true;
            this.CalcRouteButton.Click += new System.EventHandler(this.CalcRouteButton_Click);
            // 
            // RouteLB
            // 
            this.RouteLB.FormattingEnabled = true;
            this.RouteLB.Location = new System.Drawing.Point(12, 133);
            this.RouteLB.Name = "RouteLB";
            this.RouteLB.Size = new System.Drawing.Size(289, 147);
            this.RouteLB.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 309);
            this.Controls.Add(this.RouteLB);
            this.Controls.Add(this.CalcRouteButton);
            this.Controls.Add(this.TargetCB);
            this.Controls.Add(this.SourceCB);
            this.Controls.Add(this.LoadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NodesBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PathBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetNodesBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenGraphMLDialog;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.BindingSource NodesBS;
        private System.Windows.Forms.ComboBox SourceCB;
        private System.Windows.Forms.ComboBox TargetCB;
        private System.Windows.Forms.Button CalcRouteButton;
        private System.Windows.Forms.BindingSource PathBS;
        private System.Windows.Forms.ListBox RouteLB;
        private System.Windows.Forms.BindingSource TargetNodesBS;
    }
}

