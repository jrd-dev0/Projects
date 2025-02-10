using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Enums;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var findAll = await _employeeService.FindAllAsync();
            return View(findAll);
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index), new { message = "ID not provided." });
            }

            var obj = await _employeeService.FindByIDAsync(id.Value);

            if (obj is null)
            {
                return RedirectToAction(nameof(Index), new { message = "ID not found." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || _employeeService == null)
            {
                return RedirectToAction(nameof(Index), new { message = "ID not provided." });
            }

            var obj = await _employeeService.FindByIDAsync(id.Value);

            if (obj is null)
            {
                return RedirectToAction(nameof(Index), new { message = "ID not found." });
            }

            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index), new { message = "ID not provided." });
            }

            var obj = await _employeeService.FindByIDAsync(id.Value);

            if (obj is null)
            {
                return RedirectToAction(nameof(Index), new { message = "ID not found." });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                employee.Login = employee.GetLogin(employee.Name, employee.Surname);
                employee.Password = employee.Login.ToUpper();
                employee.RegistrationDate = DateTime.Now;

                await _employeeService.Insert(employee);
                TempData["Success"] = "Employee created successfully";
                return RedirectToAction(nameof(Index));

                //if (ModelState.IsValid)
                //{
                //    await _employeeService.Insert(employee);
                //    TempData["Success"] = "Employee created successfully";
                //    return RedirectToAction(nameof(Index));
                //}

                //return View(employee);
            }
            catch(ApplicationException e)
            {
                TempData["Error"] = $"An error occurred: {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                TempData["Error"] = "An error occurred: ID missmatch";
                return RedirectToAction(nameof(Index), new { message = "ID missmatch" });
            }
            try
            {
                employee.UpdateDate = DateTime.Now;

                await _employeeService.Update(employee);
                TempData["Success"] = "Employee updated successfully";
                return RedirectToAction(nameof(Details), employee);

                //if (ModelState.IsValid)
                //{
                //    await _employeeService.Update(employee);
                //    TempData["Success"] = "Employee updated successfully";
                //    return RedirectToAction(nameof(Details), employee);
                //}

                //return View(employee);
                
            }
            catch (ApplicationException e)
            {
                TempData["Error"] = $"An error occurred: {e.Message}";
                return RedirectToAction(nameof(Edit), new { message = e.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.Remove(id);
                TempData["Success"] = "Employee removed successfully";
                return RedirectToAction(nameof(Index));

            }
            catch (ApplicationException e)
            {

                TempData["Error"] = $"An error occurred: {e.Message}";
                return RedirectToAction(nameof(Edit), new { message = e.Message });
            }
            
        }
    }
}
