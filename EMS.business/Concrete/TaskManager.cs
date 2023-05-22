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
    public class TaskManager : ITaskService
    {
        private ITaskRepository _taskRepository;
        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Create(TaskEmployee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskEmployee entity)
        {
             _taskRepository.Delete(entity);
        }

        public List<TaskEmployee> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public TaskEmployee GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public List<TaskEmployee> GetTasksWithEmployee(int EmployeeId)
        { 
            return _taskRepository.GetTasksWithEmployee(EmployeeId);
        }

        public void Update(TaskEmployee entity)
        {
           _taskRepository.Update(entity);
        }
       
    }
}

