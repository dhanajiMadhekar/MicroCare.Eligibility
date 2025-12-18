using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EligibilityRequest> EligibilityRequests { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EligibilityRequest>()
                 .Property(e => e.ApprovalLimit)
                 .HasPrecision(18, 2);

            modelBuilder.Entity<EligibilityRequest>()
                .Property(e => e.Deductibles)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EligibilityRequest>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<EligibilityRequest>()
                .Property(e => e.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<EligibilityRequest>()
                .Property(e => e.MaritalStatus)
                .HasConversion<string>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "Admin@123"
                }
            );
        }
    }
}
