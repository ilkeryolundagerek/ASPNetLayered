using Core.Abstracts.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.MVC.Models;

namespace UI.MVC.ViewHelpers
{

    public class PersonHelper : IPersonHelper
    {
        private IPersonService _personService;
        private IDepartmentService _departmentService;

        public PersonHelper(IPersonService personService, IDepartmentService departmentService)
        {
            _personService = personService;
            _departmentService = departmentService;
        }

        public CreatePersonViewModel GetCreatePersonView()
        {
            return new CreatePersonViewModel()
            {
                Departments = _departmentService.GetDepartmentsForList().Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Title })
            };
        }
    }
}

