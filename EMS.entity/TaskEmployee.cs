﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.entity
{
    public class TaskEmployee
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateOfPosting { get; set; }
        public DateTime dateOfHanding { get; set; }
        public string status { get; set; }
        public bool isActive { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
