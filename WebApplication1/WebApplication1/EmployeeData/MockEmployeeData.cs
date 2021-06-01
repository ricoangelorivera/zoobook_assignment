using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUDDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {

        private List<Employee> employees = new List<Employee>()
        {

            new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Gabriel",
                MiddleName = "Scott",
                LastName = "Cruz"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();

            employees.Add(employee);

            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.MiddleName = employee.MiddleName;
            existingEmployee.LastName = employee.LastName;

            return existingEmployee;

        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
