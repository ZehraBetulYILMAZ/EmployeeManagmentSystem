namespace EMS.WebUI.Model
{
    public class PayrollModel
    {
        public int Id { get; set; }

        public double GrossSalary { get; set; }
        public double SGKPremium { get; set; }
        public double StampTax { get; set; }
        public double MuhtasarTax { get; set; }
        public double DeductionsTotal { get; set; }
        public double NetSalary { get; set; }
        public int employeeId { get; set; }
        public string idNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
