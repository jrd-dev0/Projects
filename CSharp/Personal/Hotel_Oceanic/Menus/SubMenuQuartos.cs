using Hotel_Oceanic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Oceanic.Menus
{
    internal class SubMenuQuartos
    {
        public static void Exibir(Hotel hotel)
        {
            Menu.ExibirMenuPrincipal(hotel);
            Console.WriteLine("------------ Gerenciamento de Quartos ------------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. Cadastrar Quarto");
            Console.WriteLine("2. Editar Quarto");
            Console.WriteLine("3. Remover Quarto");
            Console.WriteLine("4. Mostrar Informações dos Quartos");
            Console.WriteLine("5. Voltar");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Digite a opção desejada: ");
            int opcaoSubMenuQuartos = Menu.ObterOpcaoUsuario();
        }
    }
}
