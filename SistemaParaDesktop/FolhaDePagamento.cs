using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParaDesktop
{
    public class FolhaDePagamento
    {
        private double _salarioBruto { get; set; }
        private double _salarioLiquido { get; set; }
        private double _desconto { get; set; }
        private string _quantidadeHoras { get; set; }
        private double _resultado { get; set; }

        public double CalcularValeTransporte()
        {
            double Porcentagem, Passagem, ValorPorcentagem,ValorPassagem;
            int DiasUteis;

            Console.WriteLine("-Vamos verificar qual o menor valor para desconto do VT.");
            Console.WriteLine();

            Console.WriteLine("-Primeiro passo:");
            Console.Write("-Ensira o Sálario bruto do funcionario: R$ ");
            _salarioBruto = double.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-Segundo passo:");
            Console.Write("-Ensira a porcentagem correspondente ao vale transporte: ");
            Porcentagem = double.Parse(Console.ReadLine());
            ValorPorcentagem = _salarioBruto * (Porcentagem / 100); // O erro estava no calculo a operação de precedencia deveria ser de divisão.. 
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-Terceiro passo:");
            Console.Write("-Ensira o valor da passagem somando ida e volta: R$ ");
            Passagem = double.Parse(Console.ReadLine());
            Console.Write("-Ensira a quantidade de dias uteis: ");
            DiasUteis = int.Parse(Console.ReadLine());
            ValorPassagem =  Passagem * (double) DiasUteis;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            if(ValorPorcentagem < ValorPassagem)
            {
                Console.WriteLine("\t-Menor Valor.");
                Console.Write($"-Valor a ser descontado por porcentagem: R$ {ValorPorcentagem:f2}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t-Maior valor.");
                Console.Write($"-Valor a ser descontado por dias uteis: R$ {ValorPassagem:f2}");
                Console.ReadKey();
                Console.WriteLine();
                return ValorPorcentagem;
            }
            else
            {
                Console.WriteLine("\t-Menor valor.");
                Console.Write($"-Valor a ser descontado por dias uteis: R$ {ValorPassagem:f2}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t-Maior valor.");
                Console.Write($"-Valor a ser descontado por porcentagem: R$ {ValorPorcentagem:f2}");
                Console.ReadKey();
                Console.WriteLine();
                return ValorPassagem;
            }
        }
    }
}
