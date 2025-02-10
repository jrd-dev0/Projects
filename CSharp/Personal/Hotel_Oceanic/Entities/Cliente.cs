namespace Hotel_Oceanic.Entities
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente(string nome,  string sobrenome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }
    }
}