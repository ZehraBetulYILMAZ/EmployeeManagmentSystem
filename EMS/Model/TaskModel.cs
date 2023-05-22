using EMS.entity;

namespace EMS.WebUI.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public DateTime dateOfPosting { get; set; }

        public string status { get; set; }
        public bool isActive { get; set; }

        public int EmployeeId { get; set; }
        public string employee { get; set; }

        public DateTime dateOfHanding { get; set; }


    }
}