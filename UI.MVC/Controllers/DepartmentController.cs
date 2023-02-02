using Core.Abstracts.Services;
using Core.Concrete.DTOs.Department;
using Microsoft.AspNetCore.Mvc;

namespace UI.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(_service.GetDepartmentsForList());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetDepartmentDetail(id));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewDepartmentDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.InsertDepartment(model);
                    _service.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
