using Core.Concrete.DTOs.Address;
using Core.Concrete.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.DTOs.Person
{
    public class PersonListItemDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }

    public class PersonDetailDTO
    {
        public int Id { get; set; }
        public string? Prefix { get; set; }
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Lastname { get; set; }
        public string? Suffix { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDetailDTO Department { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public IEnumerable<AddressDTO> Addresses { get; set; }
    }

    public class NewPersonDTO
    {
        public string? Prefix { get; set; }
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Lastname { get; set; }
        public string? Suffix { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
