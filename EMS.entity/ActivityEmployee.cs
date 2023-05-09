using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.entity
{
    public class ActivityEmployee
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
