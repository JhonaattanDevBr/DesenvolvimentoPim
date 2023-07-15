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
        private double _DescontoInss { get; set; }
        private double AdiantamentoQuinzenal { get; set; }
        private double ValorTotalDePericulosidadeEInsalubridade { get; set; }
        //private double ValorTotalDeInsalubridade { get; set; }

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
                _DescontoInss = (Proventos * PercentualInss) - Parcela1;
                Console.Write($"- Valor de Desconto do INSS: R$ {_DescontoInss:f2}");
                Console.ReadKey();
            }

            else if (Proventos <= 2571.29) {
                Console.WriteLine("---Desconto feito com base na aliquota de 9%---");
                Console.WriteLine();
                PercentualInss = 9.0 / 100;
                _DescontoInss = (Proventos * PercentualInss) - Parcela2;
                Console.Write($"- Valor de Desconto do INSS: R$ {_DescontoInss:f2}");
                Console.ReadKey();
            }

            else if (Proventos <= 3856.94) {
                Console.WriteLine("---Desconto feito com base na aliquota de 12%---");
                Console.WriteLine();
                PercentualInss = 12.0 / 100;
                _DescontoInss = (Proventos * PercentualInss) - Parcela3;
                Console.Write($"- Valor de Desconto do INSS: R$ {_DescontoInss:f2}");
                Console.ReadKey();
            }

            else if (Proventos <= 7507.49) {
                Console.WriteLine("---Desconto feito com base na aliquota de 14%---");
                Console.WriteLine();
                PercentualInss = 14.0 / 100;
                _DescontoInss = (Proventos * PercentualInss) - Parcela4;
                Console.Write($"- Valor de Desconto do INSS: R$ {_DescontoInss:f2}");
                Console.ReadKey();
            }

            else {
                Console.WriteLine("---Valores acima de 7.507.49 R$ possuem um desconto fixo de 877.24 R$---");
                Console.WriteLine();
                _DescontoInss = Proventos - Parcela5;
                Console.Write($"- Valor de Desconto do INSS: R$ {_DescontoInss:f2}");
                Console.ReadKey();
            }
            return _DescontoInss;
        }

        public double CalcularIr()
        {
            double SalarioBruto, BaseIr, Inss, Pensao = 0, Dependente = 0, Percentual, DescontoIr = 0;
            double Parcela2 = 142.80;
            double Parcela3 = 354.80;
            double Parcela4 = 636.13;
            double Parcela5 = 869.69;

            Console.WriteLine("---Calculo do IR---");
            Console.WriteLine();
            /* A formula para calcular o IR é: Proventos (entradas) - INSS - Pensão - Dependentes. O valor obtido desse calculo vai ser atribuido a porcentagem de acordo
             com a tabela de desconto do IR.
            O valor por dependentes é de R$ 189,59 */

            Console.Write("- Informe o salário bruto do funcionário: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            Inss = _DescontoInss;
           // Pensao = this.CalcularPensao(); Ainda irei incluir este método.
           // Dependente = this.CalcularDependencia(); Ainda irei incluir este método.
            BaseIr = SalarioBruto - Inss - Pensao - Dependente;
            Console.WriteLine();

            if ( BaseIr <= 1903.98)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {BaseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 0,00%.");
                Console.WriteLine();
                Console.WriteLine("- Isento do desconto de IR, parcela a deduzir: R$ 0,00.");
                Console.ReadKey();
            }
            else if(BaseIr <= 2826.65)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {BaseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 7,50%.");
                Console.WriteLine();
                Percentual = 7.50 / 100;
                DescontoIr = (BaseIr * Percentual) - Parcela2;
                Console.Write($"- Valor de Desconto do IR: R$ {DescontoIr:f2}");
                Console.ReadKey();
            }
            else if (BaseIr <= 3751.05)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {BaseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 15,00%.");
                Console.WriteLine();
                Percentual = 15.00 / 100;
                DescontoIr = (BaseIr * Percentual) - Parcela3;
                Console.Write($"- Valor de Desconto do IR: R$ {DescontoIr:f2}");
                Console.ReadKey();
            }
            else if( BaseIr <= 4664.68)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {BaseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 22,50%.");
                Console.WriteLine();
                Percentual = 22.50 / 100;
                DescontoIr = (BaseIr * Percentual) - Parcela4;
                Console.Write($"- Valor de Desconto do IR: R$ {DescontoIr:f2}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {BaseIr:f2}");
                Console.WriteLine("- Base de cálculo de IR maior que 4.664,687 o desconto feito com base na aliquota de: 27,50%.");
                Console.WriteLine();
                Percentual = 27.50 / 100;
                DescontoIr = (BaseIr * Percentual) - Parcela5;
                Console.Write($"- Valor de Desconto do IR: R$ {DescontoIr:f2}");
                Console.ReadKey();
            }
            return DescontoIr;
            
        }

        public double CalcularAdiantamentoQuinzenal()
        {
            Console.Write("Informe o Salario bruo: R$ ");
            _salarioBruto = double.Parse(Console.ReadLine());
            Console.WriteLine();

            double Porcentagem = 0.4;

            AdiantamentoQuinzenal = _salarioBruto * Porcentagem;
            Console.WriteLine($"Valor do Salário bruto: R$ {_salarioBruto:f2}");
            Console.WriteLine($"Valor do Adiantamento: R$ {AdiantamentoQuinzenal:f2}");

            return AdiantamentoQuinzenal;
        }

        public double CalcularHoraExtra()
        {
            double ValorHora, Porcentagem = 0.5, ValorHoraExtra, Hora, ValorTotalHoraExtra = 0;
            //double HoraMes; - Vou utilizar esta forma quando tiver os métodos todos feitos.
            //double PorcentagemVariavel; vai ser utilizado mais a frente para as Org decidirem qual a porcentagem de Hora Extra deve ser somada.
            //double PorcentagemDeCemPorCento = 1; 

            Console.Write("- Informe seu salario bruto: R$ ");
            _salarioBruto = double.Parse(Console.ReadLine());
            //Console.Write("- Informe  quantidade de horas trabalhadas ao mes: "); - Vou utilizar esta forma quando tiver os métodos todos feitos.
            
            ValorHora = _salarioBruto / 220;
            ValorHoraExtra = ValorHora + (ValorHora * Porcentagem);

            Console.Write("- Informe a quantidade de horas feita de extra: ");
            Hora = double.Parse(Console.ReadLine());
            ValorTotalHoraExtra = Hora * ValorHoraExtra;
            Console.WriteLine();

            Console.WriteLine($"- Valor da hora: R${ValorHora:f2}");
            Console.WriteLine($"- Valor da hora extra: R${ValorHoraExtra:f2}");
            Console.WriteLine($"- Valor total hora extra: R$ {ValorTotalHoraExtra:f2}");

            return ValorHoraExtra;
            
        }

        public double CalcularPericulosidadeEInsalubridade()
        {
            
            double ValorDaPorcentagem;
            int Beneficio;

            Console.WriteLine("---Calculando periculosidade e insalubridade---");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: ");
            _salarioBruto = double.Parse(Console.ReadLine());
            double SalarioBruto = _salarioBruto;
            Console.WriteLine();
            Console.WriteLine("- Informe qual o tipo de benefício do funcionário.");
            Console.WriteLine();
            Console.WriteLine("- Dígite [1] para Periculosidade.");
            Console.WriteLine("- Dígite [2] para Insalubridade.");
            Console.Write("- Benefício..: ");
            Beneficio = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (Beneficio)
            {
                case 1:
                    Console.WriteLine("---Cálculo de Periculosidade---");
                    Console.WriteLine();
                    
                    ValorDaPorcentagem = SalarioBruto * 0.3;
                    ValorTotalDePericulosidadeEInsalubridade = ValorDaPorcentagem + SalarioBruto;
                    Console.WriteLine($"- Valor de acréscimo devido a periculosidade é de 30% que corresponde a: R$ {ValorDaPorcentagem:f2}");
                    Console.WriteLine($"- Valor do salário base acrescido do percentual de periculosidade: R$ {ValorTotalDePericulosidadeEInsalubridade:f2}"); //Depois vou tirar essa linha porque eu não vou precisar retornar o valor ja acrescido, somento o valor que vai ser acrescido.
                    Console.ReadKey();
                    break;

                case 2:
                    Console.WriteLine("---Cálculo da Insalubridade---");
                    Console.WriteLine();
                    
                    int Grau;

                    Console.WriteLine("- Informe qual o grau de insalubridade sobre o qual o funcionario exerce sua função.");
                    Console.WriteLine();
                    Console.WriteLine("- Dígite [1] para leve/10%.");
                    Console.WriteLine("- Dígite [2] para médio/20%");
                    Console.WriteLine("- Dígite [3] para gráve/40%");
                    Console.Write("- Grau...: ");
                    Grau = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if( Grau == 1 )
                    {
                        ValorDaPorcentagem = SalarioBruto * 0.1;
                        ValorTotalDePericulosidadeEInsalubridade = ValorDaPorcentagem + SalarioBruto;
                        Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 10% correspodente a: R$ {ValorDaPorcentagem:f2}");
                        Console.WriteLine($"- Valor do salário acrescido do percentual de insalubridade de 10% correspode a: R$ {ValorTotalDePericulosidadeEInsalubridade:f2}");
                        Console.ReadKey();
                    }
                    else if( Grau == 2)
                    {
                        ValorDaPorcentagem = SalarioBruto * 0.2;
                        ValorTotalDePericulosidadeEInsalubridade = ValorDaPorcentagem + SalarioBruto;
                        Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 20% correspodente a: R$ {ValorDaPorcentagem:f2}");
                        Console.WriteLine($"- Valor do salário acrescido do percentual de insalubridade de 20% correspode a: R$ {ValorTotalDePericulosidadeEInsalubridade:f2}");
                        Console.ReadKey();
                    }
                    else if( Grau == 3)
                    {
                        ValorDaPorcentagem = SalarioBruto * 0.4;
                        ValorTotalDePericulosidadeEInsalubridade = ValorDaPorcentagem + SalarioBruto;
                        Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 40% correspodente a: R$ {ValorDaPorcentagem:f2}");
                        Console.WriteLine($"- Valor do salário acrescido do percentual de insalubridade de 40% correspode a: R$ {ValorTotalDePericulosidadeEInsalubridade:f2}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("- ERRO! Opção inválida, selecione entre [1] ou [2].");
                        Console.WriteLine("- Dígite qualquer coisa para retornar.");
                        Console.ReadKey();
                    }
                    break;

                default:
                    Console.WriteLine("- ERRO! Opção inválida, selecione entre [1] ou [2].");
                    Console.WriteLine("- Dígite qualquer coisa para retornar.");
                    Console.ReadKey();
                    break;
            }
            return ValorTotalDePericulosidadeEInsalubridade;


        }
    }
}
