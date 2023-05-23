using EMS.business.Abstract;
using EMS.data.Abstract;
using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.business.Concrete
{
   public class ActivityManager:IActivityService
    {
        private IActivityRepository _activityRepository;
        public ActivityManager(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        /* public bool Create(Activity entity)
         {
             if (Validation(entity))
             {
                 _activityRepository.Create(entity);
                 return true;
             }
             return false;
         }*/
        public void Create(Activity entity)
        {
            _activityRepository.Create(entity);
        }
        public void Delete(Activity entity)
        {
            _activityRepository.Create(entity);
        }

        public List<Activity> GetActivityWithEmployee(Employee e)
        {
           return _activityRepository.GetActivityWithEmployee(e);
        }

        public List<Activity> GetAll()
        {
            return _activityRepository.GetAll();
        }


        public Activity GetById(int id)
        {
            return _activityRepository.GetById(id);
        }


        public void Update(Activity entity)
        {
            _activityRepository.Create(entity); ;
        }
        public void UpdateAttandes(Employee entity, Activity activity)
        {
            _activityRepository.UpdateAttandes(entity, activity);
        }
    }
}
