using Core.Concrete.DTOs.Department;
using Core.Concrete.DTOs.Person;

namespace UI.MVC.Models
{
    public class CreatePersonViewModel
    {
        public NewPersonDTO NewPerson { get; set; }
        public IEnumerable<DepartmentListItemDTO> Departments { get; set; }
    }
}
