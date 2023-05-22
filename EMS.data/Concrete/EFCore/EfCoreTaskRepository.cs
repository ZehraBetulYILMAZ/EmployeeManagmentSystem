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
    public class EfCoreTaskRepository :
       EfCoreGenericRepository<TaskEmployee, EMSDemoContext>, ITaskRepository
    {
        List<TaskEmployee> ITaskRepository.GetTasksWithEmployee(int EmployeeId)
        {
            using (var context = new EMSDemoContext())
            {
                var tasks = context
                    .TaskEmployees
                    .Where(i => i.EmployeeId == EmployeeId)
                    .AsQueryable();

                return tasks.ToList();
            }
        }
    }
}
