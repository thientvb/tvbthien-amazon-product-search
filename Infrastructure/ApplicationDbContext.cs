using Microsoft.EntityFrameworkCore;
using ViewModels.Domain;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AmazonAlias> AmazonAliases { get; set; }
        public DbSet<AmazonProduct> AmazonProducts { get; set; }
        public DbSet<AmazonSuggestion> AmazonSuggestions { get; set; }
    }
}
