using labQuiz_TARATHEP_ORA03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace labQuiz_TARATHEP_ORA03.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();


        public ActionResult employeeJson()
        {

            var data = db.employees.ToList();

            return Json(data,JsonRequestBehavior.AllowGet);
        }

        // GET: Employee
        public ActionResult Index()
        {
            var data = db.employees.ToList();
            data = null;
            return View();
        }

        public ActionResult Details(int? id)
        {
           
            return View(db.employees.Find(id));
        }

        public ActionResult Create()
        {
            ViewData["title_dl"] = new SelectList(db.titles.Select(p=>p.title_name));
            ViewData["gen_dl"] = new SelectList(db.genders, "gender_id", "gender_description");
            ViewData["department_dl"] = new SelectList(db.departments.Select(p => p.dept_name));
            return View();
        }

        [HttpPost]
        public ActionResult Create(employee emp)
        {
            ViewData["title_dl"] = new SelectList(db.titles.Select(p => p.title_name));
            ViewData["gen_dl"] = new SelectList(db.genders, "gender_id", "gender_description");
            ViewData["department_dl"] = new SelectList(db.departments.Select(p => p.dept_name));

            if (emp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            employee emp = db.employees.Find(id);
            if (emp == null) return HttpNotFound();

            ViewData["title_dl"] = new SelectList(db.titles.Select(p => p.title_name));
            ViewData["gen_dl"] = new SelectList(db.genders, "gender_id", "gender_description");
            ViewData["department_dl"] = new SelectList(db.departments,"dept_no","dept_name");

            return View(emp);
      
        }
        [HttpPost]
        public ActionResult Edit(employee emp)
        {
            var data = db.employees.Single(p => p.emp_no == emp.emp_no);
            data.title_name = emp.title_name;
            data.first_name = emp.first_name;
            data.last_name = emp.last_name;
            data.gender = emp.gender;
            data.department = emp.department;
            data.salary = emp.salary;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            employee data = db.employees.Find(id);
            if (data == null) return HttpNotFound();

            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            employee data = db.employees.Find(id);
            db.employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}