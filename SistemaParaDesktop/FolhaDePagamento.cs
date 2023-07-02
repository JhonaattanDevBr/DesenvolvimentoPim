using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

        public double CalcularValeAlimentacao()
        {
            int DiasUteis;
            double Percentual, ValorDoVale, DescontoDoVale;

            Console.WriteLine("---Vale Refeição/Alimentação---");
            Console.WriteLine();
            Console.Write("-Informe o valor do vale refeição diario: R$ ");
            ValorDoVale = double.Parse(Console.ReadLine());
            Console.Write("-Informe a quantidade de dias uteis do mês: ");
            DiasUteis = int.Parse(Console.ReadLine());
            Console.Write("-Informe o percentual de desconto do vale: ");
            Percentual = double.Parse(Console.ReadLine());
            DescontoDoVale = ValorDoVale * (double) DiasUteis * (Percentual / 100);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"-Valor a se descontado de vale refeição/alimentação: R$ {DescontoDoVale:f2}");
            Console.ReadKey();
                    
            return DescontoDoVale;
            
        }

        public double CalcularInss()
        {
            double Proventos, SalarioBase, PercentualInss, DescontoInss = 0;
            double Parcela1 = 0;
            double Parcela2 = 19.53;
            double Parcela3 = 96.00;
            double Parcela4 = 173.81;
            double Parcela5 = 877.24;
            // O sistema estava retornando o valor errado pois havia esquecido de dizer que o percentual era um número double. Sonso.

            Console.WriteLine("---Calculo do INSS---");
            Console.WriteLine();
            Console.Write("- Informe o valor sobre o qual será gerado o desconto de INSS: R$ ");
            Proventos = double.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------------------------");

            if (Proventos <= 1302.00) {
                Console.WriteLine("---Desconto feito com base na aliquota de 7,5%---");
                Console.WriteLine();
                PercentualInss = 7.5 / 100;
                DescontoInss = (Proventos * PercentualInss) - Parcela1;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoInss:f2}");
                Console.ReadKey();
            }

            else if (Proventos <= 2571.29) {
                Console.WriteLine("---Desconto feito com base na aliquota de 9%---");
                Console.WriteLine();
                PercentualInss = 9.0 / 100;
                DescontoInss = (Proventos * PercentualInss) - Parcela2;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoInss:f2}");
                Console.ReadKey();
            }

            else if (Proventos <= 3856.94) {
                Console.WriteLine("---Desconto feito com base na aliquota de 12%---");
                Console.WriteLine();
                PercentualInss = 12.0 / 100;
                DescontoInss = (Proventos * PercentualInss) - Parcela3;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoInss:f2}");
                Console.ReadKey();
            }

            else if (Proventos <= 7507.49) {
                Console.WriteLine("---Desconto feito com base na aliquota de 14%---");
                Console.WriteLine();
                PercentualInss = 14.0 / 100;
                DescontoInss = (Proventos * PercentualInss) - Parcela4;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoInss:f2}");
                Console.ReadKey();
            }

            else {
                Console.WriteLine("---Valores acima de 7.507.49 R$ possuem um desconto fixo de 877.24 R$---");
                Console.WriteLine();
                DescontoInss = Proventos - Parcela5;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoInss:f2}");
                Console.ReadKey();
            }
            return DescontoInss;
        }
    }
}
