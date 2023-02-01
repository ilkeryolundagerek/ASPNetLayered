using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete.Entities
{
    public class Person : BaseEntity
    {
        public string? Prefix;
        public string Firstname;
        public string? Middlename;
        public string Lastname;
        public string? Suffix;
        public string Email;
        public int DepartmentId;

        public Department Department;
        public ICollection<Address> Addresses;//Db tarafına gönderilmeyen yapılardır. Çünkü nense yapısının sütunu oluşmaz.

        public Person()
        {
            //Koleksiyon (one-to-many) bağlantılarında yünklenememe durumlarını karşılamak için boş halleri eklenmelidir.
            Addresses = new HashSet<Address>();
        }
    }
}
