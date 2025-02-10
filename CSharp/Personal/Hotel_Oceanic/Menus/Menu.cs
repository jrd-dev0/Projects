using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Oceanic.Entities;
using Hotel_Oceanic.Entities.Enums;

namespace Hotel_Oceanic.Menus
{
    internal class Menu
    {
        // Funções para exibir os menus e obter a opção do usuário
        public static void ExibirTituloHotel(Hotel hotel)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"                    Hotel {hotel.Nome}");
            Console.WriteLine("--------------------------------------------------");
        }
        public static void ExibirMenuPrincipal(Hotel hotel)
        {
            ExibirTituloHotel(hotel);
            Console.WriteLine("------------ Sistema de Gerenciamento ------------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. Gerenciar Clientes");
            Console.WriteLine("2. Gerenciar Quartos");
            Console.WriteLine("3. Gerenciar Reservas");
            Console.WriteLine("4. Mostrar Informações do Hotel");
            Console.WriteLine("5. Sair");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Digite a opção desejada: ");
        }

        public static int ObterOpcaoUsuario()
        {
            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                Console.WriteLine();
                Console.Write("Digite a opção desejada: ");
            }
            return opcao;
        }
        

        
        
        // **Funções para gerenciar reservas(exemplos):**

        public static void CadastrarReserva(Hotel hotel)
        {
            // Implementar lógica para cadastrar uma nova reserva
            // (Pedir informações de clientes, quarto, data, etc.)
            Console.WriteLine("Função de Cadastrar Reserva implementada!");
        }

        public static void EditarReserva(Hotel hotel)
        {
            // Implementar lógica para editar uma reserva existente
            // (Pedir o código da reserva e permitir a alteração de alguns dados)
            Console.WriteLine("Função de Editar Reserva implementada!");
        }

        public static void RemoverReserva(Hotel hotel)
        {
            // Implementar lógica para remover uma reserva existente
            // (Pedir o código da reserva e confirmar a remoção)
            Console.WriteLine("Função de Remover Reserva implementada!");
        }

        public static void MostrarReservasPorNomeCliente(Hotel hotel)
        {
            // Implementar lógica para exibir reservas por nome do cliente
            // (Pedir o nome do cliente e mostrar as reservas associadas)
            Console.WriteLine("Função de Mostrar Reservas por Nome do Cliente implementada!");
        }

        public static void MostrarReservasAtivas(Hotel hotel)
        {
            // Implementar lógica para exibir todas as reservas ativas
            // (Exibir detalhes de cada reserva ativa)
            Console.WriteLine("Função de Mostrar Reservas Ativas implementada!");
        }

        // **Funções para exibir informações do hotel(exemplos) :**

        public static void MostrarNomeHotel(Hotel hotel)
        {
            Console.WriteLine($"Nome do Hotel: {hotel.Nome}");
        }

        public static void MostrarQuantidadeQuartos(Hotel hotel)
        {
            Console.WriteLine($"Quantidade de Quartos: {hotel.Quartos.Count}");
        }

        public static void MostrarQuantidadeClientes(Hotel hotel)
        {
            Console.WriteLine($"Quantidade de Clientes: {hotel.Clientes.Count}");
        }

        public static void MostrarQuantidadeReservasAtivas(Hotel hotel)
        {
            int reservasAtivas = hotel.Reservas.Count(r => r.DataReserva.AddDays(r.DuracaoReserva) >= DateTime.Today);
            Console.WriteLine($"Quantidade de Reservas Ativas: {reservasAtivas}");
        }
    }
}