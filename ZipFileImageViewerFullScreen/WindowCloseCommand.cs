using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileImageViewerFullScreen
{
    internal class WindowCloseCommand : RelayCommand
    {
        public event Action CloseAction;

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CloseAction?.Invoke();
        }
    }
}
