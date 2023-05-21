using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Abstract
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee GetByIdWithDepartments(int id);
        List<Employee> GetEmployeesByDepartments(int departmentId);
        List<Employee> GetSearchResult(string searchString);
        Employee GetIdNumber(string idNumber);
    }
}
