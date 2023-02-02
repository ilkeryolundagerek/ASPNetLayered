using Core.Concrete.DTOs.Department;

namespace Core.Abstracts.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentListItemDTO> GetDepartmentsForList();
        DepartmentDetailDTO GetDepartmentDetail(int id);
        void InsertDepartment(NewDepartmentDTO newDepartment);
        void ToggleActive(int departmentId);
        void ToggleDeleted(int departmentId);
        void SaveChanges();
    }
}
