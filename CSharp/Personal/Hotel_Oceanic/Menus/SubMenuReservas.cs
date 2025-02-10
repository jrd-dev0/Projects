using Hotel_Oceanic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Oceanic.Menus
{
    internal class SubMenuReservas
    {
        public static void Exibir(Hotel hotel)
        {
            Menu.ExibirMenuPrincipal(hotel);
            Console.WriteLine("------------ Gerenciamento de Reservas -----------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. Cadastrar Reserva");
            Console.WriteLine("2. Editar Reserva");
            Console.WriteLine("3. Remover Reserva");
            Console.WriteLine("4. Mostrar Informações das Reservas");
            Console.WriteLine("5. Voltar");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Digite a opção desejada: ");
            int opcaoSubMenuReservas = Menu.ObterOpcaoUsuario();
        }
    }
}
