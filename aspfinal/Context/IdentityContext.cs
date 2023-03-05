using aspfinal.Models.Entities;
using aspfinal.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspfinal.Context
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<IdentityUserProfile> userProfiles { get; set; }

        public DbSet<ProfileEntity> UserProfiless { get; set; } = null!;
        public DbSet<TEstEntity> test { get; set; }
    }
}
