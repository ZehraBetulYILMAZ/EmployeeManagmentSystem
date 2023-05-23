using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.business.Abstract
{
    public interface IActivityService
    { //event
        Activity GetById(int id);
        List<Activity> GetAll();
        void Create(Activity entity);
        void Update(Activity entity);
        void Delete(Activity entity);
        void UpdateAttandes(Employee entity, Activity activity);
        List<Activity> GetActivityWithEmployee(Employee e);
    }
}
