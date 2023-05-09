using EMS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.business.Abstract
{
    public interface IPayrollService
    {
        Payroll GetById(int id);
        List<Payroll> GetAll();

        void Create(Payroll entity);

        void Update(Payroll entity);
        void Delete(Payroll entity);
    }
}
