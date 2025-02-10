using Hotel_Oceanic.Entities.Enums;

namespace Hotel_Oceanic.Entities
{
    public class Quarto
    {
        public int Numero { get; set; }
        public TipoQuarto Tipo { get; set; }
        public bool Disponivel { get; set; }
        public int Capacidade { get { return ObterCapacidade(); } }
        public decimal CustoDiario { get { return ObterCustoDiario(); } }
        public Quarto(int numero, TipoQuarto tipo)
        {
            Numero = numero;
            Tipo = tipo;
            Disponivel = true;
        }

        private int ObterCapacidade()
        {
            switch (Tipo)
            {
                case TipoQuarto.Simples:
                    return 1;
                case TipoQuarto.Padrão:
                    return 2;
                case TipoQuarto.SuiteSimples:
                    return 3;
                case TipoQuarto.SuiteLuxo:
                    return 4;
                default:
                    throw new Exception("Tipo de quarto inválido.");
            }
        }
        private decimal ObterCustoDiario()
        {
            switch (Tipo)
            {
                case TipoQuarto.Simples:
                    return 35.00m;
                case TipoQuarto.Padrão:
                    return 50.00m;
                case TipoQuarto.SuiteSimples:
                    return 85.00m;
                case TipoQuarto.SuiteLuxo:
                    return 150.00m;
                default:
                    throw new Exception("Tipo de quarto inválido.");
            }
        }
    }
}