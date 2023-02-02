using Core.Concrete.DTOs.Department;
using Core.Concrete.DTOs.Person;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.MVC.Models
{
    public class CreatePersonViewModel
    {
        public NewPersonDTO NewPerson { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
