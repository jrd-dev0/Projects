namespace Hotel_Oceanic.Entities
{
    public class Reserva
    {
        private readonly Hotel _hotel;

        public int QuantidadeClientes { get; set; }
        public List<Cliente> Clientes { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataReserva { get; set; }
        public int DuracaoReserva { get; set; }
        public decimal ValorTotal { get; set; }

        public Reserva(int quantidadeClientes, List<Cliente> clientes, Quarto quarto, DateTime dataReserva, int duracaoReserva, Hotel hotel)
        {
            QuantidadeClientes = quantidadeClientes;
            Clientes = clientes;
            Quarto = quarto;
            DataReserva = dataReserva;
            DuracaoReserva = duracaoReserva;
            _hotel = hotel;

            if (QuantidadeClientes > quarto.Capacidade)
            {
                SugerirNovoQuarto();
            }
            else
            {
                RealizarReserva();
            }
        }

        private void RealizarReserva()
        {
            Quarto.Disponivel = false;
            CalcularValorTotal();
        }

        private void SugerirNovoQuarto()
        {
            var quartosDisponiveis = _hotel.Quartos.Where(q => q.Disponivel && q.Capacidade >= QuantidadeClientes).ToList();

            if (quartosDisponiveis.Count > 0)
            {
                Console.WriteLine("O quarto selecionado não possui capacidade para o número de clientes informado.");
                Console.WriteLine("Quartos disponíveis com capacidade adequada:");

                foreach (var quarto in quartosDisponiveis)
                {
                    Console.WriteLine($"{Quarto.Numero}: {quarto.Numero} ({quarto.Tipo})");
                }
                
                var quartoSugerido = quartosDisponiveis.First(q => q.Tipo > Quarto.Tipo);
                Console.WriteLine($"Sugerimos o quarto {quartoSugerido.Numero} ({quartoSugerido.Tipo}) com capacidade para {quartoSugerido.Capacidade} pessoas e desconto de 20%.");
            }
            else
            {
                Console.WriteLine("Não há quartos disponíveis com capacidade para o número de clientes informado.");
            }
        }

        private void CalcularValorTotal()
        {
            ValorTotal = DuracaoReserva * Quarto.CustoDiario;
        }

        public void CancelarReservaAntecipada(DateTime dataCancelamento)
        {
            int diasCancelados = (int)(dataCancelamento - DataReserva).TotalDays;
            DuracaoReserva -= diasCancelados;
            CalcularValorTotal();
            ValorTotal *= 1.15m; // Acrescenta multa de 15%
        }
    }
}