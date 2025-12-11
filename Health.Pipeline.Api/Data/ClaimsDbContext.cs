using Health.Pipeline.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Health.Pipeline.Api.Data
{
    public class ClaimsDbContext : DbContext
    {
        public ClaimsDbContext(DbContextOptions<ClaimsDbContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }
    }
}
