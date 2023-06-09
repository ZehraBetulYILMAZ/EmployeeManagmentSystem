﻿using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Abstract
{
    public interface ITaskRepository : IRepository<TaskEmployee>
    {
        List<TaskEmployee> GetTasksWithEmployee(int EmployeeId);
    }
}
