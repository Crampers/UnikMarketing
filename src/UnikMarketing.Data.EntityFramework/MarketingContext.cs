using Microsoft.EntityFrameworkCore;


namespace UnikMarketing.Domain
{
    public class MarketingContext : DbContext
    {
        public MarketingContext()
        {
            
        }
        public MarketingContext(DbContextOptions<MarketingContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
