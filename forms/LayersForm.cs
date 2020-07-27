using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinForms.classes;
using MapWinGIS;

namespace MapWinForms.forms
{
    public partial class LayersForm : Form
    {
        private int _layerRow;
        private int _layerCol;
        private static LayersForm _instance;
        private MainWindowForm _parent;
        private MapLayersHandler _mapLayersHandler;
        private int _layerHandle;
        private int _rowIndexFromMouseDown;
        private Rectangle _dragBoxFromMouseDown;
        private int _rowIndexOfItemUnderMouseToDrop;
        public LayersForm(MapLayersHandler mapLayers, MainWindowForm parent)
        {
            InitializeComponent();
            _parent = parent;
            _mapLayersHandler = mapLayers;
            _mapLayersHandler.LayerRead += OnLayerRead;
            _mapLayersHandler.LayerRemoved += OnLayerDeleted;
            _mapLayersHandler.OnLayerNameUpdate += OnLayerNameUpdated;
            _mapLayersHandler.LayerRefreshNeeded += OnLayerRefreshRequest;
            layerGrid.CellClick += OnCellClick;
            layerGrid.CellMouseDown += OnCellMouseDown;
            layerGrid.CellDoubleClick += OnCellDoubleClick;
            layerGrid.DragDrop += OnLayerGrid_DragDrop;
            layerGrid.DragOver += OnLayerGrid_DragOver;
            layerGrid.MouseDown += OnLayerGrid_MouseDown;
            layerGrid.MouseMove += OnLayerGrid_MouseMove;
        }

        private void OnLayerGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (_dragBoxFromMouseDown != Rectangle.Empty &&
                !_dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.
                    DragDropEffects dropEffect = layerGrid.DoDragDrop(
                          layerGrid.Rows[_rowIndexFromMouseDown],
                          DragDropEffects.Move);
                }
            }
        }

        public void ShapefileLayerPropertyChanged()
        {
            MainForm.MapControl.Redraw();
            _mapLayersHandler.RefreshMap();
            RefreshLayerList();
        }
        private void OnLayerGrid_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            _rowIndexFromMouseDown = layerGrid.HitTest(e.X, e.Y).RowIndex;

            if (e.Button == MouseButtons.Right)
            {
                //itemAddLayer.Visible = true;
                //itemRemoveLayer.Visible = true;
                //itemLayerProperty.Visible = true;
                //if (_rowIndexFromMouseDown == -1)
                //{
                //    itemRemoveLayer.Visible = false;
                //    itemLayerProperty.Visible = false;
                //}
                //menuLayers.Show(layerGrid, e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Left && _rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred.
                // The DragSize indicates the size that the mouse can move
                // before a drag event should be started.
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                _dragBoxFromMouseDown = new Rectangle(
                          new System.Drawing.Point(
                            e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)),
                      dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                _dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void OnLayerGrid_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void OnLayerGrid_DragDrop(object sender, DragEventArgs e)
        {
            int layerHandle = 0;

            // The mouse locations are relative to the screen, so they must be
            // converted to client coordinates.
            System.Drawing.Point clientPoint = layerGrid.PointToClient(new System.Drawing.Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.
            _rowIndexOfItemUnderMouseToDrop = layerGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (_rowIndexOfItemUnderMouseToDrop < 0)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                    layerGrid.Rows.RemoveAt(_rowIndexFromMouseDown);
                    layerGrid.Rows.Insert(_rowIndexOfItemUnderMouseToDrop, rowToMove);

                    for (int row = 0; row < layerGrid.RowCount; row++)
                    {
                        if (row > 0)
                        {
                            layerHandle = (int)layerGrid[0, row].Tag;
                            var pos = _mapLayersHandler.get_LayerPosition(layerHandle);
                            _mapLayersHandler.MoveLayerBottom(pos);
                        }
                    }
                    _mapLayersHandler.RefreshMap();
                }
            }
        }

        public MainWindowForm MainForm
        {
            get { return _parent; }
        }
        public MapLayersHandler MapLayers
        {
            get { return _mapLayersHandler; }
        }
        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //we only respond to double-click on the name column
            if (e.ColumnIndex == 1)
            {
                int layerHandle = (int)layerGrid[0, _rowIndexFromMouseDown].Tag;
                if (MapLayers[layerHandle].IsGraticule)
                {
                }
                else
                {
                    ShowLayerProperties();
                }
            }
        }
        private void OnCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //menuLayers.Show(layerGrid, e.X, e.Y);
                _rowIndexFromMouseDown = e.RowIndex;
            }
        }
        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            _layerHandle = (int)layerGrid[0, e.RowIndex].Tag;
            if (e.ColumnIndex == 0)
            {
                bool isVisible = (bool)layerGrid[0, e.RowIndex].Value;
                layerGrid[0, e.RowIndex].Value = !isVisible;
                var layerName = layerGrid[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                _mapLayersHandler.EditLayer(_layerHandle, layerName, !isVisible);
            }

            if (e.ColumnIndex == 1)
            {
                MarkCurrentLayerName(e.RowIndex);
                _mapLayersHandler.set_MapLayer(_layerHandle);
                //itemConvertToGrid25.Enabled = false;
                //itemAlwaysKeepOnTop.Checked = _mapLayersHandler.CurrentMapLayer.KeepOnTop;
                if (global.MappingMode == fad3MappingMode.grid25Mode)
                {
                    if (_mapLayersHandler.CurrentMapLayer.LayerType == "ShapefileClass")
                    {
                        var sf = _mapLayersHandler.CurrentMapLayer.LayerObject as Shapefile;
                        //itemConvertToGrid25.Enabled = sf.ShapefileType == ShpfileType.SHP_POINT;
                    }
                }
            }
        }
        public void RefreshLayerList()
        {
            layerGrid.Rows.Clear();
            _mapLayersHandler.ReadLayers();
            MarkCurrentLayerName(CurrentLayerRow());
        }
        private void OnLayerRefreshRequest(object sender, EventArgs e)
        {
            RefreshLayerList();
        }
        private void OnLayerDeleted(MapLayersHandler s, LayerEventArg e)
        {
            for (int n = 0; n < layerGrid.Rows.Count; n++)
            {
                if ((int)layerGrid[0, n].Tag == e.LayerHandle)
                {
                    layerGrid.Rows.Remove(layerGrid.Rows[n]);
                }
            }
        }
        private void OnLayerNameUpdated(MapLayersHandler s, LayerEventArg e)
        {
            layerGrid[_layerCol, _layerRow].Value = e.LayerName;
        }
        public static LayersForm GetInstance(MapLayersHandler mapLayers, MainWindowForm parent)
        {
            if (_instance == null) _instance = new LayersForm( mapLayers, parent);
            return _instance;
        }

        private void OnLayerRead(MapLayersHandler mapLayersHandler, LayerEventArg e)
        {
            if (e.ShowInLayerUI)
            {

                //set the layer preview thumbnail
                PictureBox pic = new PictureBox
                {
                    Height = layerGrid.RowTemplate.Height-2,
                    Width = layerGrid.Columns[2].Width,
                    Visible = false
                };
                _mapLayersHandler.LayerSymbol(e.LayerHandle, pic, e.LayerType);

                if (!_mapLayersHandler[e.LayerHandle].IsMaskLayer)
                {
                    layerGrid.Invoke((MethodInvoker)delegate
                    {
                        //we always insert a new layer in the first row of the dataGrid
                        layerGrid.Rows.Insert(0, new object[] { e.LayerVisible, e.LayerName, pic.Image });

                        //we assign the layerhandle to the tag of cell 0,0
                        layerGrid[0, 0].Tag = e.LayerHandle;

                        //symbolize the current layer by making it bold font
                        MarkCurrentLayerName(CurrentLayerRow());
                    });
                }
            }
        }
        private void MapLayersForm_Resize(object sender, EventArgs e)
        {
            var gridWidth = layerGrid.Width;
            var col0Width = layerGrid.Columns[0].Width;
            var col2Width = layerGrid.Columns[2].Width;
            layerGrid.Columns[1].Width = gridWidth - 3 - (col0Width + col2Width);
        }
        private int CurrentLayerRow()
        {
            if (_mapLayersHandler.CurrentMapLayer != null)
            {
                int currentLayerHandle = _mapLayersHandler.CurrentMapLayer.Handle;
                foreach (DataGridViewRow item in layerGrid.Rows)
                {
                    if ((int)item.Cells[0].Tag == currentLayerHandle)
                    {
                        return item.Index;
                    }
                }
            }
            return 0;
        }
        private void MarkCurrentLayerName(int currentRow)
        {
            if (layerGrid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in layerGrid.Rows)
                {
                    row.Cells[1].Style.Font = new Font(Font.FontFamily.Name, Font.Size, FontStyle.Regular);
                }
                layerGrid[1, currentRow].Style.Font = new Font(Font.FontFamily.Name, Font.Size, FontStyle.Bold);
            }
        }
        private void LayersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
            _mapLayersHandler.LayerRead -= OnLayerRead;
        }




        private void OnFormLoad(object sender, EventArgs e)
        {
            _mapLayersHandler.ReadLayers();
            layerGrid.DefaultCellStyle.SelectionBackColor = SystemColors.Window;
            layerGrid.DefaultCellStyle.SelectionForeColor = SystemColors.WindowText;
        }
        private void ShowLayerProperties()
        {
            var lpf = LayerPropertyForm.GetInstance(this, (int)layerGrid[0, _rowIndexFromMouseDown].Tag);
            if (!lpf.Visible)
            {
                lpf.Show(this);
            }
            else
            {
                lpf.BringToFront();
            }
        }
        private void OnMenuClick(object sender, EventArgs e)
        {
            switch(((ToolStripMenuItem)sender).Name)
            {
                case "menuAddLayer":
                    _parent.AddLayer();
                    break;
                case "menuLayerProperties":
                    ShowLayerProperties();
                    break;
                case "menuLayerAttributes":
                    var sfa = ShapefileAttributesForm.GetInstance(_parent, _parent.MapInterActionHandler);
                    if (!sfa.Visible)
                    {
                        sfa.Show(this);
                    }
                    else
                    {
                        sfa.BringToFront();
                    }
                    break;
                case "menuRemoveLayer":
                    MapLayers.RemoveLayer((int)layerGrid[0, _rowIndexFromMouseDown].Tag);
                    break;
            }
        }
    }
}
