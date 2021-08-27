using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_WebMaster.Areas.Identity.Data;
using PruebaTecnica_WebMaster.Models;
using PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern;

namespace PruebaTecnica_WebMaster.Data
{
    public class PruebaTecnica_WebMasterDbContext : IdentityDbContext<PruebaTecnica_WebMasterUser>
    {
        public PruebaTecnica_WebMasterDbContext(DbContextOptions<PruebaTecnica_WebMasterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Store>().Property(x => x.Altitud).HasPrecision(9, 6);
            //builder.Entity<Store>().Property(x => x.Longitud).HasPrecision(9, 6);

            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<PruebaTecnica_WebMasterUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            new StoreMap(builder.Entity<Store>());
            builder.Entity<Store>().Property(x => x.Latitude).HasPrecision(9, 6);
            builder.Entity<Store>().Property(x => x.Longitude).HasPrecision(9, 6);
        }
    }
}
