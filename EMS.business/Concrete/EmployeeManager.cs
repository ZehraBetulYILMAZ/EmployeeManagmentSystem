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
    public class EmployeeManager:IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Create(Employee entity)
        {
            _employeeRepository.Create(entity);
        }

        public void Delete(Employee entity)
        {
            _employeeRepository.Create(entity);
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }


        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Employee GetByIdWithDepartments(int id)
        {
            return _employeeRepository.GetByIdWithDepartments(id);
        }

        List<Employee> IEmployeeService.GetEmployeesByDepartments(int departmentId)
        {
            return _employeeRepository.GetEmployeesByDepartments(departmentId);
        }
        List<Employee> IEmployeeService.GetSearchResult(string searchString)
        {
            return _employeeRepository.GetSearchResult(searchString);
        }

        public void Update(Employee entity)
        {
            _employeeRepository.Update(entity); ;
        }
        public Employee GetIdNumber(string idNumber)
        {
            return _employeeRepository.GetIdNumber(idNumber);
        }

    }
}
