using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            string entrada = File.ReadAllText(@"..\..\prueba.txt");

            Console.WriteLine("Entrada:\n");
            Console.WriteLine(entrada);
            Console.WriteLine();

            var gramatica = new Gramatica();
            var parser = new Parser(gramatica);
            var arbol = parser.Parse(entrada);

            if (arbol.Root == null)
            {
                Console.WriteLine("Analisis Lexico Sintactico Fallido :(");
            }
            else
            {
                Console.WriteLine("Analisis Lexico Sintactico Exitoso :D");
            }

            Console.ReadLine();
        }
    }
}
