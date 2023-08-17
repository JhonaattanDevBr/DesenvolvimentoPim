using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParaDesktop
{
    public class Ferias
    {
        FolhaDePagamento FolhaDePagamento = new FolhaDePagamento();
        private int DiasGozados { get; set; }
        private int Saida { get; set; }
        private int Retorno { get; set; }
        private double LiquidoDeDeFerias { get; set; }

        public void ConsultarBeneficioDasFerias()
        {
            // Aqui eu vou fazer algumas consultas ao banco de dados e retornar algumas informações para o usuario.
        }

        public double OpcaoDeFerias()
        {
            //Aqui eu vou mostrar ao usuario as opções de férias que ele possui
            return DiasGozados;
        }

        public double CalcularFerias()
        {
            double salarioBase, umTerco, salarioBrutoFerias, inss, irrf, pensao, dependente, valorDasFerias;

            Console.WriteLine("- Primeiro passo para calcular as férias:");
            Console.WriteLine();
            Console.WriteLine("- Calcular pensão.");
            pensao = this.FolhaDePagamento.CalcularPensao();
            Console.WriteLine();

            Console.WriteLine("- Segundo passo para calcular as férias:");
            Console.WriteLine();
            Console.WriteLine("- Calcular dependentes.");
            dependente = this.FolhaDePagamento.CalcularDependencia();
            Console.WriteLine();

            Console.WriteLine("- Terceiro passo para calcular as férias:");
            Console.WriteLine();
            Console.Write("- Informe o salário base do funcionario: R$ ");
            salarioBase = double.Parse(Console.ReadLine());
            umTerco = salarioBase / 3;
            salarioBrutoFerias = salarioBase + umTerco;
            Console.WriteLine();
            Console.WriteLine($"- O salario bruto das férias é de: R$ {salarioBrutoFerias:f2}");
            Console.WriteLine();

            inss = FolhaDePagamento.FormulaDoInss(salarioBrutoFerias);
            irrf = FolhaDePagamento.FormulaDoIrrf(salarioBrutoFerias, inss, pensao, dependente);
            valorDasFerias = salarioBrutoFerias - inss - irrf;
            Console.WriteLine();

            Console.WriteLine($"- O valor das férias que o funcionario ira receber é de: R$ {valorDasFerias:f2}");

            return valorDasFerias;
            // Aqui vai estar o calculo comun das férias.
           // return LiquidoDeDeFerias;
        }

        public double CalcularVendaDasFerias()
        {
            // Aqui eu vou calcular o valor dos dias vendidos das ferias recebendo a quantidade de dias por parametros e retornando o valor da venda.
            double valor = 0;
            return valor;
        }



    }
}
