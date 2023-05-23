

namespace EMS.WebUI.Model
{
    public class EmployeeModel
    {
        public string? idNumber { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime? birthDate { get; set; }
        public string? address { get; set; }

        public string? department { get; set; }

        public bool? gender { get; set; }
        public string? offerLetterPath { get; set; }
        public string? promotionLetterPath { get; set; }



    }
}
