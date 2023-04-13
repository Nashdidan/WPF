using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MVVMDemo.Models;
using MVVMDemo.Commands;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace MVVMDemo.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        EmployeeService EmployeeService { get; set; }
        public EmployeeViewModel()
        {
            EmployeeService = new EmployeeService();
            LoadData();
            currentEmployee = new Employee();
            SaveCommand = new ButtonCommand(SaveData);
            UpdateCommand = new ButtonCommand(() => { EmployeeService.Update(CurrentEmployee); });
            SearchCommand = new ButtonCommand(Search);
            EmployeeService.MessageSent += (o, s) => { Message = s; Console.WriteLine("whhhhattttttt"); };

            MyCollectionView = CollectionViewSource.GetDefaultView(Employees);
            MyCollectionView.Filter = item => ((Employee)item).Id > 30;
            MyCollectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

        }


        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged("Employees"); }
        }

        private void LoadData()
        {
            Employees = new ObservableCollection<Employee>(EmployeeService.GetAll());
            UpdateProgress();
        }

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        public ButtonCommand SearchCommand { get; }



        public ButtonCommand SaveCommand { get; }
        public ButtonCommand UpdateCommand { get; }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


        private void SaveData()
        {
            try
            {
                bool isSaved = EmployeeService.AddEmployee(new Employee { Age = currentEmployee.Age, Id=currentEmployee.Id, Name=currentEmployee.Name});
                LoadData();

                if (isSaved)
                {
                    message = "saved bitch";
                }
                else { message = "nahhhh not saved"; }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private float progress;

        public float Progress
        {
            get { return progress; }
            set { progress = value; OnPropertyChanged("Progress"); }
        }

        private void UpdateProgress()
        {
            float n = employees.Count();
            Progress = (n / 10) * 100 ;
            if(Progress >= 100)
            {
                Message = "you reached the limit boy";
            }
        }
        private ICollectionView _myCollectionView;
        public ICollectionView MyCollectionView
        {
            get { return _myCollectionView; }
            set
            {
                _myCollectionView = value;
                OnPropertyChanged(nameof(MyCollectionView));
            }
        }

        public void Search()
        {
            try
            {
                var employee = EmployeeService.Search(currentEmployee.Id);
                if(employee != null)
                {
                    Message = "employee found";
                    CurrentEmployee = employee;
                }
                else
                {
                    Message = "employee not found";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }

    }
}
