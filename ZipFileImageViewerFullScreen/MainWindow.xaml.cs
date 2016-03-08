using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZipFileImageViewerFullScreen
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
#if false
            AllocConsole();
#endif
            InitializeComponent();
#if false
            Closed += (sender, e) => FreeConsole();
#endif
            Loaded += MakeNoTaskbar;
        }

        protected override void ParentLayoutInvalidated(UIElement child)
        {
            base.ParentLayoutInvalidated(child);
            MakeNoTaskbar(null, null);
        }

        private void MakeNoTaskbar(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height;
        }

        private WindowState MinimizeCommand_GetCurrentState()
        {
            return WindowState;
        }

        private void MinimizeCommand_MinimizeAction()
        {
            WindowState = WindowState.Minimized;
        }

        private void WindowCloseCommand_CloseAction()
        {
            Close();
        }


#if false
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();
#endif
    }
}
