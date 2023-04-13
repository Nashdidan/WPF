using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    public class EmployeeService
    {
        public event EventHandler<string> MessageSent;
        private static List<Employee> employeeList;

        public EmployeeService()
        {
            employeeList = new List<Employee>()
            {
                new Employee(){Id=0, Age=19, Name="JOJO"}
            };
        }
        public bool AddEmployee(Employee employee)
        {
            bool isEmployeeAdded = false;
            if (employeeList.Any((e) => e.Id == employee.Id) && (employee.Age < 21 || employee.Age > 58)) 
            {
                MessageSent.Invoke(this, "!!!not added!!!!");
                return isEmployeeAdded; 
            }
            employeeList.Add(employee); 
            isEmployeeAdded = true;
            MessageSent.Invoke(this, $"this is list count {employeeList.Count()}");
            return isEmployeeAdded;
        }

        public List<Employee> GetAll()
        {
            return employeeList;
        }

        public bool Update(Employee employee)
        {
            bool isUpdated = false;

            int index = employeeList.FindIndex(e => e.Id == employee.Id);
            if (index != -1)
            {
                employeeList[index].Age = employee.Age;
                employeeList[index].Name = employee.Name;
                isUpdated = true;
                MessageSent.Invoke(this, "yaaa shiling update");
            }
            return isUpdated;
        }

        public bool Delete(Employee employee) 
        {
            bool isDeleted = false;
            int index = employeeList.FindIndex(e => e.Id == employee.Id);
            if (index != -1)
            {
                employeeList.RemoveAt(index);
                isDeleted = true;
            }
            return isDeleted;
        }

        public Employee Search(int id)
        {
            var em = employeeList.FirstOrDefault(e => e.Id == id);
            if (em != null)
            {
                return new Employee() { Age = em.Age, Id = em.Id, Name = em.Name };
            }
            return null;

        }
    }
}
