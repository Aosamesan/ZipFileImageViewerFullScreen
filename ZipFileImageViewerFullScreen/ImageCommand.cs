using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileImageViewerFullScreen
{
    internal class ImageCommand : RelayCommand
    {
        public event Func<bool> CanExecuteAction;
        public event Action ExecuteAction;

        public override bool CanExecute(object parameter)
        {
            if (CanExecuteAction?.Invoke() == true)
                return true;
            return false;
        }

        public override void Execute(object parameter)
        {
            ExecuteAction?.Invoke();
        }
    }
}
