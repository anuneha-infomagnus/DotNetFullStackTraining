using Day07.Models;
using Microsoft.EntityFrameworkCore;

namespace Day07.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(e => e.Reports)
                .HasForeignKey(e => e.ManagerId)
                .IsRequired(false);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(18, 2);
            modelBuilder.Entity<EmployeeProfile>()
                .HasOne(p => p.Employee)
                .WithOne(e => e.Profile)
                .HasForeignKey<EmployeeProfile>(p => p.EmployeeId);
        }
    }
}