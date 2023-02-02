using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.Services;
using Core.Concrete.DTOs.Department;
using Core.Concrete.Entities;

namespace Services.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public DepartmentDetailDTO GetDepartmentDetail(int id)
        {
            Department entity = _unitOfWork.DepartmentRepo.ReadOneByKey(id);
            return _mapper.Map<DepartmentDetailDTO>(entity);
        }

        public IEnumerable<DepartmentListItemDTO> GetDepartmentsForList()
        {
            var entities = _unitOfWork.DepartmentRepo.ReadMany();
            return from d in entities
                   select new DepartmentListItemDTO
                   {
                       Id = d.Id,
                       Title = d.Title,
                       Active = d.Active,
                       Deleted = d.Deleted
                   };
        }

        public void InsertDepartment(NewDepartmentDTO newDepartment)
        {
            var entity = _mapper.Map<Department>(newDepartment);
            _unitOfWork.DepartmentRepo.CreateOne(entity);
        }

        public void ToggleActive(int departmentId)
        {
            var entity = _unitOfWork.DepartmentRepo.ReadOneByKey(departmentId);
            entity.Active = !entity.Active;
            _unitOfWork.DepartmentRepo.UpdateOne(entity);
        }

        public void ToggleDeleted(int departmentId)
        {
            var entity = _unitOfWork.DepartmentRepo.ReadOneByKey(departmentId);
            entity.Deleted = !entity.Deleted;
            _unitOfWork.DepartmentRepo.UpdateOne(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
