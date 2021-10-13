using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Riodetask.Model.Entity;
using Riodetask.Model.Entity.Memberships;
using Riodetask.Model.Memberships;
using System;

namespace Riodetask.Model.DataContexts
{



    public class RioDbContext : IdentityDbContext<RiodeUser, RiodeRole, int, RiodeUserClaim, RiodeUserRole, RiodeUserLogin, RiodeRoleClaim, RiodeUserToken>
    {
        public RioDbContext()
            :base()
        {

        }
        public RioDbContext( DbContextOptions options)
            : base(options)
        {
            
        }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Subscribe> subscribes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RiodeUser>(e =>
            {
                e.ToTable("User", "Membership");
            });
            builder.Entity<RiodeRole>(e =>
            {
                e.ToTable("Role", "Membership");
            });
            builder.Entity<RiodeRoleClaim>(e =>
            {
                e.ToTable("RoleClaim", "Membership");
            });
            builder.Entity<RiodeUserClaim>(e =>
            {
                e.ToTable("UserClaim", "Membership");
            });
            builder.Entity<RiodeUserLogin>(e =>
            {
                e.HasKey(p => new { p.ProviderKey, p.LoginProvider});

                e.ToTable("UserLogin", "Membership");
            });
            builder.Entity<RiodeUserToken>(e =>
            {
                e.ToTable("UserToken", "Membership");
            });
            builder.Entity<RiodeUserRole>(e =>
            {
                e.ToTable("UserRole", "Membership");
            });
        }

        internal object UserClaims(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
