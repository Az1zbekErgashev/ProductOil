using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductOil.Enitiy;

namespace ProductOil.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider services) : base(options)
        {
            this.Services = services;
        }

        public IServiceProvider Services { get; set; }
        public DbSet<Categoriy> Categoriys { get; set; }
        public DbSet<BenefitOil> BenefitOil { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Exemples> Exemples { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<OilCompany> OilCompany { get; set; }
        public DbSet<OilNews> OilNews { get; set; }
        public DbSet<OilProduct> OilProduct { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<NeftekorCertified> NeftekorCertified { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Services));
        }
    }
}
