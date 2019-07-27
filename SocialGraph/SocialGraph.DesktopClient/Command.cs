using System;
using System.Windows.Input;

namespace SocialGraph.DesktopClient
{
    public delegate void Function(object param);
    public class Command: ICommand
    {
        public Command(Function Param)
        {
            func += Param;
        }

        public void Execute(object parameter = null)
        {
            func(parameter);
        }

        public bool CanExecute(object parameter = null)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        private Function func;
    }
}