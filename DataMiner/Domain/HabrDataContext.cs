using System.Data.Entity;

namespace DataMiner.Domain
{
    public class HabrDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
