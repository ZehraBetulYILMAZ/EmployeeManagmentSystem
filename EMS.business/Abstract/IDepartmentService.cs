using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.business.Abstract
{
    public interface IDepartmentService
    {
        Department GetById(int id);
        List<Department> GetAll();

        void Create(Department entity);

        void Update(Department entity);
        void Delete(Department entity);
    }
}
