using Microsoft.AspNetCore.Identity;

namespace EMS.WebUI.Identity
{
    public class User : IdentityUser
    {
        public string? identificationNumber { get; set; }
    }
}
