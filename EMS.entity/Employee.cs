
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.entity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? identificationNumber { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public DateTime? birthday { get; set; }
        public bool? gender { get; set; }
        public string? adress { get; set; }

        public string? offerLetterPath { get; set; }
        public string? promotionLetterPath { get; set; }

        public List<ActivityEmployee>? ActivityEmployees { get; set; }
        public List<TaskEmployee>? tasks { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }


        public Payroll? Payroll { get; set; }
    }
}
