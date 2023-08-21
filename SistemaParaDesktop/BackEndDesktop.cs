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
            Ferias ObjFerias = new Ferias();

            //ObjetofolhaDePagamento.GerarFolhaDePagamento();
            Console.WriteLine("TESTE do metodo calcular férias.");
            Console.WriteLine();
            Console.WriteLine();
            ObjFerias.AgendarFerias();
            

            /*Console.WriteLine("---TESTE---");
            Console.WriteLine();

            ObjetofolhaDePagamento.CalcularFormulasDoDecimoTerceiro();*/
        }
    }
}