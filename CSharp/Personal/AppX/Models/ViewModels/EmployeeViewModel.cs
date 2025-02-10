namespace AppX.Models.ViewModels
{
    public class EmployeeViewModel : Employee
    {
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}