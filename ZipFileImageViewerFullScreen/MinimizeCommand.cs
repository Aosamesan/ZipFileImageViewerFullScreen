using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZipFileImageViewerFullScreen
{
    internal class MinimizeCommand : RelayCommand
    {
        public event Func<WindowState> GetCurrentState;
        public event Action MinimizeAction;

        public override bool CanExecute(object parameter)
        {
            return GetCurrentState?.Invoke() != WindowState.Minimized;
        }

        public override void Execute(object parameter)
        {
            MinimizeAction?.Invoke();
        }
    }
}
