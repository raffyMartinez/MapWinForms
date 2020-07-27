namespace MapWinForms.forms
{
    partial class LayersForm
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
            this.layerGrid = new System.Windows.Forms.DataGridView();
            this.Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Layer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewImageColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLayerProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLayerAttributes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddLayer = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layerGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // layerGrid
            // 
            this.layerGrid.AllowDrop = true;
            this.layerGrid.AllowUserToAddRows = false;
            this.layerGrid.AllowUserToDeleteRows = false;
            this.layerGrid.AllowUserToOrderColumns = true;
            this.layerGrid.AllowUserToResizeColumns = false;
            this.layerGrid.AllowUserToResizeRows = false;
            this.layerGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.layerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.layerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.layerGrid.ColumnHeadersVisible = false;
            this.layerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Visible,
            this.Layer,
            this.Symbol});
            this.layerGrid.ContextMenuStrip = this.contextMenu;
            this.layerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layerGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.layerGrid.Location = new System.Drawing.Point(0, 0);
            this.layerGrid.Name = "layerGrid";
            this.layerGrid.RowHeadersVisible = false;
            this.layerGrid.RowHeadersWidth = 51;
            this.layerGrid.RowTemplate.Height = 24;
            this.layerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.layerGrid.Size = new System.Drawing.Size(464, 450);
            this.layerGrid.TabIndex = 0;
            this.layerGrid.Resize += new System.EventHandler(this.MapLayersForm_Resize);
            // 
            // Visible
            // 
            this.Visible.HeaderText = "V";
            this.Visible.MinimumWidth = 6;
            this.Visible.Name = "Visible";
            this.Visible.Width = 20;
            // 
            // Layer
            // 
            this.Layer.HeaderText = "Name";
            this.Layer.MinimumWidth = 6;
            this.Layer.Name = "Layer";
            this.Layer.Width = 228;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.MinimumWidth = 6;
            this.Symbol.Name = "Symbol";
            this.Symbol.Width = 50;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(464, 450);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // ovalShape1
            // 
            this.ovalShape1.Location = new System.Drawing.Point(356, 224);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(57, 50);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRemoveLayer,
            this.menuLayerProperties,
            this.menuLayerAttributes,
            this.menuAddLayer});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(211, 128);
            // 
            // menuRemoveLayer
            // 
            this.menuRemoveLayer.Name = "menuRemoveLayer";
            this.menuRemoveLayer.Size = new System.Drawing.Size(210, 24);
            this.menuRemoveLayer.Text = "Remove layer";
            this.menuRemoveLayer.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // menuLayerProperties
            // 
            this.menuLayerProperties.Name = "menuLayerProperties";
            this.menuLayerProperties.Size = new System.Drawing.Size(210, 24);
            this.menuLayerProperties.Text = "Layer properties";
            this.menuLayerProperties.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // menuLayerAttributes
            // 
            this.menuLayerAttributes.Name = "menuLayerAttributes";
            this.menuLayerAttributes.Size = new System.Drawing.Size(210, 24);
            this.menuLayerAttributes.Text = "Layer attributes";
            this.menuLayerAttributes.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // menuAddLayer
            // 
            this.menuAddLayer.Name = "menuAddLayer";
            this.menuAddLayer.Size = new System.Drawing.Size(210, 24);
            this.menuAddLayer.Text = "Add layer";
            this.menuAddLayer.Click += new System.EventHandler(this.OnMenuClick);
            // 
            // LayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 450);
            this.Controls.Add(this.layerGrid);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LayersForm";
            this.Text = "LayersForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LayersForm_FormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.layerGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView layerGrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Layer;
        private System.Windows.Forms.DataGridViewImageColumn Symbol;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveLayer;
        private System.Windows.Forms.ToolStripMenuItem menuLayerProperties;
        private System.Windows.Forms.ToolStripMenuItem menuLayerAttributes;
        private System.Windows.Forms.ToolStripMenuItem menuAddLayer;
    }
}