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
    public class PayrollManager: IPayrollService
    {
        private IPayrollRepository payrollRepository;

        public PayrollManager(IPayrollRepository payrollRepository)
        {
            this.payrollRepository = payrollRepository;
        }
        public void Create(Payroll entity)
        {
            payrollRepository.Create(entity);
        }

        public void Delete(Payroll entity)
        {
            payrollRepository.Delete(entity);
        }

        public List<Payroll> GetAll()
        {
            return payrollRepository.GetAll();
        }

        public Payroll GetById(int id)
        {
            return payrollRepository.GetById(id);
        }

        public void Update(Payroll entity)
        {
            payrollRepository.Update(entity);
        }
    }
}
