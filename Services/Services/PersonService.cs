using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.Services;
using Core.Concrete.DTOs.Person;
using Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{

    public class PersonService : BaseService, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<PersonListItemDTO> GetPeopleForList()
        {
            var data = _unitOfWork.PersonRepo.ReadMany();
            return data.Select(x => _mapper.Map<PersonListItemDTO>(x));
            /*
            return data.Select(x => new PersonListItemDTO
            {
                Id = x.Id,
                Fullname = $"{x.Firstname} {x.Middlename} {x.Lastname}",
                Active = x.Active,
                Deleted = x.Deleted,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.Title,
                Email = x.Email
            });
            */
        }

        public IEnumerable<PersonListItemDTO> GetPeopleForListByCity()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonListItemDTO> GetPeopleForListByDepartment()
        {
            throw new NotImplementedException();
        }

        public PersonDetailDTO GetPersonDetail(int id)
        {
            Person entity = _unitOfWork.PersonRepo.ReadOneByKey(id);
            return _mapper.Map<PersonDetailDTO>(entity);
        }

        public void InsertPerson(NewPersonDTO newPerson)
        {
            Person entity = _mapper.Map<Person>(newPerson);
            /*new Person
        {
            Active = true,
            Deleted = false,
            CreateTime = DateTime.Now,
            Prefix = newPerson.Prefix,
            Firstname = newPerson.Firstname,
            Middlename = newPerson.Middlename,
            Lastname = newPerson.Lastname,
            Suffix = newPerson.Suffix,
            DepartmentId = newPerson.DepartmentId,
            Email = newPerson.Email
        };*/
            _unitOfWork.PersonRepo.CreateOne(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool ToggleActive(int personId)
        {
            var entity = _unitOfWork.PersonRepo.ReadOneByKey(personId);
            entity.Active = !entity.Active;
            _unitOfWork.PersonRepo.UpdateOne(entity);
            _unitOfWork.Commit();
            return entity.Active;
        }

        public bool ToggleDeleted(int personId)
        {
            var entity = _unitOfWork.PersonRepo.ReadOneByKey(personId);
            entity.Deleted = !entity.Deleted;
            _unitOfWork.PersonRepo.UpdateOne(entity);
            _unitOfWork.Commit();
            return entity.Deleted;
        }
    }
}
