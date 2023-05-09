using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.entity
{
    public class Department
    {
        public int departmentId { get; set; }
        public string name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
