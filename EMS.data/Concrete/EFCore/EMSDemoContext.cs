using EMS.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.data.Concrete.EFCore
{
    public class EMSDemoContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<TaskEmployee> TaskEmployees { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=EMSDemo;User Id=postgres;Password=hello123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityEmployee>()
                .HasKey(c => new { c.ActivityId, c.EmployeeId });
        }
    }
}
