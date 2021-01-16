using System;
using EmpTracking.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpTracking.Controllers
{
    public class EmpDataController : Controller
    {
        private readonly IEmpDataRepository repo;

        public EmpDataController(IEmpDataRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var empdata = repo.GetAllEmpData();

            return View(empdata);

        }

        public IActionResult ViewEmpData(int id)
        {
            var empdata = repo.GetEmpData(id);
            return View(empdata);
        }

        public IActionResult UpdateEmpData(int id)
        {
            EmpList empdata = repo.GetEmpData(id);

            repo.UpdateEmpData(empdata);

            if (empdata == null)
            {
                return View("EmployeeNotFound");
            }

            return View(empdata);
        }

        public IActionResult UpdateEmpToDatabase(EmpList empdata)
        {
            repo.UpdateEmpData(empdata);

            return RedirectToAction("ViewEmpData", new { id = empdata.EmpDataID });
        }

        public IActionResult InsertEmpData()
        {
            var empdata = repo.AssignDepartment();

            return View(empdata);
        }

        public IActionResult InsertEmpToDatabase(EmpList employeeToInsert)
        {
            repo.InsertEmpData(employeeToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmpData(EmpList empdata)
        {
            repo.DeleteEmpData(empdata);

            return RedirectToAction("Index");
        }

    }
}
