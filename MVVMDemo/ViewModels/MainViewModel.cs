using MVVMDemo.Commands;
using MVVMDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainViewModel()
        {
            UserControls = new ObservableCollection<FrameworkElement>();
            UserControllComand = new UControllCommand(GetUserControll);   
        }

        public UControllCommand UserControllComand { get; }

        public ObservableCollection<FrameworkElement> UserControls { get; set; }
        
        private void GetUserControll()
        {
            UserControls.Clear();
            UserControls.Add( new EmployeeView());
        }
    }
}
