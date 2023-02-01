﻿using Core.Concrete.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.Services
{
    public interface IPersonService
    {
        IEnumerable<PersonListItemDTO> GetPeopleForList();
        IEnumerable<PersonListItemDTO> GetPeopleForListByDepartment();
        IEnumerable<PersonListItemDTO> GetPeopleForListByCity();
        void InsertPerson(NewPersonDTO newPerson);
        void ToggleActive(int personId);
        void ToggleDeleted(int personId);
    }
}
