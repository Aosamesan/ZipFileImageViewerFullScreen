using System;
using System.Collections.Generic;
using System.Linq;
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
    /// ContentControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContentControl : UserControl
    {
        public ContentControl()
        {
            InitializeComponent();
        }

        private bool PrevImage_CanExecuteAction()
        {
            return ImageList.SelectedIndex > 0;
        }

        private void PrevImage_ExecuteAction()
        {
            ImageList.SelectedIndex = ImageList.SelectedIndex - 1;
        }

        private bool NextImage_CanExecuteAction()
        {
            return ImageList.SelectedIndex < ImageList.Items.Count - 1;
        }

        private void NextImage_ExecuteAction()
        {
            ImageList.SelectedIndex = ImageList.SelectedIndex + 1;
        }

        private void ImageCollectionViewModel_AfterFileOpened()
        {
            if (ImageList.Items.Count > 0)
                ImageList.SelectedIndex = 0;
        }
    }
}
