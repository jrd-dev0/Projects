using Hotel_Oceanic.Entities;
using System.Globalization;

namespace Hotel_Oceanic.Menus
{
    internal class SubMenuClientes
    {
        //Exibir o cabeçalho do SubMenu
        private static void ExibirCabecalho()
        {
            Console.WriteLine("------------ Gerenciamento de Clientes -----------");
            Console.WriteLine("--------------------------------------------------");
        }
        //Exibir as opções do subMenu
        public static void Exibir(Hotel hotel)
        {
            Menu.ExibirTituloHotel(hotel);
            ExibirCabecalho();
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Editar Cliente");
            Console.WriteLine("3. Remover Cliente");
            Console.WriteLine("4. Exibir lista dos Clientes");
            Console.WriteLine("5. Exibir Informação do Cliente");
            Console.WriteLine("6. Voltar");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Digite a opção desejada: ");
            int opcaoSubMenuClientes = Menu.ObterOpcaoUsuario();
            ExibirOpcoes(opcaoSubMenuClientes, hotel);
        }
        public static void ExibirOpcoes(int opcaoSubMenu, Hotel hotel)
        {
            switch (opcaoSubMenu)
            {
                case 1: // Cadastrar Cliente
                    CadastrarCliente(hotel);
                    Exibir(hotel);
                    break;
                case 2: // Editar Cliente
                    EditarCliente(hotel);
                    Exibir(hotel);
                    break;
                case 3: // Remover Cliente
                    Menu.RemoverReserva(hotel);
                    break;
                case 4: // Mostrar Listas dos Clientes
                    break;
                case 5: // Mostrar Informações de um cliente
                    break;
                case 6: // Voltar ao Menu Principal
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        // Menu para obter as informações do cliente para cadastro.
        private static void CadastrarCliente(Hotel hotel)
        {
            Menu.ExibirTituloHotel(hotel);
            ExibirCabecalho();
            Console.WriteLine("1. Cadastro de Cliente");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Forneça as informações do Cliente:");

            string nome = SolicitarInformacao("Nome do Cliente", 3);
            string sobrenome = SolicitarInformacao("Sobrenome do Cliente", 3);
            string cpf = SolicitarInformacao("CPF do Cliente (Apenas números - Ex. 12345678900)", 11);
            cpf = string.Format("{0:000\\.000\\.000-00}", double.Parse(cpf));
            DateTime dataNascimento = SolicitarData("Data de Nascimento do Cliente (Ex. 01/01/2000)");

            Cliente cliente = new Cliente(nome, sobrenome, cpf, dataNascimento);
            hotel.AdicionarCliente(cliente);
        }

        private static string SolicitarInformacao(string descricao, int tamanhoMinimo)
        {
            Console.Write($" - {descricao}: ");
            string texto = "";
            while (texto is null || texto.Length < tamanhoMinimo)
            {
                texto = Console.ReadLine();

                if (texto == null || texto.Length < tamanhoMinimo)
                {
                    Console.WriteLine();
                    Console.WriteLine($"O {descricao.ToLower()} não pode ter menos que {tamanhoMinimo} caracteres");
                    Console.Write($"Informe o {descricao}: ");
                }
            }
            return texto;
        }

        private static DateTime SolicitarData(string descricao)
        {
            Console.Write($" - {descricao}: ");
            string dataInput = "";
            DateTime data;
            while (true)
            {
                dataInput = Console.ReadLine();

                if (!DateTime.TryParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                {
                    Console.WriteLine("A data está inválida, precisa ser digitada no padrão (Ex. 01/01/2000).");
                    Console.Write($"Informe a {descricao}: ");
                    Console.WriteLine();
                }
                else
                {
                    return data;
                }
            }
        }

        private static void EditarCliente(Hotel hotel)
        {
            Menu.ExibirTituloHotel(hotel);
            ExibirCabecalho();
            Console.WriteLine("2. Editar Cliente");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Forneça as informações do Cliente:");

            string cpfPesquisa = SolicitarInformacao("CPF do Cliente (Apenas números - Ex. 12345678900)", 11);
            cpfPesquisa = string.Format("{0:000\\.000\\.000-00}", double.Parse(cpfPesquisa));

            Cliente clienteAtual = hotel.ObterClientePorCPF(cpfPesquisa);
            ExibirInformacoesCliente(clienteAtual);

            string nome = SolicitarInformacao("Primeiro Nome do Cliente", 3);
            string sobrenome = SolicitarInformacao("Sobrenome do Cliente", 3);
            string cpf = SolicitarInformacao("CPF do Cliente (Apenas números - Ex. 12345678900)", 11);
            cpf = string.Format("{0:000\\.000\\.000-00}", double.Parse(cpf));
            DateTime dataNascimento = SolicitarData("Data de Nascimento do Cliente (Ex. 01/01/2000)");

            hotel.EditarCliente(clienteAtual, new Cliente(nome, sobrenome, cpf, dataNascimento));
        }
        
        private static void ExibirInformacoesCliente(Cliente cliente)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Sobrenome: {cliente.Sobrenome}");
            Console.WriteLine($"CPF: {cliente.CPF}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
        }
    }
}