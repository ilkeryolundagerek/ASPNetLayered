using Core.Abstracts;
using Core.Abstracts.Repositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private IPersonRepository _personRepository;
        private IDepartmentRepository _departmentRepository;
        private IAddressRepository _addressRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IPersonRepository PersonRepo
        {
            get
            {
                _personRepository = _personRepository == null ? new PersonRepository(_context) : _personRepository;
                return _personRepository;
            }
        }

        public IDepartmentRepository DepartmentRepo => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);

        public IAddressRepository AddressRepo => _addressRepository ??= new AddressRepository(_context);

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Dispose();
            }

        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            //Rollback işlemi yapılır.
            _context.Dispose();
        }
    }
}
