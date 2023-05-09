using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.business.Abstract
{
    public interface ITaskService
    {
        TaskEmployee GetById(int id);
        List<TaskEmployee> GetAll();

        void Create(TaskEmployee entity);

        void Update(TaskEmployee entity);
        void Delete(TaskEmployee entity);
    }
}
