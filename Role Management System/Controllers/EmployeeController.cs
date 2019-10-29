using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Role_Management_System.DataServices.EmployeeServices;
using Role_Management_System.Models;

namespace Role_Management_System.Controllers
{
    [Authorize]
    [HandleError]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult EmployeeList()
        {
            EmployeeViewModel empList = new EmployeeViewModel();
            var List = empList.GetEmployee();
            return View(List);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel create = new EmployeeViewModel();
                create.CreateEmployee(employee);
                return RedirectToAction("EmployeeList", "Employee"); 
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            var getEmployee = emp.GetEmployeeById(Id);
            return View(getEmployee);
        }
        [HttpPost]
        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel update = new EmployeeViewModel();
                update.UpdateEmployee(emp);
                return RedirectToAction("EmployeeList", "Employee");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            EmployeeViewModel del = new EmployeeViewModel();
            var getEmp = del.GetEmployeeById(Id);
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel del = new EmployeeViewModel();
                 del.Delete(emp.Id);
                return RedirectToAction("EmployeeList", "Employee");
            }
            return View();
        }

	}
}