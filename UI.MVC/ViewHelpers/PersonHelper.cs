using Core.Abstracts.Services;
using UI.MVC.Models;

namespace UI.MVC.ViewHelpers
{
    public interface IPersonHelper
    {
        CreatePersonViewModel GetCreatePersonView();
    }

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
                Departments = _departmentService.GetDepartmentsForList()
            };
        }
    }
}

