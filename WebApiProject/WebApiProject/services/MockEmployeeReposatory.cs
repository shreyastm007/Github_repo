using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.model;
using WebApiProject.repo;

namespace WebApiProject.services
{
   
public class MockEmployeeRepository : IEmployeeRepository
{


    public List<Employee> _employee = new List<Employee>();
    public MockEmployeeRepository() {
        _employee.Add(new Employee() { Id = 1, Name = "Shreyas", Phone = 2343, Place = "Hassan" });
        _employee.Add(new Employee() { Id = 2, Name = "Avi", Phone = 4567, Place = "Tumkur" });
        _employee.Add(new Employee() { Id = 3, Name = "Namana", Phone = 8765, Place = "Bangalore" });
        _employee.Add(new Employee() { Id = 4, Name = "Akshata", Phone = 5647, Place = "Mangalore" });

    }

    public Employee Add(Employee employee) {
        employee.Id = _employee.Max(e => e.Id) + 1;
        _employee.Add(employee);
        return employee;
    }

    public Employee Delete(int id) {
        Employee employee = _employee.FirstOrDefault(e => e.Id == id);
        if (employee != null) {
            _employee.Remove(employee);
        }
        return employee;
    }

    public IEnumerable<Employee> GetAllEmployee() {
        return _employee;
    }

    public Employee GetEmployee(int id) {
        return _employee.FirstOrDefault(e => e.Id == id);
    }

    public Employee Update(Employee employeeUpdated) {
        Employee employee = _employee.FirstOrDefault(e => e.Id == employeeUpdated.Id);
        if (employee != null) {
            employee.Name = employeeUpdated.Name;
            employee.Phone = employeeUpdated.Phone;
            employee.Place = employeeUpdated.Place;
        }
        return employee;
    }
}

}