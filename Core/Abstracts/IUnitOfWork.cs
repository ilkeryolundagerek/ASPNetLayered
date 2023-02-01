using Core.Abstracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        //Interface yapılar new operatörü kullanamaz, abstract yapılardır. set edilmezler.
        IPersonRepository PersonRepo { get; }
        IDepartmentRepository DepartmentRepo { get; }
        IAddressRepository AddressRepo { get; }

        void Commit();
        Task CommitAsync();
    }
}
