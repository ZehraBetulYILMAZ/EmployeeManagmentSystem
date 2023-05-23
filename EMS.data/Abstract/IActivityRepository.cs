using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Abstract
{
    public interface IActivityRepository:IRepository<Activity>
    {
        void UpdateAttandes(Employee entity, Activity activity);
        
        List<Activity> GetActivityWithEmployee(Employee e);
        /* Activity GetById(int id);
         List<Activity> GetAll();
         void Create(Activity entity);
         void Update(Activity entity);
         void Delete(Activity entity);*/


    }
}
