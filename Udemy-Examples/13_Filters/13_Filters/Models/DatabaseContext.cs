using System.Data.Entity;

namespace _13_Filters.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
    }
}