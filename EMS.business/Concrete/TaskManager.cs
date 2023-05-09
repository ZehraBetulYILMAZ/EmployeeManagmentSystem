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
        public void Create(Task entity)
        {
            _taskRepository.Create(entity);
        }

        public void Delete(Task entity)
        {
            _taskRepository.Create(entity);
        }

        public List<Task> GetAll()
        {
            return _taskRepository.GetAll();
        }


        public Task GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public Task GetByIdWithDepartments(int id)
        {
            return _taskRepository.GetByIdWithDepartments(id);
        }

        List<Task> ITaskService.GetTasksByDepartments(int departmentId)
        {
            return _taskRepository.GetTasksByDepartments(departmentId);
        }
        List<Task> ITaskService.GetSearchResult(string searchString)
        {
            return _taskRepository.GetSearchResult(searchString);
        }

        public void Update(Task entity)
        {
            _taskRepository.Create(entity); ;
        }

    }
}

