using Microsoft.EntityFrameworkCore;

namespace pagamentos_api_v1.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }

        public DbSet<Pagamento>? Pagamentos { get; set; }
    }
}