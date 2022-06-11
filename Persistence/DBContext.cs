using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.EntityTypeConfigurations;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{

    public class DBContext : IdentityDbContext, IDBContext
    {
        public new DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<FrontGlobalSetting> FrontGlobalSettings { get; set; }
        public DbSet<FrontCategory> FrontCategories { get; set; }
        public DbSet<Demo> Demos { get; set; }
        public DbSet<FrontPage> FrontPages { get; set; }
        public DbSet<FrontBaseComponent> FrontBaseComponents { get; set; }
        public DbSet<FrontComponentProp> FrontComponentProps { get; set; }
        public DbSet<FrontComponent> FrontComponents { get; set; }
        public DbSet<FrontPropValue> FrontPropValues { get; set; }

        public DBContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DemoConfiguration());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

    }
}
