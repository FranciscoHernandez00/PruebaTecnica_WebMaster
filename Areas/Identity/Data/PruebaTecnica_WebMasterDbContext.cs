using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_WebMaster.Areas.Identity.Data;

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
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
