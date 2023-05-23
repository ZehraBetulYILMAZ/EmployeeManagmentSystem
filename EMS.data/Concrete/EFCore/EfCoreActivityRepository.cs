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
    public class EfCoreActivityRepository :
       EfCoreGenericRepository<Activity, EMSDemoContext>, IActivityRepository
    {
        public List<Activity> GetActivityWithEmployee(Employee e)
        {
            using (var context = new EMSDemoContext())
            {


                var orders = context.Activities
                                      .Include(i => i.ActivityEmployees)
                                      .ThenInclude(i => i.Employee)
                                      .AsQueryable();

                return orders.ToList();
            }
        }

        public void UpdateAttandes(Employee entity, Activity activity)
        {
            using (var context = new EMSDemoContext())
            {

                var a = context.Activities
                              .Include(i => i.ActivityEmployees)
                              .FirstOrDefault(i => i.Id == activity.Id);
                if (a != null)
                {

                    a.ActivityEmployees.Add(new ActivityEmployee { EmployeeId = entity.Id, ActivityId = a.Id });

                    context.SaveChanges();
                }
            }

        }
      
    }
}
