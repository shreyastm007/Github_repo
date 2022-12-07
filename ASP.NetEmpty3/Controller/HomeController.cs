using ASP.NetEmpty3.Model;
using ASP.NetEmpty3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreempty.controller
{

        [Route("[controller]")]
    public class HomeController : Controller {
        public IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }


        [Route("")]
        [Route("[action]")] 
        [Route("Index/{id?}")]
        public string Index(int? id) {
            return _employeeRepository.GetEmployee(id??1).name;
        }


        [Route("~/")]
        [Route("Details/{id?}")]
        //public ViewResult Details(int? id) {
        //    HomeDetailsViewModel homeEmployeeDetails = new HomeDetailsViewModel() {
        //        Employee = _employeeRepository.GetEmployee(id ?? 2),
        //        Title = "Details of Employee"
        //    };
        //    return View(homeEmployeeDetails);
        //}


        public ViewResult Details(int? id) {
            HomeDetailsViewModel homeEmployeeDetails = new HomeDetailsViewModel() {

                Employee = _employeeRepository.GetEmployee(id ?? 2),
                Title = "Details of Employee"
            };
            if (homeEmployeeDetails.Employee == null) {
                return View("ErrorPage");
            }
            else {
                return View(homeEmployeeDetails);
            }
        }


        public ViewResult ErrorPage() {
            return View();
        }



        [Route("Details1")]
        public IActionResult Details1() {
            var modal = _employeeRepository.GetAllEmployee();
            return View(modal);
        }

        [Route("EnvTest")]
        public ViewResult EnvTest() {
            return View();
        }    
    }
}
