using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ZipFileImageViewerFullScreen
{
    internal class OpenCommand : RelayCommand
    {
        public Action<string> OpenZipFileAction;

        public OpenCommand(Action<string> openZipFileAction)
        {
            OpenZipFileAction = openZipFileAction;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip File (*zip)|*.zip";

            if(ofd.ShowDialog() == true)
            {
                OpenZipFileAction?.Invoke(ofd.FileName);
            }
        }
    }
}
