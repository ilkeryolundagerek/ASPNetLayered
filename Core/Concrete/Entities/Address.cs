using Core.Abstracts.Bases;

namespace Core.Concrete.Entities
{
    public class Address : BaseEntity
    {
        public string Name;
        public int PersonId;
        public Person Person;//Db tarafına gönderilmeyen yapılardır. Çünkü nense yapısının sütunu oluşmaz.
        public string City;
        public string Country;
        public string Detail;
    }
}
