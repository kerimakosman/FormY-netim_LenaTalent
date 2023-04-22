using Entities.Entities.Concrete;
using Entities.Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public class SqlDbContext:DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>()
                .HasKey(p => new { p.UserId, p.RoleId });

            builder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(p => p.RoleId);

            builder.Entity<FormMessage>()
                .HasOne(fm => fm.Form)
                .WithMany(f=>f.FormMessages)
                .HasForeignKey(fm => fm.FormId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<FormMessage>()
                .HasOne(fm => fm.User)
                .WithMany(f => f.FormMessages)
                .HasForeignKey(fm => fm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
