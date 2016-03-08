using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZipFileImageViewerFullScreen
{
    internal class ViewMode
    {
        public string ModeName { get; set; }
        public ScrollBarVisibility Horizontal { get; set; }
        public ScrollBarVisibility Vertical { get; set; }
        public Stretch Stretch { get; set; }

        public override string ToString()
        {
            return ModeName;
        }
    }
}
