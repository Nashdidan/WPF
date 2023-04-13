using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action function;

        public ButtonCommand(Action func)
        {
            function = func;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            function();
        }
    }
}
