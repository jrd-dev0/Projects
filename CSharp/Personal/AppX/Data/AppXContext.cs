using AppX.Models;
using Microsoft.EntityFrameworkCore;

namespace AppX.Data
{
    public class AppXContext : DbContext
    {
        public AppXContext(DbContextOptions<AppXContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
