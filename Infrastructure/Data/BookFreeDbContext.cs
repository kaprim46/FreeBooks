using Domain.Entity;
using Infrastructure.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BookFreeDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookFreeDbContext(DbContextOptions<BookFreeDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Custom identity user change names of tables as you want

            //builder.Entity<IdentityUser>().ToTable("Users", "Identity");
            //builder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Identity");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Identity");
            //builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");

            builder.Entity<Book>().Property(x => x.Id).HasDefaultValueSql("(newId())");
            builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("(newId())");
            builder.Entity<LogBook>().Property(x => x.Id).HasDefaultValueSql("(newId())");
            builder.Entity<LogCategory>().Property(x => x.Id).HasDefaultValueSql("(newId())");
            builder.Entity<LogSubCategory>().Property(x => x.Id).HasDefaultValueSql("(newId())");
            builder.Entity<SubCategory>().Property(x => x.Id).HasDefaultValueSql("(newId())");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }
        public DbSet<LogCategory> LogCategories { get; set; }
        public DbSet<LogSubCategory> LogSubCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
