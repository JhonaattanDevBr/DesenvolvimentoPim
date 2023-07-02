using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemaParaDesktop
{
    internal class BackEndDesktop
    {
        static void Main(string[] args)
        {
            FolhaDePagamento ObjetofolhaDePagamento = new FolhaDePagamento();

            /*
            Console.WriteLine("---Calculando o Vale Transporte--");
            Console.WriteLine();
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularValeTransporte();
            Console.WriteLine("-Dígite qualquer tecla para continuar.");
            Console.ReadKey();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("---Calculando o Vale Refeição ou Vale Alimentação---");
            Console.WriteLine();
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularValeAlimentacao();
            Console.WriteLine("-Dígite qualquer tecla para continuar.");
            Console.ReadKey();*/
            Console.WriteLine("---Calculando o INSS---");
            Console.WriteLine();
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularInss();
        }
    }
}