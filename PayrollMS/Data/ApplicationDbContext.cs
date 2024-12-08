using Microsoft.EntityFrameworkCore;
using PayrollMS.Models;

namespace PayrollMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Allowance> Allowances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.Status)
                .HasDefaultValue("Pending");

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                AdminId = 1,
                Username = "admin",
                Password = "admin@123" // Use hashed passwords in real applications
            });
        }
    }
}
