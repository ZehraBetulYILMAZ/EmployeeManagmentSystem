using EMS.data.Abstract;
using EMS.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Concrete.EFCore
{
    public class EfCoreEmployeeRepository :
       EfCoreGenericRepository<Employee, EMSDemoContext>, IEmployeeRepository
    {
        public Employee GetByIdWithDepartments(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByDepartments(int departmentId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetSearchResult(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
