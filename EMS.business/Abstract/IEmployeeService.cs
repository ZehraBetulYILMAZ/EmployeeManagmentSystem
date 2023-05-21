using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.business.Abstract
{
    public interface IEmployeeService
    {
        Employee GetById(int id);
        List<Employee> GetAll();
        void Create(Employee entity);
        void Update(Employee entity);
        void Delete(Employee entity);
        Employee GetByIdWithDepartments(int id);
        List<Employee> GetEmployeesByDepartments(int departmentId);
        List<Employee> GetSearchResult(string searchString);

        Employee GetIdNumber(string idNumber);
    }
}
