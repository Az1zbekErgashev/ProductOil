using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductOil.Enitiy;
using System.Data;

namespace ProductOil.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public RoleConfiguration(IServiceProvider services) => this.Services = services;
        public IServiceProvider Services { get; set; }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var roleManager = Services.GetRequiredService<RoleManager<IdentityRole>>();

            var role = Enum.GetNames<Role>().Select(x => new IdentityRole(x.ToUpper()) { NormalizedName = roleManager.NormalizeKey(x.ToUpper()) });
            builder.HasData(role);
        }
    }
}
