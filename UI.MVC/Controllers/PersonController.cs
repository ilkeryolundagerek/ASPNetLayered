using Core.Abstracts.Services;
using Microsoft.AspNetCore.Mvc;
using UI.MVC.Models;

namespace UI.MVC.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _service;
        public PersonController(IPersonService service)
        {
            _service = service;
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
            return View(new CreatePersonViewModel());
        }
    }
}
