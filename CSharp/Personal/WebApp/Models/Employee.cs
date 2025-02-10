using WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Employee() { }
        public Employee(int id, string name, string surname, string email, double salary, Profile profile)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Salary = salary;
            Email = email;
            Login = GetLogin(name, surname);
            Profile = profile;
            Password = Login.ToUpper();
            RegistrationDate = DateTime.Now;
        }

        public string GetLogin(string name, string surname)
        {
            foreach(char c in surname)
            {
                if (c == ' ')
                {
                    string[] vet = surname.Split(' ');

                    string login = $"{name}.{vet[vet.Length-1]}";

                    return login.ToLower();
                }
            }

            return $"{name.ToLower()}.{surname.ToLower()}";
        }
    }
}
