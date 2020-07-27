using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinForms.forms;
using MapWinForms.classes;
namespace MapWinForms
{
    public partial class MainWindowForm : Form
    {
        private MapLayer _currentMapLayer;
        private LayersForm _layersForm;
        private MapLayersHandler _mapLayersHandler;
        private MapInterActionHandler _mapInterActionHandler;

        public MapInterActionHandler MapInterActionHandler { get { return _mapInterActionHandler; } }
        public MainWindowForm()
        {
            InitializeComponent();
        }

        private void Cleanup()
        {
            _mapLayersHandler.Dispose();
            _mapInterActionHandler.Dispose();
        }
        public MapLayersHandler MapLayersHandler
        {
            get { return _mapLayersHandler; }
        }
        public AxMapWinGIS.AxMap MapControl
        {
            get { return mapControl; }
        }
        private void OnMenuItemClick(object sender, EventArgs e)
        {
            switch(((ToolStripMenuItem)sender).Name)
            {
                case "menuPan":
                    MapControl.CursorMode = MapWinGIS.tkCursorMode.cmPan;
                    break;
                case "menuAddLayer":
                    AddLayer();
                    break;
                case "menuLayersDialog":
                    _layersForm = LayersForm.GetInstance( _mapLayersHandler, this);
                    if (!_layersForm.Visible)
                    {
                        _layersForm.Disposed += OnLayersFormDisposed;
                        _layersForm.Show(this);
                        menuAddLayer.Enabled = true;
                    }
                    else
                    {
                        _layersForm.BringToFront();
                        _layersForm.Focus();
                    }
                    break;
                case "menuExit":
                    Close();
                    break;
                case "menuZoomin":
                    MapControl.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
                    break;
                case "menuZoomout":
                    MapControl.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
                    break;
                case "menuMapSelect":
                    mapControl.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
                    break;
            }
        }

        public void AddLayer()
        {
            dialogFileOpen.Title = "Add a layer";
            dialogFileOpen.Filter = "Shapefile|*.shp|Image file|*.jpg;*.tif";
            dialogFileOpen.FilterIndex = 0;
            DialogResult dr = dialogFileOpen.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                var fileName = dialogFileOpen.FileName;
                var result = _mapLayersHandler.FileOpenHandler(fileName);
                if (!result.success)
                {
                    MessageBox.Show(result.errMsg);
                }
            }
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            _mapLayersHandler = new MapLayersHandler(mapControl);
            _mapLayersHandler.TilesVisible = false;
            _mapInterActionHandler = new MapInterActionHandler(mapControl, _mapLayersHandler);
            
        }
        private void OnCurrentMapLayer(MapLayersHandler s, LayerEventArg e)
        {
            _currentMapLayer = _mapLayersHandler.get_MapLayer(e.LayerHandle);
        }
        private void OnLayersFormDisposed(object sender, EventArgs e)
        {

            //_mapLayersHandler = new MapLayersHandler(this.mapControl);
            //_mapLayersHandler.CurrentLayer += OnCurrentMapLayer;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Cleanup();
        }
    }
}
