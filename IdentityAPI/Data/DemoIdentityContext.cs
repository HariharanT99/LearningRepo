using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IdentityAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace IdentityAPI.Data
{
    public partial class DemoIdentityContext: IdentityDbContext<User, Role, Guid>
    {
        public DemoIdentityContext(DbContextOptions<DemoIdentityContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                // Maps to the Users table
                b.ToTable("Users");

            });

            builder.Entity<UserClaim>(b =>
            {

                // Maps to the UserClaims table
                b.ToTable("UserClaims");
            });

            builder.Entity<UserLogin>(b =>
            {
                // Maps to the UserLogins table
                b.ToTable("UserLogins");
            });

            builder.Entity<UserToken>(b =>
            {
                // Maps to the UserTokens table
                b.ToTable("UserTokens");
            });

            builder.Entity<Role>(b =>
            {
                // Maps to the AspNetRoles table
                b.ToTable("Roles");

            });

            builder.Entity<RoleClaim>(b =>
            {
                // Maps to the AspNetRoleClaims table
                b.ToTable("RoleClaims");
            });

            builder.Entity<UserRole>(b =>
            {
                // Maps to the UserRoles table
                b.ToTable("UserRoles");
            });


            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<UserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvIder, e.ProvIderKey });
            //});

            //modelBuilder.Entity<UserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });
            //});

            //modelBuilder.Entity<UserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvIder, e.Name });
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
