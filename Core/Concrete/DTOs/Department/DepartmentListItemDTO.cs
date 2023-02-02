using Core.Concrete.DTOs.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.DTOs.Department
{
    public class DepartmentListItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }

    public class DepartmentDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<PersonListItemDTO> People { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }

    public class NewDepartmentDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
