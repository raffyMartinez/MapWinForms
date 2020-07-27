using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinForms.classes
{
    
    public class global
    {
        private static string _appPath = "";
       public static fad3MappingMode MappingMode { get; set; }

        static global()
        {
            _appPath = System.Windows.Forms.Application.StartupPath;
        }
        public static string ApplicationPath
        {
            get { return _appPath; }
        }
    }

}
