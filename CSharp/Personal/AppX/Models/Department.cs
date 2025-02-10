namespace AppX.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public double TotalSalary(double salary)
        {
            return Employees.Sum(x => x.Salary);
        }
    }
}
