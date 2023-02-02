using Core.Abstracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Services;
using UI.MVC.Models;
using UI.MVC.ViewHelpers;

namespace UI.MVC.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _service;
        private IDepartmentService _dService;
        private IPersonHelper _helper;
        public PersonController(IPersonService service, IPersonHelper helper, IDepartmentService dService)
        {
            _service = service;
            _helper = helper;
            _dService = dService;
        }
        public IActionResult Index()
        {
            return View(_service.GetPeopleForList());
        }

        public IActionResult Details(int id)
        {
            return View(_service.GetPersonDetail(id));
        }

        public IActionResult Create()
        {
            return View(_helper.GetCreatePersonView());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonViewModel model)
        {
            //var c = ModelState["NewPerson"].Children.Any(x => x.ValidationState != Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid);
            ModelState.Remove("Departments");
            if (ModelState.IsValid)
            //!string.IsNullOrEmpty(model.NewPerson.Firstname) 
            {
                _service.InsertPerson(model.NewPerson);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            model.Departments = _dService.GetDepartmentsForList().Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Title, Selected = d.Id == model.NewPerson.DepartmentId });
            return View(model);
        }

        public bool ToggleActive(int id)
        {
           return _service.ToggleActive(id);
        }

        public bool ToggleDeleted(int id)
        {
            return _service.ToggleDeleted(id);
        }
    }
}
