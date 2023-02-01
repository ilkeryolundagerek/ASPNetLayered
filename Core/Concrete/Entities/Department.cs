using Core.Abstracts.Bases;

namespace Core.Concrete.Entities
{
    public class Department : BaseEntity
    {
        public string Title;
        public string Description;
        public ICollection<Person> People;

        public Department()
        {
            People = new HashSet<Person>();
        }
    }
}
