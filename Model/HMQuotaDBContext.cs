using Microsoft.EntityFrameworkCore;
namespace HMQuota.Model
{
    public class HMQuotaDBContext : DbContext
    {
        public DbSet<QuotaHeader> quotaHeaders { get; set; }

        public DbSet<QuotaBody> quotaBody { get; set; }
        public HMQuotaDBContext(DbContextOptions<HMQuotaDBContext> dbContextOptions) : base(dbContextOptions) { }
    }

}