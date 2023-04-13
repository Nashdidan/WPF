using MVVMDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    public class UControllCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        public Action action;

        public bool CanExecute(object parameter) => true;
        public UControllCommand(Action ac)
        {
            action = ac;
        }
        public void Execute(object parameter)
        {
            switch (parameter.ToString() )
            {
                case "Button":
                    action.Invoke();
                    break;
                default:
                    break;
            }
        }


    }
}
