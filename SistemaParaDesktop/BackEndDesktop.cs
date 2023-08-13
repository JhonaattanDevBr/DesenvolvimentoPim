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
            
            
             ObjetofolhaDePagamento.GerarFolhaDePagamento();
            

            /*Console.WriteLine("---TESTE---");
            Console.WriteLine();

            ObjetofolhaDePagamento.CalcularFormulasDoDecimoTerceiro();*/
        }
    }
}