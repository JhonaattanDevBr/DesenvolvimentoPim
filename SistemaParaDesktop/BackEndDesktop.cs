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

            Console.WriteLine("Vamos gerar a folha de pagamento");
            Console.WriteLine();
            Console.WriteLine();
             ObjetofolhaDePagamento.GerarFolhaDePagamento();
        }
    }
}