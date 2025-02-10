using Hotel_Oceanic.Entities;
using Hotel_Oceanic.Entities.Exceptions;
using Hotel_Oceanic.Menus;

namespace Hotel_Oceanic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar e inicializar o hotel
            var hotel = new Hotel("Oceanic");

            // Loop principal do programa
            while (true)
            {
                try
                {
                    Menu.ExibirMenuPrincipal(hotel);

                    int opcaoMenuPrincipal = Menu.ObterOpcaoUsuario();

                    switch (opcaoMenuPrincipal)
                    {
                        case 1: // Gerenciar Clientes
                            SubMenuClientes.Exibir(hotel);
                            break;
                        case 2: // Gerenciar Quartos
                            SubMenuQuartos.Exibir(hotel);
                            // ... (Implentar submenu e funções de gerenciamento de quartos)
                            break;
                        case 3: // Gerenciar Reservas
                            SubMenuReservas.Exibir(hotel);
                            break;
                        case 4: // Mostrar Informações do Hotel
                                //ExibirSubMenuInformacoesHotel();
                            int opcaoSubMenuInformacoes = Menu.ObterOpcaoUsuario();

                            switch (opcaoSubMenuInformacoes)
                            {
                                case 1: // Mostrar Nome do Hotel
                                        //MostrarNomeHotel(hotel);
                                    break;
                                case 2: // Mostrar Quantidade de Quartos
                                        //MostrarQuantidadeQuartos(hotel);
                                    break;
                                case 3: // Mostrar Quantidade de Clientes
                                        //MostrarQuantidadeClientes(hotel);
                                    break;
                                case 4: // Mostrar Quantidade de Reservas Ativas
                                        //MostrarQuantidadeReservasAtivas(hotel);
                                    break;
                                case 5: // Voltar ao Menu Principal
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida. Tente novamente.");
                                    break;
                            }

                            break;
                        case 5: // Sair
                            Console.WriteLine("Saindo do programa...");
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }

                    // Limpar a tela após cada submenu
                    Console.Clear();
                }
                catch(DomainException exception)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Erro: {exception.Message}");
                    Console.WriteLine();
                    Console.Write("Pressiona qualquer tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
    }
}