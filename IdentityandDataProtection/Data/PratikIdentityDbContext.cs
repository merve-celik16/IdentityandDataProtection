using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityandDataProtection.Data
{
    public class PratikIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public PratikIdentityDbContext(DbContextOptions<PratikIdentityDbContext> options) : base(options) { }
    }
    
    
}
