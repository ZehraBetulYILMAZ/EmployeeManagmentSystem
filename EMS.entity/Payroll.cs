using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.entity
{
    public class Payroll
    {
        public int Id { get; set; }

        public double brutMaas { get; set; }
        public double sgkPrimi { get; set; }
        public double damgaVergisi { get; set; }
        public double muhtasarVergisi { get; set; }
        public double kesintilerToplamı { get; set; }
        public double netMaas { get; set; }


        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
