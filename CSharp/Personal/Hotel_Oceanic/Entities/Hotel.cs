using Hotel_Oceanic.Entities.Enums;
using Hotel_Oceanic.Entities.Exceptions;

namespace Hotel_Oceanic.Entities
{
    public class Hotel
    {
        public string Nome { get; set; }
        public List<Quarto> Quartos { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Cliente> Clientes { get; set; }

        public Hotel(string nome)
        {
            Nome = nome;
            Quartos = new List<Quarto>();
            Reservas = new List<Reserva>();
            Clientes = new List<Cliente>();
        }

        public void AdicionarQuarto(Quarto quarto)
        {
            if (Quartos.Any(q => q.Numero == quarto.Numero))
            {
                throw new DomainException($"Já existe um quarto com o número {quarto.Numero}.");
            }

            Quartos.Add(quarto);
        }

        public void RemoverQuarto(int numero)
        {
            if (!Quartos.Any(q => q.Numero == numero))
            {
                throw new DomainException($"Quarto com o número {numero} não encontrado.");
            }

            var quarto = Quartos.First(q => q.Numero == numero);
            Quartos.Remove(quarto);

            // Remover reservas do quarto
            Reservas.RemoveAll(r => r.Quarto == quarto);
        }

        public void EditarQuarto(int numeroQuarto, TipoQuarto novoTipo)
        {
            if (!Quartos.Any(q => q.Numero == numeroQuarto))
            {
                throw new DomainException($"Quarto com o número {numeroQuarto} não encontrado.");
            }

            var quarto = Quartos.First(q => q.Numero == numeroQuarto);
            quarto.Tipo = novoTipo;
        }
        public void AdicionarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new DomainException($"Cliente Inválido!");
            }

            if (Clientes.Any(c => c.CPF == cliente.CPF))
            {
                throw new DomainException($"Já existe um cliente com o CPF {cliente.CPF}.");
            }

            Clientes.Add(cliente);
        }

        public void RemoverCliente(string cpf)
        {
            if (!Clientes.Any(c => c.CPF == cpf))
            {
                throw new DomainException($"Cliente com o CPF {cpf} não encontrado.");
            }

            Clientes.Remove(Clientes.First(c => c.CPF == cpf));

            // Remover clientes das reservas
            Reservas.ForEach(r => r.Clientes.RemoveAll(c => c.CPF == cpf));
        }

        public void EditarCliente(Cliente clienteAtual, Cliente clienteAtualizado)
        {
            clienteAtual.Nome = clienteAtualizado.Nome;
            clienteAtual.Sobrenome = clienteAtualizado.Sobrenome;
            clienteAtual.CPF = clienteAtualizado.CPF;
            clienteAtual.DataNascimento = clienteAtualizado.DataNascimento;
        }

        public void AdicionarReserva(Reserva reserva)
        {
            if (Reservas.Any(r => r.Quarto.Numero == reserva.Quarto.Numero))
            {
                throw new DomainException($"Já existe uma reserva para o quarto de número:{reserva.Quarto.Numero}.");
            }

            Reservas.Add(reserva);
        }

        public void MostrarQuartosOcupados()
        {
            Console.WriteLine("Quartos Ocupados:");
            foreach (var quarto in Quartos.Where(q => !q.Disponivel).OrderBy(q => q.Numero))
            {
                Console.WriteLine($"Número: {quarto.Numero} ({quarto.Tipo})");
            }
        }
        public void MostrarQuartosDisponiveis()
        {
            Console.WriteLine($"Quartos Disponiveis:");
            foreach (var quarto in Quartos.Where(q => q.Disponivel).OrderBy(q => q.Numero))
            {
                Console.WriteLine($"Número: {quarto.Numero} ({quarto.Tipo})");
            }
        }

        public void MostrarReservaPorNomeCliente(string nomeCliente)
        {
            var reservasCliente = Reservas.Where(r => r.Clientes.Any(c => c.Nome == nomeCliente));

            if (!reservasCliente.Any())
            {
                Console.WriteLine($"Nenhuma reserva encontrada para o cliente {nomeCliente}.");
            }

            foreach (var reserva in reservasCliente)
            {
                Console.WriteLine($"Reserva {reserva.QuantidadeClientes} pessoas:");
                Console.WriteLine($"Quarto: {reserva.Quarto.Numero} ({reserva.Quarto.Tipo})");
                Console.WriteLine($"Data Reserva: {reserva.DataReserva.ToShortDateString()}");
                Console.WriteLine($"Duração: {reserva.DuracaoReserva} dias");
                Console.WriteLine($"Valor Total: {reserva.ValorTotal:F2}");
            }
        }

        public int ObterNumeroDeQuartoPorNomeCliente(string nomeCliente)
        {
            var reservaCliente = Reservas.FirstOrDefault(r => r.Clientes.Any(c => c.Nome == nomeCliente));

            if (reservaCliente == null)
            {
                return 0; // Cliente não possui reserva
            }

            return reservaCliente.Quarto.Numero;
        }

        public Cliente ObterClientePorCPF(string cpf)
        {
            var cliente = Clientes.Where(c => c.CPF == cpf).FirstOrDefault();

            if (cliente == null)
            {
                throw new DomainException($"Nenhum cliente encontrado para o CPF: {cpf}.");
            }

            return cliente;
        }

        public List<Cliente> ObterClientesPorNumeroQuarto(int numeroQuarto)
        {
            var reservaQuarto = Reservas.FirstOrDefault(r => r.Quarto.Numero == numeroQuarto);

            if (reservaQuarto == null)
            {
                throw new DomainException($"Nenhuma reserva encontrada para o quarto: {numeroQuarto}.");
            }

            return reservaQuarto.Clientes;
        }

        public Decimal CalcularValorTotalReservasAtivas()
        {
            return Reservas.Where(r => r.Quarto.Disponivel == false).Sum(r => r.ValorTotal);
        }
    }
}