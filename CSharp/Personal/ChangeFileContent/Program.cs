using System;
using System.IO;

//::TODO::

//1.Obter o arquivo a ser lido ou a pasta que contém os arquivos;
//1.1 Caso seja uma pasta, listar os arquivos contido na pasta e solicitar que seja informado o arquivo;
//2.Ler o arquivo e armazenar seu conteúdo;
//3.Exibir opções para Fazer uma cópia ou alterar alguma linha do arquivo;
//3.1 Caso seja uma cópia, solicitar o novo nome do arquivo e o local para armazenamento;
//3.2 Caso seja uma alteração, solicitar a linha que deverá ser alterada;
//3.2.1 Exibir o conteúdo da linha a ser alterada;
//3.2.2 Solicitar o novo conteúdo da linha a ser alterada;
//4.Exibir o conteudo do arquivo
//4.1 Exibir linha alterada em vermelho
// C:\Intel\Logs

namespace ChangeFileContent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Write("Informe o caminho do arquivo ou a pasta: ");
                string fileOrFolder = Console.ReadLine();

                if (File.Exists($@"{fileOrFolder}"))
                {
                    string file = fileOrFolder;
                }
                else
                {
                    var folder = Directory.EnumerateFiles(fileOrFolder, "*.*", SearchOption.TopDirectoryOnly);

                    Console.WriteLine("Folder Content:");

                    int i = 0;
                    foreach (string line in folder)
                    {
                        Console.WriteLine($"{i}. {line}");
                        i++;
                    }

                    Console.Write("Select file to edit: ");
                    int selectFile = int.Parse(Console.ReadLine());

                    folder[selectFile];
                    
                    Console.WriteLine();


                    Console.WriteLine("File selected: {}");
                }

            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }






        }
    }
}
