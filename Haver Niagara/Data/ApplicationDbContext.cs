using Haver_Niagara.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Haver_Niagara.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
