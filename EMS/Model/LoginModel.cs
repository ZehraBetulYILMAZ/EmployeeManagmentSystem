using System.ComponentModel.DataAnnotations;
namespace EMS.WebUI.Model
{       public class LoginModel
        {
            [Required]
            //[DataType(DataType.EmailAddress)]
            // public string UserName { get; set; }
            public string username { get; set; }
            [Required]
           // [DataType(DataType.Password)]
            public string password { get; set; }
            public string ReturnUrl { get; set; }
        }
}
