using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics.Metrics;

namespace SistemaParaDesktop
{
    public class FolhaDePagamento
    {
        // Terei que refatoras todo o código inserindo tratamento de erros, laços de repetição etc a todos os metodos. 
        private double SalarioBase { get; set; }
        private double Vencimentos { get; set; }
        private double SalarioLiquido { get; set; }
        private double Descontos { get; set; }
        private double DescontoDoValeTransporte { get; set; }
        private double DescontoDoValeRefeicaoAlimentacao { get; set; }
        private double DescontoDoInss { get; set; }
        private double DescontoDoIrrf { get; set; }
        private double AdiantamentoQuinzenal { get; set; }
        private double TotalDeHorasExtras { get; set; }
        private double ValorTotalDePericulosidadeInsalubridade { get; set; }
        private double ValorDoAdicionalNoturno { get; set; }
        private double DescontoDoConvenioMedico { get; set; }
        private double DescontoDoConvenioOdontologico { get; set; }
        private double DescontoTotalDeDependentes { get; set; }
        private double DescontoTotalDePensao { get; set; }
        private double DescontoDeAtrasos { get; set; }
        private double TotalDeHorasConvertidas { get; set; }
        private double TotalDeAtrasos { get; set; }
        private double FaltasInjustificadasComDsr { get; set; }
        private double DescontoDeFaltasInjustificadas { get; set; }
        private double ValorDoDecimoTerceiroSalarioLiquido { get; set; }
        private double ValorDoDecimoTerceiroSalarioBruto { get; set; }
        private double InssSobreDecimoTerceiro { get; set; }
        private double IrrfSobreDecimoTerceiro { get; set; }
        private double Fgts { get; set; }

        public double CalcularValeTransporte()
        {
            double porcentagem, passagem, valorPorcentagem,valorPassagem, salarioBruto;
            int diasUteis;

            Console.WriteLine("- Vamos verificar qual o menor valor para desconto do vale transporte.");
            Console.WriteLine();

            Console.Write("- Primeiro informe o salário bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Segundo informe a porcentagem correspondente ao vale transporte: ");
            porcentagem = double.Parse(Console.ReadLine());
            valorPorcentagem = salarioBruto * (porcentagem / 100);
            Console.Write("- Terceiro informe o valor da passagem somando ida e volta: R$ ");
            passagem = double.Parse(Console.ReadLine());
            Console.Write("- Quarto informe a quantidade de dias uteis: ");
            diasUteis = int.Parse(Console.ReadLine());
            valorPassagem =  passagem * (double) diasUteis;
            Console.WriteLine();

            if(valorPorcentagem < valorPassagem)
            {
                Console.Write($"- Menor valor: Valor a ser descontado por porcentagem R$ {valorPorcentagem:f2}");
                Console.WriteLine();
                Console.ReadKey();
                DescontoDoValeTransporte = valorPorcentagem;
                return DescontoDoValeTransporte;
            }
            else
            {
                Console.Write($"- Menor valor: Valor a ser descontado por dias uteis R$ {valorPassagem:f2}");
                Console.WriteLine();
                Console.ReadKey();
                DescontoDoValeTransporte = valorPassagem;
                return DescontoDoValeTransporte;
            }
        } 

        public double CalcularValeAlimentacao()
        {
            int diasUteis;
            double percentual, valorDoVale, descontoDoVale;

            Console.Write("- Informe o valor do vale refeição/alimentação diario: R$ ");
            valorDoVale = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de dias uteis do mês: ");
            diasUteis = int.Parse(Console.ReadLine());
            Console.Write("- Informe o percentual de desconto do vale: ");
            percentual = double.Parse(Console.ReadLine());
            descontoDoVale = valorDoVale * (double) diasUteis * (percentual / 100);
            Console.WriteLine();
            Console.WriteLine($"- Valor a se descontado de vale refeição/alimentação: R$ {descontoDoVale:f2}");
            Console.ReadKey();
            DescontoDoValeRefeicaoAlimentacao = descontoDoVale;
            return DescontoDoValeRefeicaoAlimentacao;
        } 

        public double CalcularInss()
        {
            // o descontro do INSS é aplicado sobre a soma de todos os proventos/entradas que o funcionario tiver.

            double percentualInss, valorParaCalculoDoInss;
            double parcela1 = 0, parcela2 = 19.80, parcela3 = 96.94, parcela4 = 174.08, parcela5 = 877.24;
            double salarioBruto = SalarioBase;
            double horasExtras = TotalDeHorasExtras;
            double periculosidadeInsalubridade = ValorTotalDePericulosidadeInsalubridade;
            double adicionalNoturno = ValorDoAdicionalNoturno;
            // double ferias =  Ainda não tenho este método então vou deixar esta linha comentada e liga-la ao código depois de criar o método.
            // double adiantamentoDecimoTerceiro = Ainda não tenho este método então vou deixar esta linha comentada e liga-la ao código depois de criar o método.
            valorParaCalculoDoInss = salarioBruto + horasExtras + periculosidadeInsalubridade + adicionalNoturno;

            Console.WriteLine("- IMPORTANTE: O desconto do INSS é cálculado sobre a soma de todos os proventos que o funcionario obteve ao mês");
            Console.WriteLine($"- Valor obtido para calculo do INSS: R$ {valorParaCalculoDoInss:f2}");
            Console.WriteLine();
            Console.WriteLine("- Agora vejamos sobre qual índice da tabela do INSS sera aplicado o calculo.");
            Console.WriteLine("- Dígite qualquer coisa para continuar.");
            Console.ReadKey();
            Console.WriteLine();

            if (valorParaCalculoDoInss <= 1320.00) {
                Console.WriteLine("- Desconto feito com base na aliquota de 7,5%");
                //Console.WriteLine();
                percentualInss = 7.5 / 100;
                DescontoDoInss = (valorParaCalculoDoInss * percentualInss) - parcela1;
                Console.WriteLine("- Funcionario isento do desconto de INSS.");
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.WriteLine();
            }

            else if (valorParaCalculoDoInss <= 2571.29) {
                Console.WriteLine("- Desconto feito com base na aliquota de 9,0%");
                percentualInss = 9.0 / 100;
                DescontoDoInss = (valorParaCalculoDoInss * percentualInss) - parcela2;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.WriteLine();
            }

            else if (valorParaCalculoDoInss <= 3856.94) {
                Console.WriteLine("- Desconto feito com base na aliquota de 12,0%");
               // Console.WriteLine();
                percentualInss = 12.0 / 100;
                DescontoDoInss = (valorParaCalculoDoInss * percentualInss) - parcela3;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.WriteLine();
            }

            else if (valorParaCalculoDoInss <= 7507.49) {
                Console.WriteLine("- Desconto feito com base na aliquota de 14,0%");
               // Console.WriteLine();
                percentualInss = 14.0 / 100;
                DescontoDoInss = (valorParaCalculoDoInss * percentualInss) - parcela4;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.WriteLine();
            }

            else {
                Console.WriteLine("- Valores acima de 7.507.49 R$ (teto do INSS), possuem um desconto fixo de 877.24 R$");
               // Console.WriteLine();
                DescontoDoInss = valorParaCalculoDoInss - parcela5;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.WriteLine();
            }
            return DescontoDoInss;
        } 

        public double CalcularIrrf()
        {
            double baseIrrf, percentual, calculoNormal, calculoSimplificado, descontoIr = 0, valorSimplificado = 528.00;
            double parcela2 = 158.40, parcela3 = 370.40, parcela4 = 651.73, parcela5 = 884.96;
            double salarioBruto = SalarioBase;
            double valorDoInss = DescontoDoInss;
            double valorDaPensao = DescontoTotalDePensao;
            double valorDeDependente = DescontoTotalDeDependentes;

            calculoNormal = salarioBruto - valorDoInss - valorDaPensao - valorDeDependente;
            calculoSimplificado = salarioBruto - valorSimplificado;

            if( calculoNormal < calculoSimplificado)
            {
                baseIrrf = calculoNormal;
            }
            else
            {
                baseIrrf = calculoSimplificado;
            }
            
            if (baseIrrf <= 2112.00)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIrrf:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 0,00%.");
                Console.WriteLine();
                Console.WriteLine("- Isento do desconto de IR, parcela a deduzir: R$ 0,00.");
                Console.ReadKey();
                Console.WriteLine();
            }
            else if(baseIrrf <= 2826.65)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIrrf:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 7,50%.");
                Console.WriteLine();
                percentual = 7.50 / 100;
                descontoIr = (baseIrrf * percentual) - parcela2;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
                Console.WriteLine();
            }
            else if (baseIrrf <= 3751.05)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIrrf:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 15,00%.");
                Console.WriteLine();
                percentual = 15.00 / 100;
                descontoIr = (baseIrrf * percentual) - parcela3;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
                Console.WriteLine();
            }
            else if(baseIrrf <= 4664.68)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIrrf:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 22,50%.");
                Console.WriteLine();
                percentual = 22.50 / 100;
                descontoIr = (baseIrrf * percentual) - parcela4;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIrrf:f2}");
                Console.WriteLine("- Base de cálculo de IR maior que 4.664,687 o desconto feito com base na aliquota de: 27,50%.");
                Console.WriteLine();
                percentual = 27.50 / 100;
                descontoIr = (baseIrrf * percentual) - parcela5;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
                Console.WriteLine();
            }
            DescontoDoIrrf = descontoIr;
            return DescontoDoIrrf;

        } 

        public double CalcularAdiantamentoQuinzenal()
        {
            double salarioBruto;
            double porcentagem = 0.4;

            //Console.Write("- Informe o Salario bruto: R$ ");
            //salarioBruto = double.Parse(Console.ReadLine());
            //Console.WriteLine();
            salarioBruto = SalarioBase;
            AdiantamentoQuinzenal = salarioBruto * porcentagem;
            Console.WriteLine($"- Valor do Salário bruto: R$ {salarioBruto:f2}");
            Console.WriteLine($"- Valor do Adiantamento: R$ {AdiantamentoQuinzenal:f2}");
            return AdiantamentoQuinzenal;
        } 

        public double CalcularHoraExtra()
        {
            double valorHora, valorDaHoraExtra, hora, valorTotalDaHoraExtra, salarioBruto, horaConvertida = 0, indicadorDsr, percentualDoDsr, valorDoDsr;
            int converter, porcentagem, diasUteis, repousosFeriados;

            do {
                Console.WriteLine("- Horas com minutos não são calculadas pois é necessario converte-las em horas.");
                Console.WriteLine("- É necesario fazer converção de minutos em horas ?");
                Console.WriteLine();
                Console.WriteLine("- Para SIM dígite [1]");
                Console.WriteLine("- Para NÃO dígite [2]");
                Console.Write("- Converter...: ");
                converter = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (converter == 1)
                {
                    horaConvertida = ConversorDeMinutosEmHoras();
                    Console.WriteLine();
                    Console.WriteLine("- Minutos convertidos em horas!");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                }
                else if (converter == 2)
                {
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }
            }while(converter != 1 && converter != 2);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("- Informe o salário bruto do funcionário: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de horas realizadas: ");
            hora = double.Parse(Console.ReadLine());
            Console.Write("- Informe a porcentagem incedida sobre as horas extras: ");
            porcentagem = int.Parse(Console.ReadLine());
            Console.WriteLine();

            valorHora = salarioBruto / 220;
            porcentagem = porcentagem / 100;
            valorDaHoraExtra = valorHora + (valorHora * (double) porcentagem);
            valorTotalDaHoraExtra = hora * valorDaHoraExtra;

            Console.WriteLine("- Agora é preciso calcular o DSR sobre as horas extras.");
            Console.WriteLine();
            Console.Write("- Informe a quantidade de dias uteis do mes: ");
            diasUteis = int.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de dias de repouso e feriados do mes: ");
            repousosFeriados = int.Parse(Console.ReadLine());
            Console.WriteLine();

            indicadorDsr = (double) repousosFeriados / diasUteis;
            percentualDoDsr = indicadorDsr * porcentagem;
            valorDoDsr = valorDaHoraExtra * percentualDoDsr;
            valorTotalDaHoraExtra = horaConvertida * (valorDaHoraExtra + valorDoDsr);

            Console.WriteLine($"- Valor da hora normal: R$ {valorHora:f2}");
            Console.WriteLine($"- Valor da hora extra: R$ {valorDaHoraExtra:f2}");
            Console.WriteLine($"- Valor do DSR incedido sobre as horas extras: R$ {valorDoDsr:f2}");
            Console.WriteLine($"- Valor total da hora extra incedida sobre o DSR: R$ {valorTotalDaHoraExtra:f2}");

            TotalDeHorasExtras = valorTotalDaHoraExtra;
            return TotalDeHorasExtras;

        } 

        public double CalcularPericulosidadeInsalubridade()
        {
            double valorDaPorcentagem, salarioBruto;
            int beneficio;

           // Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.WriteLine();
            do
            {
                Console.WriteLine("- Informe qual o tipo de benefício do funcionário.");
                Console.WriteLine();
                Console.WriteLine("- Dígite [1] para Periculosidade.");
                Console.WriteLine("- Dígite [2] para Insalubridade.");
                Console.Write("- Benefício..: ");
                beneficio = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (beneficio)
                {
                    case 1:
                        Console.WriteLine("---Cálculo de Periculosidade---");
                        Console.WriteLine();

                        valorDaPorcentagem = salarioBruto * 0.3;
                        ValorTotalDePericulosidadeInsalubridade = valorDaPorcentagem + salarioBruto;
                        Console.WriteLine($"- Valor de acréscimo devido a periculosidade é de 30% que corresponde a: R$ {valorDaPorcentagem:f2}");
                        Console.ReadKey();
                        break;

                    case 2:
                            Console.WriteLine("---Cálculo da Insalubridade---");
                            Console.WriteLine();
                            int grau, escolha;
                            double salarioMinimo = 1320.00, valorDeCalculo = 0, percentual = 0;

                        do {
                            Console.WriteLine("- ATENÇÂO: O cálculo de insalubridade é aplicado sobre o sálario mínimo, exceto em acordo entre o funcionário e o empregador.");
                            Console.WriteLine("- Sendo assim, para prosseguir selecione.");
                            Console.WriteLine();
                            Console.WriteLine("- Para salário mínimo dígite [1]");
                            Console.WriteLine("- Para salário base dígite [2]");
                            Console.Write("- Escolha...: ");
                            escolha = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            if (escolha == 1)
                            {
                                valorDeCalculo = salarioMinimo;
                            }
                            else if (escolha == 2)
                            {
                                valorDeCalculo = salarioBruto;
                            }
                            else
                            {
                                Console.WriteLine("- ERRO! Opção inválida, selecione entre [1] ou [2].");
                                Console.WriteLine("- Dígite qualquer coisa para retornar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                            }
                        } while(escolha != 1 && escolha != 2);

                        do { 
                            Console.WriteLine("- Informe qual o grau de insalubridade sobre o qual o funcionario exerce sua função.");
                            Console.WriteLine();
                            Console.WriteLine("- Dígite [1] para leve/10%.");
                            Console.WriteLine("- Dígite [2] para médio/20%");
                            Console.WriteLine("- Dígite [3] para gráve/40%");
                            Console.Write("- Grau...: ");
                            grau = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            if (grau == 1)
                            {
                                percentual = valorDeCalculo * 0.1;
                                Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 10% correspodente a: R$ {percentual:f2}");
                                ValorTotalDePericulosidadeInsalubridade = percentual;
                                Console.ReadKey();
                            }
                            else if (grau == 2)
                            {
                                percentual = valorDeCalculo * 0.2;
                                Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 20% correspodente a: R$ {percentual:f2}");
                                ValorTotalDePericulosidadeInsalubridade = percentual;
                                Console.ReadKey();
                            }
                            else if (grau == 3)
                            {
                                percentual = valorDeCalculo * 0.4;
                                Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 40% correspodente a: R$ {percentual:f2}");
                                ValorTotalDePericulosidadeInsalubridade = percentual;
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("- ERRO! Opção inválida, selecione entre [1], [2] ou [3].");
                                Console.WriteLine("- Dígite qualquer coisa para retornar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                            }
                        }while (grau != 1 && grau != 2 && grau != 3);
                        break;

                    default:
                        Console.WriteLine("- ERRO! Opção inválida, selecione entre [1] ou [2].");
                        Console.WriteLine("- Dígite qualquer coisa para retornar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                        break;
                }
            } while (beneficio != 1 && beneficio != 2);
            return ValorTotalDePericulosidadeInsalubridade;
        } 

        public double CalcularAdicionalNoturno()
        {
            double salarioBruto, valorDaHoraNormal, valorDoAdicionalNoturnoHora, acrescimo, horaConvertida, quantidadeDeHoras;
            int converter;

            do
            {
                Console.WriteLine("- Horas com minutos não são calculadas, é necessario converter os minutos em horas.");
                Console.WriteLine("- Deseja realizar a converção de minutos em horas ?");
                Console.WriteLine();
                Console.WriteLine("- Para SIM dígite [1]");
                Console.WriteLine("- Para NÃO dígite [2]");
                Console.Write("- Converter...: ");
                converter = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (converter == 1)
                {
                    horaConvertida = ConversorDeMinutosEmHoras();
                    Console.WriteLine();
                    Console.WriteLine("- Minutos convertidos em horas!");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                }
                else if (converter == 2)
                {
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }
            } while (converter != 1 && converter != 2);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("- Agora vamos calcular o adcional noturno do funcionário.");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionário: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            valorDaHoraNormal = salarioBruto / (double) 220;
            acrescimo = valorDaHoraNormal * 0.2;
            valorDoAdicionalNoturnoHora = valorDaHoraNormal + acrescimo;

            Console.Write("- Informe a quantidade de horas trabalhadas como adicional noturno: ");
            quantidadeDeHoras = double.Parse(Console.ReadLine());
            ValorDoAdicionalNoturno = quantidadeDeHoras * valorDoAdicionalNoturnoHora;
            Console.WriteLine();

            Console.WriteLine($"- O valor hora de adicional noturno do funcionário é de: R$ {valorDoAdicionalNoturnoHora:f2}");
            Console.WriteLine($"- O valor total que o funcionário ira receber de adicional noturno é: R$ {ValorDoAdicionalNoturno:f2}");
            return ValorDoAdicionalNoturno;
        } 

        public double CalcularConvenioMedico()
        {
            double valorDoConvenioMedico;

            //Console.WriteLine("- Selecione qual a empresa que fornece o plano de saúde: "); Só vou utilizar isso depois que ficar o BD com as empresas e seus valores.
            // Vou precisar fazer um acesso ao BD e fazer uma pesquisa das empresas e buscar o valor cobrado por ela, depois armazenar na variavel abaixo.
            Console.Write("- Informe o valor cobrado pela empresa que fornece o serviço: R$ ");
            valorDoConvenioMedico = double.Parse(Console.ReadLine());
            DescontoDoConvenioMedico = valorDoConvenioMedico;
            Console.WriteLine();

            Console.WriteLine($"- O valor do convenio médico descontado do funcionarios é de: R$ {valorDoConvenioMedico:f2}");
            Console.ReadKey();
            return DescontoDoConvenioMedico;
        }  

        public double CalcularConvenioOdontologico()
        {
            double valorDoConvenioOdontologico;

            //Console.WriteLine("- Selecione qual a empresa que fornece o plano odontológico: "); Só vou utilizar isso depois que ficar o BD com as empresas e seus valores.
            // Vou precisar fazer um acesso ao BD e fazer uma pesquisa das empresas e buscar o valor cobrado por ela, depois armazenar na variavel abaixo.
            Console.Write("- Informe o valor cobrado pela empresa que fornece o serviço: R$ ");
            valorDoConvenioOdontologico = double.Parse(Console.ReadLine());
            DescontoDoConvenioOdontologico = valorDoConvenioOdontologico;
            Console.WriteLine();

            Console.WriteLine($"- O valor do convenio odontológico descontado do funcionarios é de: R$ {valorDoConvenioOdontologico:f2}");
            Console.ReadKey();
            return DescontoDoConvenioOdontologico;
        } 

        public double CalcularDependencia()
        {
            double dependente = 189.59;
            int quantidadeDeDependentes; 

            Console.Write("- Informe a quantidade de dependentes: R$ ");
            quantidadeDeDependentes = int.Parse(Console.ReadLine());
            DescontoTotalDeDependentes = (double) quantidadeDeDependentes * dependente;

            Console.WriteLine($"- O valor total a ser descontado de dependentes é de: R$ {DescontoTotalDeDependentes:f2}");
            Console.ReadKey();
            return DescontoTotalDeDependentes;
        } 

        public double CalcularPensao()
        {
            int porcentagemFixada;
            double porcentagemFixadaConvertida, salarioMinimo = 1320.00, valorDaPensao;
           
            Console.Write("- Informe a porcentagem de pensão fixada judicialmente: ");
            porcentagemFixada = int.Parse(Console.ReadLine());

            porcentagemFixadaConvertida = (double) porcentagemFixada / 100.0;
            valorDaPensao = salarioMinimo * porcentagemFixadaConvertida;

            Console.Write($"- O Desconto a ser retirado de pensão é de: R$ {valorDaPensao:f2}");
            Console.ReadKey();
            Console.WriteLine();
            DescontoTotalDePensao = valorDaPensao;
            return DescontoTotalDePensao;
        } 

        public double CalcularAtrasos()
        {
            double horasConvertidas;
            int converter, tipoDeDesconto;

            do {
                Console.WriteLine("- Se for necessario fazer a conversão de minutos em horas para os proximos cálculos digite [1], caso contrario digite [2].");
                Console.Write("- Converter...: ");
                converter = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (converter == 1)
                {
                    horasConvertidas = this.ConversorDeMinutosEmHoras();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                }
                else if (converter == 2)
                {
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }
            }while (converter != 1 && converter != 2);

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            do
            {
                Console.WriteLine("- Selecione qual o tipo de atraso deseja calcular.");
                Console.WriteLine();
                Console.WriteLine("- Para desconto de atraso comum dígite............................[1]");
                Console.WriteLine("- Para desconto de falta injustifícada ao trabalho dígite.........[2]");
                Console.WriteLine("- Para desconto de falta ao trabalho com DSR dígite...............[3]");
                Console.WriteLine("- Para sair dígite................................................[4]");
                Console.Write("- Tipo de desconto...: ");
                tipoDeDesconto = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (tipoDeDesconto)
                {
                    case 1:
                        Console.WriteLine("---Atraso Comum---");
                        Console.WriteLine();
                        TotalDeAtrasos = this.AtrasoComum();
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("---Falta ao Trabalho Injustifícada---");
                        Console.WriteLine();
                        TotalDeAtrasos = this.FaltaInjustificada();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("---Falta ao Tabalho com DSR---");
                        Console.WriteLine();
                        TotalDeAtrasos = this.FaltaInjustificadaComDsr();
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("---Saindo---");
                        break;

                    default:
                        Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                        Console.WriteLine("- Dígite qualquer coisa para continuar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                        break;
                }
            } while (tipoDeDesconto != 1 &&  tipoDeDesconto != 2 && tipoDeDesconto != 3 && tipoDeDesconto != 4);
            return TotalDeAtrasos;
        } 

        private double ConversorDeMinutosEmHoras()
        {
            int quantidadeDehorasFechadas, quantidadeDeMinutos;
            double totalDeMinutos;

            Console.Write("- Informe a quantidade de horas fechadas: ");
            quantidadeDehorasFechadas = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("- Informe a quantidade de minutos: ");
                quantidadeDeMinutos = int.Parse(Console.ReadLine());
                if (quantidadeDeMinutos <= 0 || quantidadeDeMinutos > 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("- Error! Não é possivel entrar com valores abaixo de [0] pois não se configuram em horas.");
                    Console.WriteLine("- Error! Não é possível entrar com valores acima de [60] pois se configura como uma hora fechada.");
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ ENTRE COM UM VALOR VÁLIDO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }
            } while (quantidadeDeMinutos <= 0 || quantidadeDeMinutos > 60);

            totalDeMinutos = (double)quantidadeDeMinutos / 60.0;
            TotalDeHorasConvertidas = (double) quantidadeDehorasFechadas + totalDeMinutos;
            Console.WriteLine();
            Console.WriteLine($"- Total de Horas: {TotalDeHorasConvertidas:f2}");
            return TotalDeHorasConvertidas;
        }

        private double AtrasoComum()
        {
            double salarioBruto, horasEmAtraso;
            int jornada;

            Console.Write("- Informe o salario bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de atrasos em horas: ");
            horasEmAtraso = double.Parse(Console.ReadLine());
            Console.Write("- Informe as horas da jornada de trabalho: ");
            jornada = int.Parse(Console.ReadLine());

            DescontoDeAtrasos = (salarioBruto * horasEmAtraso) / (double) jornada;
            Console.WriteLine();

            Console.WriteLine($"- O valor de desconto devido a tempo de atrasos é de: R$ {DescontoDeAtrasos:f2}");
            Console.WriteLine($"- Total de horas em atraso: {horasEmAtraso}");
            return DescontoDeAtrasos;
        } 

        private double FaltaInjustificada()
        {
            double salarioBruto;
            int faltas;

            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de faltas do funcionario: ");
            faltas = int.Parse(Console.ReadLine());
            DescontoDeFaltasInjustificadas = (salarioBruto * (double) faltas) / (double) 30;
            Console.WriteLine();
            Console.WriteLine($"- O valor de desconto devido a faltas injustificadas é de: R$ {DescontoDeFaltasInjustificadas:f2}");
            return DescontoDeFaltasInjustificadas;
        } 

        private double FaltaInjustificadaComDsr()
        {
            double salarioBruto, valorDoDsr, horaExtra, valorDoReflexo;
            int faltas, dsr, reflexoDoDsr, diasUteis, dsrDoMes;

            Console.WriteLine("- Primeiro vamos calcular o valor do dsr do funcionario.");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: ");
            salarioBruto = double.Parse(Console.ReadLine());
            valorDoDsr = salarioBruto / 30;
            Console.WriteLine();
            Console.WriteLine($"- O valor do DSR do funcionario é de: R$ {valorDoDsr:f2}");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("- Segundo, vamos calcular o desconto por falta ao trabalho com DSR.");
            Console.WriteLine();
            Console.Write("- Informe a quantidade de faltas do funcionario: ");
            faltas = int.Parse(Console.ReadLine());
            Console.Write("- informe a quantidade de DSR´s que deve ser descontado: ");
            dsr = int.Parse(Console.ReadLine());
            FaltasInjustificadasComDsr = ((salarioBruto * (double) faltas) / (double) 30) + ((double) dsr * valorDoDsr) ;
            Console.WriteLine();
            Console.WriteLine($"- O valor total de desconto de faltas + DSR é de: R$ {FaltasInjustificadasComDsr:f2}");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            do
            {
                Console.WriteLine("- O funcionario realizou horas extras ou teve algum acrescimo ao salário no mes? Caso sim o reflexo do DSR deverá ser calculado.");
                Console.WriteLine();
                Console.WriteLine("- Para sim dígite [1]");
                Console.WriteLine("- Para não dígite [2]");
                Console.Write("- Reflexo...: ");
                reflexoDoDsr = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (reflexoDoDsr == 1)
                {
                    Console.Write("- Informe o valor da hora extra/comissão obtido pelo funcionario no mês: R$ ");
                    horaExtra = double.Parse(Console.ReadLine());
                    Console.Write("- Informe a quantidade de dias uteis do mes: ");
                    diasUteis = int.Parse(Console.ReadLine());
                    Console.Write("- Informe a quantidade de DSR do mes: ");
                    dsrDoMes = int.Parse(Console.ReadLine());
                    valorDoReflexo = (horaExtra / (double)diasUteis) * (double)dsrDoMes;
                    FaltasInjustificadasComDsr += valorDoReflexo;
                    Console.WriteLine();
                    Console.WriteLine($"- O valor do reflexo é de: R$ {valorDoReflexo:f2}");
                    Console.WriteLine($"- O valor a ser descontado por falta ao trabalho + DSR + reflexo do DSR é de: R$ {FaltasInjustificadasComDsr:f2}");
                }
                else if (reflexoDoDsr == 2)
                {
                    Console.WriteLine("- Dígite qualquer coisa para retornar");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("- ERROR, Valor invalida selecione entre as opções [1] ou [2].");
                    Console.WriteLine("- Dígite qualquer coisa para retornar");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }
            } while (reflexoDoDsr != 1 &&  reflexoDoDsr != 2);
            return FaltasInjustificadasComDsr;
        } 
        
        public void CalcularDecimoTerceiroSalario()
        {
            // Por enquantovou deixar VOID para analisar melhor depois
            // PRECISO TESTAR ESTE MÈTODO.
            double salarioBruto = SalarioBase;
            int  parcelar;

            Console.WriteLine("---Calculando o Décimo Terceiro Salário---");
            Console.WriteLine();

            do
            {
                Console.WriteLine("- Informe se o decimo salário sera pago em 1x ou em 2x");
                Console.WriteLine("- Para pagamento em 1x dígite [1]");
                Console.WriteLine("- Para pagamento em 2x dígite [2]");
                Console.Write("- Parcelar...: ");
                parcelar = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (parcelar)
                {
                    case 1:
                        CalcularDecimoTerceiroEmParcelaUnica();
                        break;

                    case 2:
                        int parcela;
                        do
                        {
                            Console.WriteLine("- Deseja calcular a 1º ou a 2º parcela do décimo terceiro?");
                            Console.WriteLine("- Para calcular a 1º parcela digite [1]");
                            Console.WriteLine("- Para calcular a 2º parcela digite [2]");
                            Console.Write("- Calcular...: ");
                            parcela = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            if (parcela == 1)
                            {
                                CalcularPrimeiraParcelaDoDecimoTerceiro();
                            }
                            else if (parcela == 2)
                            {
                                CalcularSegundaParcelaDoDecimoTerceiro();
                            }
                            else
                            {
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                            }
                        } while (parcela != 1 && parcela != 2);
                        break;

                    default:
                        Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                        Console.WriteLine("- Dígite qualquer coisa para continuar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                        break;
                }
            } while (parcelar != 1 && parcelar != 2);
        }
        
        private double CalcularDecimoTerceiroEmParcelaUnica() // Esse método tem que ser private
        {
            int mesesTrabalhados;
            double decimoTerceiroBruto, decimoTerceiroSalarioLiquido, percentualInss, percentualIrrf, descontoDeInssDoDecimoTerceiro, baseIrrfDecimoTerceiro, descontoDeIrrDofDecimoTerceiro = 0;
            double parcelaInss1 = 0, parcelaInss2 = 19.80, parcelaInss3 = 96.94, parcelaInss4 = 174.08, parcelaInss5 = 877.24;
            double parcelaIrrf2 = 158.40, parcelaIrrf3 = 370.40, parcelaIrrf4 = 651.73, parcelaIrrf5 = 884.96;
            // double salarioBruto = SalarioBase; vou atribuir o valor de forma manual antes de incluir no metodo da folha.
            double salarioBruto;

            Console.Write("- Informe o salário bruto do funcionario: ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe quantos meses do ano o funcionário trabalhou: ");
            mesesTrabalhados = int.Parse(Console.ReadLine());
            decimoTerceiroBruto = (salarioBruto / 12) * (double) mesesTrabalhados;
            Console.WriteLine();

            if(decimoTerceiroBruto <= 1320.00) 
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 7,5%");
                percentualInss = 7.5 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss1;
            }
            else if (decimoTerceiroBruto <= 2571.29)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 9,0%");
                percentualInss = 9.0 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss2;
            }
            else if (decimoTerceiroBruto <= 3856.94)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 12,0%");
                percentualInss = 12.0 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss3;
            }
            else if (decimoTerceiroBruto <= 7507.49)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 14,0%");
                percentualInss = 14.0 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss4;
            }
            else
            {
                Console.WriteLine("- Valores acima de 7.507.49 R$ (teto do INSS), possuem um desconto fixo de 877.24 R$");
                descontoDeInssDoDecimoTerceiro = decimoTerceiroBruto - parcelaInss5;
            }

            baseIrrfDecimoTerceiro = salarioBruto - descontoDeInssDoDecimoTerceiro;

            if (baseIrrfDecimoTerceiro <= 2112.00)
            {
                Console.WriteLine("- Isento do desconto de IR, parcela a deduzir: R$ 0,00.");
            }
            else if (baseIrrfDecimoTerceiro <= 2826.65)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de: 7,50%.");
                percentualIrrf = 7.50 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf2;
            }
            else if (baseIrrfDecimoTerceiro <= 3751.05)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de: 15,00%.");
                percentualIrrf = 15.00 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf3;
            }
            else if (baseIrrfDecimoTerceiro <= 4664.68)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de: 22,50%.");
                percentualIrrf = 22.50 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf4;
            }
            else
            {
                Console.WriteLine("- Base de cálculo de IR maior que 4.664,687 o desconto feito com base na aliquota de: 27,50%.");
                percentualIrrf = 27.50 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf5;
            }
            Console.WriteLine();

            decimoTerceiroSalarioLiquido = decimoTerceiroBruto - descontoDeInssDoDecimoTerceiro - descontoDeIrrDofDecimoTerceiro;
            Console.Write($"- O valor bruto do décimo terceiro salário do funcionario é de: R$ {decimoTerceiroBruto:f2}");
            ValorDoDecimoTerceiroSalarioBruto = decimoTerceiroBruto;
            Console.WriteLine();
            Console.Write($"- O desconto de INSS sobre o décimo terceiro é de: R$ {descontoDeInssDoDecimoTerceiro:f2}");
            InssSobreDecimoTerceiro = descontoDeInssDoDecimoTerceiro;
            Console.WriteLine();
            Console.Write($"- O desconto de IRRF sobre o deécimo terceiro salário é de: R$ {descontoDeIrrDofDecimoTerceiro:f2}");
            IrrfSobreDecimoTerceiro = descontoDeIrrDofDecimoTerceiro;
            Console.WriteLine();
            Console.WriteLine($"- O valor líquido do décimo terceiro a receber é de: R$ {decimoTerceiroSalarioLiquido:f2}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            return decimoTerceiroSalarioLiquido;
        }

        private double CalcularPrimeiraParcelaDoDecimoTerceiro()
        {
            //double salarioBruto = SalarioBase;
            double salarioBruto, PrimeiraParcelaDecimoTerceiro;
            int mesesTrabalhados;

            Console.Write("- Informe o salário bruto do funcionario: ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe quantos meses do ano o funcionário trabalhou: ");
            mesesTrabalhados = int.Parse(Console.ReadLine());
            PrimeiraParcelaDecimoTerceiro = (salarioBruto / 12) * (double) mesesTrabalhados;
            Console.WriteLine();
            return PrimeiraParcelaDecimoTerceiro;
        }

        private double CalcularSegundaParcelaDoDecimoTerceiro()
        {
            double decimoTerceiroBruto, segundaParcelaDecimoTerceiro, baseSegundaParcelaDecimoTerceiro, percentualInss, percentualIrrf, descontoDeInssDoDecimoTerceiro, baseIrrfDecimoTerceiro, descontoDeIrrDofDecimoTerceiro = 0;
            double parcelaInss1 = 0, parcelaInss2 = 19.80, parcelaInss3 = 96.94, parcelaInss4 = 174.08, parcelaInss5 = 877.24;
            double parcelaIrrf2 = 158.40, parcelaIrrf3 = 370.40, parcelaIrrf4 = 651.73, parcelaIrrf5 = 884.96;
            // double salarioBruto = SalarioBase; vou atribuir o valor de forma manual antes de incluir no metodo da folha.

            Console.WriteLine("- Informe o valor bruto do décimo terceiro: R$  ");
            decimoTerceiroBruto = double.Parse(Console.ReadLine());
            baseSegundaParcelaDecimoTerceiro = decimoTerceiroBruto / 2;

            if (decimoTerceiroBruto <= 1320.00)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 7,5%");
                percentualInss = 7.5 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss1;
            }
            else if (decimoTerceiroBruto <= 2571.29)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 9,0%");
                percentualInss = 9.0 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss2;
            }
            else if (decimoTerceiroBruto <= 3856.94)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 12,0%");
                percentualInss = 12.0 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss3;
            }
            else if (decimoTerceiroBruto <= 7507.49)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de 14,0%");
                percentualInss = 14.0 / 100;
                descontoDeInssDoDecimoTerceiro = (decimoTerceiroBruto * percentualInss) - parcelaInss4;
            }
            else
            {
                Console.WriteLine("- Valores acima de 7.507.49 R$ (teto do INSS), possuem um desconto fixo de 877.24 R$");
                descontoDeInssDoDecimoTerceiro = decimoTerceiroBruto - parcelaInss5;
            }

            baseIrrfDecimoTerceiro = decimoTerceiroBruto - descontoDeInssDoDecimoTerceiro;
            if (baseIrrfDecimoTerceiro <= 2112.00)
            {
                Console.WriteLine("- Isento do desconto de IR, parcela a deduzir: R$ 0,00.");
            }
            else if (baseIrrfDecimoTerceiro <= 2826.65)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de: 7,50%.");
                percentualIrrf = 7.50 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf2;
            }
            else if (baseIrrfDecimoTerceiro <= 3751.05)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de: 15,00%.");
                percentualIrrf = 15.00 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf3;
            }
            else if (baseIrrfDecimoTerceiro <= 4664.68)
            {
                Console.WriteLine("- Desconto feito com base na aliquota de: 22,50%.");
                percentualIrrf = 22.50 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf4;
            }
            else
            {
                Console.WriteLine("- Base de cálculo de IR maior que 4.664,687 o desconto feito com base na aliquota de: 27,50%.");
                percentualIrrf = 27.50 / 100;
                descontoDeIrrDofDecimoTerceiro = (baseIrrfDecimoTerceiro * percentualIrrf) - parcelaIrrf5;
            }
            Console.WriteLine();

            segundaParcelaDecimoTerceiro = baseSegundaParcelaDecimoTerceiro - descontoDeInssDoDecimoTerceiro - descontoDeIrrDofDecimoTerceiro;
            Console.Write($"- O valor da Segunda parcela do décimo terceiro é de: R$ {segundaParcelaDecimoTerceiro:f2}");
            Console.WriteLine();
            Console.Write($"- O desconto de INSS sobre o décimo terceiro é de: R$ {descontoDeInssDoDecimoTerceiro:f2}");
            InssSobreDecimoTerceiro = descontoDeInssDoDecimoTerceiro;
            Console.WriteLine();
            Console.Write($"- O desconto de IRRF sobre o décimo terceiro é de: R$ {descontoDeIrrDofDecimoTerceiro:f2}");
            IrrfSobreDecimoTerceiro = descontoDeIrrDofDecimoTerceiro;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            return segundaParcelaDecimoTerceiro;
        }

        public double CalcularFgts()
        {
            double salarioBruto;

            Console.WriteLine("---Calcular o FGTS---");
            Console.WriteLine();

            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Fgts = salarioBruto * 0.08;
            Console.WriteLine();
            Console.WriteLine($"- O valor do FGTS a ser depositado é de: R$ {Fgts:f2}");
            Console.ReadKey();
            return Fgts;
        }

        public double GerarFolhaDePagamento()
        {
            int escolha;
            double valor = 0;

            Console.WriteLine("---Gerando o Holerite---");
            Console.WriteLine();

            do { 
                Console.WriteLine("- Deseja gerar a folha de pagamento de forma sequencial ou selecionar os campos um a um ?");
                Console.WriteLine("- Digite [1] para sequencial.");
                Console.WriteLine("- Dígite [2] para selecionar os campos.");
                Console.Write("- Escolha...: ");
                escolha = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (escolha == 1)
                {
                    int simNao;

                    Console.WriteLine("\t\t---Modelo Sequência---");
                    Console.WriteLine();
                    Console.WriteLine("- Etapa 1");
                    Console.Write("- Informe o salário base do funcionário: R$ ");
                    SalarioBase = double.Parse(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 2");
                        Console.WriteLine("- O funcionario possui adiantamento quinzenal? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularAdiantamentoQuinzenal();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                AdiantamentoQuinzenal = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do { 
                        Console.WriteLine("- Etapa 3");
                        Console.WriteLine("- O funcionario possui adicional noturno? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularAdicionalNoturno();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                ValorDoAdicionalNoturno = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();


                    do
                    {
                        Console.WriteLine("- Etapa 4");
                        Console.WriteLine("- O funcionario atua sobre periculosidade ou insalubridade? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularPericulosidadeInsalubridade();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                ValorTotalDePericulosidadeInsalubridade = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 5");
                        Console.WriteLine("- O funcionario realizou horas extras este mês? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch(simNao)
                        {
                            case 1:
                                CalcularHoraExtra();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                TotalDeHorasExtras = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    // Vou deixar esta parte comentada porque será o espaço destinado para a etapa de férias.
                    /*Console.WriteLine("- Etapa 6");
                    Console.WriteLine("- O funcionario irá tirar férias este mês? Para SIM dígite [1], para NÃO dígite [2]");
                    Console.Write("- Escolha...: ");
                    simNao = int.Parse(Console.ReadLine());
                    Console.WriteLine();*/

                    do
                    {
                        Console.WriteLine("- Etapa 7");
                        Console.WriteLine("- O funcionario possui vale transporte? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularValeTransporte();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoValeTransporte = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    }while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 8");
                        Console.WriteLine("- O funcionario possui vale refeição ou alimentação? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularValeAlimentacao();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoValeRefeicaoAlimentacao = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 9");
                        Console.WriteLine("- O funcionario possui convênio médico? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularConvenioMedico();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoConvenioMedico = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 10");
                        Console.WriteLine("- O funcionario possui convênio odontológico? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularConvenioOdontologico();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoConvenioOdontologico = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 11");
                        Console.WriteLine("- O funcionario possui dependentes? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularDependencia();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoTotalDeDependentes = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 12");
                        Console.WriteLine("- O funcionario teve atrasos durante o mês? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularAtrasos();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                TotalDeAtrasos = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("- Etapa 13");
                    Console.WriteLine("- Chegou a hora de calcular o INSS.");
                    Console.WriteLine();
                    CalcularInss();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    
                    do
                    {
                        Console.WriteLine("- Etapa 14");
                        Console.WriteLine("- O funcionario contribui paga pensão? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularPensao();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoTotalDePensao = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    
                    Console.WriteLine("- Etapa 15");
                    Console.WriteLine("- Chegou a hora de calcular o IRRF.");
                    Console.WriteLine();
                    CalcularIrrf();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    
                }
                else if (escolha == 2)
                {
                    Console.WriteLine("- Informe quais os atributos serão utilizados para gerar o holerite.");
                    Console.WriteLine();
                    Console.WriteLine("- Vale Transporte...........................[1]");
                    Console.WriteLine("- Vale alimentação..........................[2]");
                    Console.WriteLine("- Adiantamento Quinzenal....................[3]");
                    Console.WriteLine("- Horas Extras..............................[4]");
                    Console.WriteLine("- Periculosidade ou Insalubridade...........[5]");
                    Console.WriteLine("- Adicional Noturno.........................[6]");
                    Console.WriteLine("- Convenio Médico...........................[7]");
                    Console.WriteLine("- Convenio Odontológico.....................[8]");
                    Console.WriteLine("- Atrasos...................................[9]");
                    Console.WriteLine("- Dependencia...............................[10]");
                    Console.WriteLine("- Pensão....................................[11]");
                    Console.WriteLine("- INSS......................................[12]");
                    Console.WriteLine("- IR........................................[13]");
                    Console.WriteLine("- FGTS......................................[14]");
                }
                else
                {
                    Console.WriteLine("-Error, Opção invalida, selecione entre as opções.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }

            } while (escolha != 1 && escolha != 2);
            return valor;
        }
      
    }
}
