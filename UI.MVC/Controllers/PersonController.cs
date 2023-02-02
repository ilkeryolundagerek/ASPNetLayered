using Core.Abstracts.Services;
using Microsoft.AspNetCore.Mvc;
using UI.MVC.Models;
using UI.MVC.ViewHelpers;

namespace UI.MVC.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _service;
        private IPersonHelper _helper;
        public PersonController(IPersonService service, IPersonHelper helper)
        {
            _service = service;
            _helper = helper;
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
    }
}
