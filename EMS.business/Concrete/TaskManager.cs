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
            throw new NotImplementedException();
        }

        public List<TaskEmployee> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskEmployee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskEmployee entity)
        {
            throw new NotImplementedException();
        }
    }
}

