using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public class EmployeeService
    {
        private readonly WebAppContext _context;

        public EmployeeService(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> FindAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task Insert(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> FindByIDAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remove(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            var hasAny = _context.Employees.Any(x => x.Id == employee.Id);

            if (!hasAny)
            {
                throw new Exception("ID not found.");
            }

            try
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (ApplicationException e)
            {
                throw new(e.Message);
            }
        }

        public async Task GetInfo(Employee employee)
        {
            var hasAny = _context.Employees.Any(x => x.Id == employee.Id);

            if ()
        }
    }
}
