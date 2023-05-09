using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.entity
{
    public class Activity
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateOfPosting { get; set; }
        public string status { get; set; }
        public bool isActive { get; set; }
        public List<ActivityEmployee> ActivityEmployees { get; set; }
    }
}
