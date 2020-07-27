
using MapWinGIS;

namespace MapWinForms.classes
{
    public class ClassifiedItem
    {
        public string Caption { get; set; }
        public ShapeDrawingOptions DrawingOptions { get; set; }
        public float PointSize { get; set; }
        public uint FillColor { get; set; }

        public ClassifiedItem(string caption)
        {
            Caption = caption;
        }
    }
}