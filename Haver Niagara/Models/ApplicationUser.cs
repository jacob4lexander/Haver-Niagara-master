using Microsoft.AspNetCore.Identity;

namespace Haver_Niagara.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
