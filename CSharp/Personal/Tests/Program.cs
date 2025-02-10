namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Hommer";
            string surname = "Da Silva Santos";

            string[] vet = surname.Split(' ');

            string login = GetLogin(name, surname);

            Console.WriteLine(login);
            Console.WriteLine("---");
            Console.WriteLine(vet.Length-1);
            Console.WriteLine(vet[0]);
            Console.WriteLine(vet[1]);
            Console.WriteLine(vet[2]);
            Console.WriteLine("---");
            Console.WriteLine(vet[vet.Length - 1]);
            Console.WriteLine("---");
            foreach (char c in surname)
            {
                if (c == ' ')
                {
                    Console.WriteLine("Found");
                }
            }
        }

        public static string GetLogin(string name, string surname)
        {
            foreach (char c in surname)
            {
                if (c == ' ')
                {
                    string[] vet = surname.Split(' ');

                    string login = $"{name}.{vet[vet.Length - 1]}";

                    return login.ToLower();
                }
            }

            return $"{name.ToLower()}.{surname.ToLower()}";
        }
    }
}