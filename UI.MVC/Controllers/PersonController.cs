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
        private IWebHostEnvironment _environment;
        public PersonController(IPersonService service, IPersonHelper helper, IDepartmentService dService, IWebHostEnvironment environment)
        {
            _service = service;
            _helper = helper;
            _dService = dService;
            _environment = environment;
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
        public IActionResult Create(CreatePersonViewModel model, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                string fName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePicture.FileName);
                var upload_path = Path.Combine(_environment.WebRootPath, "uploads", fName);

                using (var stream = new FileStream(upload_path,FileMode.Create))
                {
                    ProfilePicture.CopyTo(stream);
                }
            }

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
