using WebApp.Models;
using WebApp.Models.Enums;

namespace WebApp.Data
{
    public class SeedingService
    {
        public static void SeedData(IApplicationBuilder applicationBuider)
        {
            using (var serviceScope = applicationBuider.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WebAppContext>();
                // Has any data ?
                if (context.Employees.Any())
                {
                    return; // DB has been seeded
                }

                Employee emp1 = new(1, "Hommer", "YellowStone", "hommer@gmail.com", 3000.00, Profile.Admin);
                Employee emp2 = new(2, "Alice", "Theodore", "alice.theo@gmail.com", 2000.00, Profile.Default);
                Employee emp3 = new(3, "Marge", "Simpson", "marge@gmail.com", 6000.00, Profile.Default);
                Employee emp4 = new(4, "Walker", "Dunky", "walker.d@gmail.com", 7000.00, Profile.Default);
                Employee emp5 = new(5, "Dummer", "Liutszesk", "dummer_liutszesk@outlook.com", 3250.00, Profile.Default);

                Department dep1 = new(1, "Finance");
                Department dep2 = new(2, "Accounting");
                Department dep3 = new(3, "IT");

                context.Employees.AddRange(emp1, emp2, emp3, emp4, emp5);
                context.Departments.AddRange(dep1, dep2, dep3);

                context.SaveChanges();
            }
        }
    }
}