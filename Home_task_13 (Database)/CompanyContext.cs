using Microsoft.EntityFrameworkCore;

namespace CompanyDB
{
    public class CompanyContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CompanyDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(p => p.Employees)
                .UsingEntity(j => j.ToTable("EmployeeProjects"));
        }
    }

    public static class CompanyContextExtensions
    {
        public static IQueryable<Department> IncludeEmployees(this IQueryable<Department> departments)
        {
            return departments.Include(d => d.Employees);
        }

        public static IQueryable<Project> IncludeEmployees(this IQueryable<Project> projects)
        {
            return projects.Include(p => p.Employees);
        }
    }
}