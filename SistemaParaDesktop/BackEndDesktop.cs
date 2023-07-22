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
            Console.ReadKey();
            Console.WriteLine("---Calculando o INSS---");
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularInss();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("---Calculando o IR---");
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularIr();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("--Calculando o adiantamento quinzenal--");
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularAdiantamentoQuinzenal();

            Console.WriteLine("---Calculando hora extra---");
            Console.WriteLine();
            ObjetofolhaDePagamento.CalcularHoraExtra();

            Console.WriteLine("---Calculando---");
            ObjetofolhaDePagamento.CalcularPericulosidadeEInsalubridade();

            Console.WriteLine("---Adicional Noturno---");
            ObjetofolhaDePagamento.CalcularAdicionalNoturno();

            Console.WriteLine("---Convenio Médico---");
            ObjetofolhaDePagamento.CalcularConvenioMedico();

            Console.WriteLine("---Convenio Odontológico---");
            ObjetofolhaDePagamento.CalcularConvenioOdontologico()

            Console.WriteLine("---Dependetes---");
            ObjetofolhaDePagamento.CalcularDependencia();

            Console.WriteLine("---Calculo da Pensão---");
            ObjetofolhaDePagamento.CalcularPensao();

            Console.WriteLine("---Atrasos---");
            ObjetofolhaDePagamento.CalcularAtrasos();*/

            Console.WriteLine("---FGTS---");
            ObjetofolhaDePagamento.CalcularFgts();
        }
    }
}