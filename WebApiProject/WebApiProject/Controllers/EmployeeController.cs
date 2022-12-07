using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.model;
using WebApiProject.repo;
using Microsoft.Extensions.DependencyInjection;
using WebApiProject.Controllers;
using WebApiProject.services;
using System.Web.Http.Cors;

namespace WebApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController : ControllerBase
    {

        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }



        [HttpGet]
        [Route("Test/Get")]
        public int test() {
            return 20;
        }


        [HttpGet]
        [Route("Employee/Get")]
        public IEnumerable<Employee> GetEmployees() {
            return _employeeRepository.GetAllEmployee();
        }



        [HttpGet]
        [Route("Employee/Get/{id}")]
        public Employee GetEmployeeById(int id) {
            return _employeeRepository.GetEmployee(id);
        }


        [HttpPost]
        [Route("Employee/Post")]
        public Employee AddEmployee(Employee employee) {
         var newemployee= _employeeRepository.Add(employee);
            return newemployee;
        } //hardcoded so not executable


        [HttpDelete]
        [Route("Employee/Delete/{id}")]
        public Employee DeleteEmployee(int id) {
            var deleteemployee=_employeeRepository.Delete(id);
            return deleteemployee;
        }


    }
    }




