namespace MapWinForms
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLayers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLayersDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMapSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPan = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.mapControl = new AxMapWinGIS.AxMap();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLayers,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuLayers
            // 
            this.menuLayers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddLayer,
            this.menuLayersDialog});
            this.menuLayers.Name = "menuLayers";
            this.menuLayers.Size = new System.Drawing.Size(133, 26);
            this.menuLayers.Text = "Layers";
            // 
            // menuAddLayer
            // 
            this.menuAddLayer.Name = "menuAddLayer";
            this.menuAddLayer.Size = new System.Drawing.Size(180, 26);
            this.menuAddLayer.Text = "Add layer";
            this.menuAddLayer.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // menuLayersDialog
            // 
            this.menuLayersDialog.Name = "menuLayersDialog";
            this.menuLayersDialog.Size = new System.Drawing.Size(180, 26);
            this.menuLayersDialog.Text = "Layers dialog";
            this.menuLayersDialog.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(133, 26);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuZoomIn,
            this.menuZoomOut,
            this.menuMapSelect,
            this.menuPan});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // menuZoomIn
            // 
            this.menuZoomIn.Name = "menuZoomIn";
            this.menuZoomIn.Size = new System.Drawing.Size(158, 26);
            this.menuZoomIn.Text = "Zoom in";
            this.menuZoomIn.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // menuZoomOut
            // 
            this.menuZoomOut.Name = "menuZoomOut";
            this.menuZoomOut.Size = new System.Drawing.Size(158, 26);
            this.menuZoomOut.Text = "Zoom out";
            this.menuZoomOut.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // menuMapSelect
            // 
            this.menuMapSelect.Name = "menuMapSelect";
            this.menuMapSelect.Size = new System.Drawing.Size(158, 26);
            this.menuMapSelect.Text = "Select";
            this.menuMapSelect.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // menuPan
            // 
            this.menuPan.Name = "menuPan";
            this.menuPan.Size = new System.Drawing.Size(158, 26);
            this.menuPan.Text = "Pan";
            this.menuPan.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // mapControl
            // 
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.Enabled = true;
            this.mapControl.Location = new System.Drawing.Point(0, 28);
            this.mapControl.Name = "mapControl";
            this.mapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mapControl.OcxState")));
            this.mapControl.Size = new System.Drawing.Size(800, 422);
            this.mapControl.TabIndex = 2;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mapControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindowForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLayers;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuAddLayer;
        private System.Windows.Forms.ToolStripMenuItem menuLayersDialog;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuZoomIn;
        private System.Windows.Forms.ToolStripMenuItem menuZoomOut;
        private System.Windows.Forms.ToolStripMenuItem menuMapSelect;
        private System.Windows.Forms.ToolStripMenuItem menuPan;
        private System.Windows.Forms.OpenFileDialog dialogFileOpen;
        private AxMapWinGIS.AxMap mapControl;
    }
}

