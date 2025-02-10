using AppX.Data;
using AppX.Models;

namespace WebApp.Data
{
    public class SeedingService
    {
        public static void SeedData(IApplicationBuilder applicationBuider)
        {
            using (var serviceScope = applicationBuider.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppXContext>();
                // Has any data ?
                if (context.Employees.Any() || context.Departments.Any())
                {
                    return; // DB has been seeded
                }

                Department dep1 = new() { Id = 1, Name = "Finance" };
                Department dep2 = new() { Id = 2, Name = "Accounting" };
                Department dep3 = new() { Id = 3, Name = "IT" };

                Employee emp1 = new() { Id = 1, Name = "Hommer", Salary = 3000.00, Department = dep1 };
                Employee emp2 = new() { Id = 2, Name = "Alice", Salary = 3200.00, Department = dep2 };
                Employee emp3 = new() { Id = 3, Name = "Walker", Salary = 2700.00, Department = dep3 };
                Employee emp4 = new() { Id = 4, Name = "Marge", Salary = 3500.00, Department = dep3 };
                Employee emp5 = new() { Id = 5, Name = "Partrait", Salary = 4250.00, Department = dep1 };

                context.Employees.AddRange(emp1, emp2, emp3, emp4, emp5);
                context.Departments.AddRange(dep1, dep2, dep3);

                context.SaveChanges();
            }
        }
    }
}