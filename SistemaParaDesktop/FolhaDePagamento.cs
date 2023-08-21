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
        private double ValorDoDecimoTerceiro { get; set; }
        private double Fgts { get; set; }


        public double CalcularValeTransporte()
        {
            double porcentagem, passagem, valorPorcentagem,valorPassagem, salarioBruto = SalarioBase;
            int diasUteis;

            Console.WriteLine("- Vamos verificar qual o menor valor para desconto do vale transporte.");
            Console.WriteLine();

            //Console.Write("- Primeiro informe o salário bruto do funcionario: R$ ");
            //salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a porcentagem correspondente ao vale transporte: ");
            porcentagem = double.Parse(Console.ReadLine());
            valorPorcentagem = salarioBruto * (porcentagem / 100);
            Console.Write("- Informe o valor da passagem somando ida e volta: R$ ");
            passagem = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de dias uteis: ");
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
            do
            {
                Console.Write("- Informe o percentual de desconto do vale: ");
                percentual = double.Parse(Console.ReadLine());
                if (percentual > 20)
                {
                    Console.WriteLine();
                    Console.WriteLine("- Valor inválido, percentual máximo permitido por lei de 20%.");
                    Console.WriteLine("- Entre com um valor válido.");
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }
            } while (percentual > 20);
            descontoDoVale = valorDoVale * (double)diasUteis * (percentual / 100);
            Console.WriteLine();
            Console.WriteLine($"- Valor a se descontado de vale refeição/alimentação: R$ {descontoDoVale:f2}");
            Console.ReadKey();
            DescontoDoValeRefeicaoAlimentacao = descontoDoVale;
            return DescontoDoValeRefeicaoAlimentacao;
        } 

        public double CalcularInss()
        {
            double salarioBruto = SalarioBase;
            
            Console.WriteLine("- Precione qualquer tecla para calcular o desconto do INSS.");
            Console.ReadKey();
            Console.WriteLine();
            DescontoDoInss = FormulaDoInss(salarioBruto);
            Console.WriteLine();
            Console.WriteLine($"- O valor do desconto em folha de contribuição do INSS é de: R$ {DescontoDoInss:f2}");
            return DescontoDoInss;
        } 

        public double FormulaDoInss(double salario)
        {
            double ValorDeDescontoDoInss, faixa2, faixa3, faixa4, restante;
            double valorPadraoFaixa1 = 99.00;
            double valorPadraoFaixa2 = 112.62;
            double valorPadraoFaixa3 = 154.28;
            double valorPadraoFaixa4 = 511.06;
            if (salario <= 1320.00)
            {
                Console.WriteLine("- O salário se estabelece na primeira faixa da tabela. Desconto do INSS realizado sobre 7,5% ");
                ValorDeDescontoDoInss = salario * 0.075;
            }
            else if (salario <= 2571.29)
            {
                Console.WriteLine("- O salário se estabelece na segunda faixa da tabela. Desconto do INSS realizado sobre 9,0% ");
                restante = salario - 1320.00;
                faixa2 = restante * 0.09;
                ValorDeDescontoDoInss = valorPadraoFaixa1 + faixa2;
            }
            else if (salario <= 3856.94)
            {
                Console.WriteLine("- O salário se estabelece na terceira faixa da tabela. Desconto do INSS realizado sobre 12,00% ");
                restante = salario - 2571.29;
                faixa3 = restante * 0.12;
                ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + faixa3;
            }
            else if (salario <= 7507.49)
            {
                Console.WriteLine("- O salário se estabelece na quarta faixa da tabela. Desconto do INSS realizado sobre 14,00% ");
                restante = salario - 3856.94;
                faixa4 = restante * 0.14;
                ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + valorPadraoFaixa3 + faixa4;
            }
            else
            {
                Console.WriteLine("- O salaário excede o teto do INSS, Desconto sobre 14,0% ");
                ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + valorPadraoFaixa3 + valorPadraoFaixa4;
            }
            return ValorDeDescontoDoInss;
        }

        public double CalcularIrrf()
        {
            double salarioBruto = SalarioBase;
            double valorDoInss = DescontoDoInss;
            double valorDaPensao = DescontoTotalDePensao;
            double valorDeDependente = DescontoTotalDeDependentes;

            Console.WriteLine("- Precione qualquer tecla para calcular o desconto do IRRF.");
            Console.ReadKey();
            Console.WriteLine();
            DescontoDoIrrf = FormulaDoIrrf(salarioBruto, valorDoInss, valorDaPensao, valorDeDependente);
            if(DescontoDoIrrf != 0)
            {
                Console.WriteLine($"- O valor do desconto em folha de contribuição do IRRF é de: R$ {DescontoDoIrrf:f2}");
            }
            else
            {
            }
            return DescontoDoIrrf;
        } 

        public double FormulaDoIrrf(double salario, double inss, double pensao, double dependente)
        {
            double deducoesLegais, descontoSimplificado, baseDeCalculoDoIrrfDefinitivo, valorDeDescontoDoIrrf = 0, percentual;
            double parcela2 = 158.40;
            double parcela3 = 370.40;
            double parcela4 = 651.73;
            double parcela5 = 884.96;
            double valorSimplificado = 528.00;

            deducoesLegais = salario - inss - pensao - dependente;
            descontoSimplificado = salario - valorSimplificado;

            if(deducoesLegais > descontoSimplificado)
            {
                baseDeCalculoDoIrrfDefinitivo = deducoesLegais;
            }
            else
            {
                baseDeCalculoDoIrrfDefinitivo = descontoSimplificado;
            }
            
            if (baseDeCalculoDoIrrfDefinitivo <= 2112.00)
            {
                Console.WriteLine("- A base de calculo se estabelece na segunda faixa. Funcionário está isento do desconto de IRRF.");
                valorDeDescontoDoIrrf = 0;
            }
            else if (baseDeCalculoDoIrrfDefinitivo <= 2826.65)
            {
                Console.WriteLine("- A base de calculo se estabelece na segunda faixa. Desconto do IRRF realizado sobre 7,5%");
                percentual = 7.50 / 100;
                valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela2;
            }
            else if (baseDeCalculoDoIrrfDefinitivo <= 3751.05)
            {
                Console.WriteLine("- A base de calculo se estabelece na terceira faixa. Desconto do IRRF realizado sobre 15,00%%");
                percentual = 15.00 / 100;
                valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela3;
            }
            else if (baseDeCalculoDoIrrfDefinitivo <= 4664.68)
            {
                Console.WriteLine("- A base de calculo se estabelece na terceira faixa. Desconto do IRRF realizado sobre 22,50%");
                percentual = 22.50 / 100;
                valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela4;
            }
            else
            {
                Console.WriteLine("- A base de calculo se estabelece na quarta faixa. Desconto do IRRF realizado sobre 27,50%");
                percentual = 27.50 / 100;
                valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela5;
            }
            return valorDeDescontoDoIrrf;
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
            double valorHora, valorDaHoraExtra, valorTotalDaHoraExtra, indicadorDsr, percentualDoDsr, valorDoDsr;
            int converter, porcentagem, diasUteis, repousosFeriados;
            double hora = 0, horaConvertida = 0;
            double salarioBruto = SalarioBase;

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

            //Console.Write("- Informe o salário bruto do funcionário: R$ ");
           // salarioBruto = double.Parse(Console.ReadLine());
           if(horaConvertida == 0)
            {
                Console.Write("- Informe a quantidade de horas realizadas: ");
                hora = double.Parse(Console.ReadLine());
            }
           else
            {
                hora = horaConvertida;
            }
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
            if(horaConvertida == 0)
            {
                indicadorDsr = (double)repousosFeriados / diasUteis;
                percentualDoDsr = indicadorDsr * porcentagem;
                valorDoDsr = valorDaHoraExtra * percentualDoDsr;
                valorTotalDaHoraExtra = hora * (valorDaHoraExtra + valorDoDsr);
            }
            else
            {
                indicadorDsr = (double)repousosFeriados / diasUteis;
                percentualDoDsr = indicadorDsr * porcentagem;
                valorDoDsr = valorDaHoraExtra * percentualDoDsr;
                valorTotalDaHoraExtra = horaConvertida * (valorDaHoraExtra + valorDoDsr);
            }
            Console.WriteLine($"- Valor da hora normal: R$ {valorHora:f2}");
            Console.WriteLine($"- Valor da hora extra: R$ {valorDaHoraExtra:f2}");
            Console.WriteLine($"- Valor do DSR incedido sobre as horas extras: R$ {valorDoDsr:f2}");
            Console.WriteLine($"- Valor total da hora extra incedida sobre o DSR: R$ {valorTotalDaHoraExtra:f2}");

            TotalDeHorasExtras = valorTotalDaHoraExtra;
            return TotalDeHorasExtras;

        } 

        public double CalcularPericulosidadeInsalubridade()
        {
            double valorDaPorcentagem, salarioBruto = SalarioBase;
            int beneficio;

           // Console.WriteLine();
            //Console.Write("- Informe o salário bruto do funcionario: ");
            //salarioBruto = double.Parse(Console.ReadLine());
            //Console.WriteLine();
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
            double salarioBruto = SalarioBase, valorDaHoraNormal, valorDoAdicionalNoturnoHora, acrescimo, horaConvertida = 0, quantidadeDeHoras;
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
            //Console.Write("- Informe o salário bruto do funcionário: R$ ");
            //salarioBruto = double.Parse(Console.ReadLine());
            valorDaHoraNormal = salarioBruto / (double) 220;
            acrescimo = valorDaHoraNormal * 0.2;
            valorDoAdicionalNoturnoHora = valorDaHoraNormal + acrescimo;
            if (horaConvertida == 0)
            {
                Console.Write("- Informe a quantidade de horas trabalhadas como adicional noturno: ");
                quantidadeDeHoras = double.Parse(Console.ReadLine());
                ValorDoAdicionalNoturno = quantidadeDeHoras * valorDoAdicionalNoturnoHora;
                Console.WriteLine();
            }
            else
            {
                quantidadeDeHoras = horaConvertida;
                ValorDoAdicionalNoturno = quantidadeDeHoras * valorDoAdicionalNoturnoHora;
            }
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
            int tipoDeDesconto;

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
            double salarioBruto = SalarioBase, horasEmAtraso, horasConvertidas = 0;
            int jornada, converter;

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
            } while (converter != 1 && converter != 2);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            //Console.Write("- Informe o salario bruto do funcionario: R$ ");
            //salarioBruto = double.Parse(Console.ReadLine());
            if (horasConvertidas == 0)
            {
                Console.Write("- Informe a quantidade de atrasos em horas: ");
                horasEmAtraso = double.Parse(Console.ReadLine());
            }
            else
            {
                horasEmAtraso = horasConvertidas;
            }
            Console.Write("- Informe as horas da jornada de trabalho: ");
            jornada = int.Parse(Console.ReadLine());
            DescontoDeAtrasos = (salarioBruto * horasEmAtraso) / (double)jornada;
            Console.WriteLine();
            Console.WriteLine($"- O valor de desconto devido a tempo de atrasos é de: R$ {DescontoDeAtrasos:f2}");
            Console.WriteLine($"- Total de horas em atraso: {horasEmAtraso:f2}");
            return DescontoDeAtrasos;
        } 

        private double FaltaInjustificada()
        {
            double salarioBruto = SalarioBase;
            int faltas;

            //Console.Write("- Informe o salário bruto do funcionario: R$ ");
            //salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de faltas do funcionario: ");
            faltas = int.Parse(Console.ReadLine());
            DescontoDeFaltasInjustificadas = (salarioBruto * (double) faltas) / (double) 30;
            Console.WriteLine();
            Console.WriteLine($"- O valor de desconto devido a faltas injustificadas é de: R$ {DescontoDeFaltasInjustificadas:f2}");
            return DescontoDeFaltasInjustificadas;
        } 

        private double FaltaInjustificadaComDsr()
        {
            double salarioBruto = SalarioBase, valorDoDsr, horaExtra, valorDoReflexo;
            int faltas, dsr, reflexoDoDsr, diasUteis, dsrDoMes;

            //Console.WriteLine("- Primeiro vamos calcular o valor do dsr do funcionario.");
            //Console.WriteLine();
           // Console.Write("- Informe o salário bruto do funcionario: ");
            //salarioBruto = double.Parse(Console.ReadLine());
            valorDoDsr = salarioBruto / 30;
            Console.WriteLine();
            Console.WriteLine($"- O valor do DSR do funcionario é de: R$ {valorDoDsr:f2}");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("- Primeiro, vamos calcular o desconto por falta ao trabalho com DSR.");
            Console.WriteLine();
            Console.Write("- Informe a quantidade de faltas do funcionario: ");
            faltas = int.Parse(Console.ReadLine());
            Console.Write("- informe a quantidade de DSR´s que deve ser descontado: ");
            dsr = int.Parse(Console.ReadLine());
            FaltasInjustificadasComDsr = ((salarioBruto * (double) faltas) / (double) 30) + ((double) dsr * valorDoDsr) ;
            Console.WriteLine();
            Console.WriteLine($"- O valor total de desconto de faltas + DSR é de: R$ {FaltasInjustificadasComDsr:f2}");
            
            horaExtra = TotalDeHorasExtras;
            if (horaExtra != 0)
            {
                Console.WriteLine();
                Console.WriteLine("- Este funcionario realizou horas extras, o reflexo do DSR deverá ser calculado.");
                Console.WriteLine();
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
            else 
            {}
            return FaltasInjustificadasComDsr;
        } 

        private double CalcularDecimoTerceiro()
        {
            double decimoTerceiroBruto;
            double salarioBruto = SalarioBase;
            int mesesTrabalhados;

            Console.Write("- Informe quantos meses do ano o funcionário trabalhou: ");
            mesesTrabalhados = int.Parse(Console.ReadLine());
            decimoTerceiroBruto = (salarioBruto / 12) * (double) mesesTrabalhados;
            return decimoTerceiroBruto;
        }

        public double CalcularFormulasDoDecimoTerceiro() 
        {
            int tipoDePagamento;
            double valorDoPagamento = 0;

            do {
                Console.WriteLine("- Informe o tipo de pagamento do décimo terceiro deve ser realizado.");
                Console.WriteLine();
                Console.WriteLine("- Para pagamento do valor completo de forma única dígite [1]");
                Console.WriteLine("- Para pagamento da primeira parcela dígite [2]");
                Console.WriteLine("- Para pagamento da segunda parcela dígite [3]");
                Console.Write("- Tipo de pagamento...: ");
                tipoDePagamento = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (tipoDePagamento)
                {
                    case 1:
                        valorDoPagamento = CalcularPagamentoUnicoDoDecimoTerceiro();
                        Console.WriteLine($"- Valor a receber de décimo terceiro é de: R$ {valorDoPagamento:f2}");
                        break;

                    case 2:
                        valorDoPagamento = CalcularPrimeiraParcelaDoDecimoTerceiro();
                        Console.WriteLine($"- O valor da primeira parcelado décimo terceiro coresponde a: R$ {valorDoPagamento:f2}");
                        break;

                    case 3:
                        valorDoPagamento = CalcularSegundaParcelaDoDecimoTerceiro();
                        Console.WriteLine($"- O valor da segunda parcelado décimo terceiro coresponde a: R$ {valorDoPagamento:f2}");
                        break;

                    default:
                        Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                        Console.WriteLine("- Dígite qualquer coisa para continuar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                        break;
                }
            } while (tipoDePagamento != 1 &&  tipoDePagamento != 2 && tipoDePagamento != 3);
            ValorDoDecimoTerceiro = valorDoPagamento;
            return ValorDoDecimoTerceiro;
        }

        private double CalcularPrimeiraParcelaDoDecimoTerceiro()
        {
            double salarioBrutoDoDecimoTerceiro = CalcularDecimoTerceiro();
            double PrimeiraParcelaDecimoTerceiro;
           
            //Console.Write("- Informe quantos meses do ano o funcionário trabalhou: ");
            //mesesTrabalhados = int.Parse(Console.ReadLine());
            PrimeiraParcelaDecimoTerceiro = salarioBrutoDoDecimoTerceiro / 2;
            Console.WriteLine();
            return PrimeiraParcelaDecimoTerceiro;
        }

        private double CalcularSegundaParcelaDoDecimoTerceiro()
        {
            double salarioBrutoDoDecimoTerceiro, valorDaSegundaParcelaDoDecimo, inss, irrf;
            double pensao = DescontoTotalDePensao;
            double dependente = DescontoTotalDeDependentes;

            salarioBrutoDoDecimoTerceiro = CalcularDecimoTerceiro();
            Console.WriteLine();
            inss = FormulaDoInss(salarioBrutoDoDecimoTerceiro);
            irrf = FormulaDoIrrf(salarioBrutoDoDecimoTerceiro, inss, pensao, dependente);
            valorDaSegundaParcelaDoDecimo = (salarioBrutoDoDecimoTerceiro / 2) - inss - irrf;
            Console.WriteLine();
            return valorDaSegundaParcelaDoDecimo;
        }

        private double CalcularPagamentoUnicoDoDecimoTerceiro()
        {
            double salarioBrutoDoDecimoTerceiro, pagamentoUnicoDoDecimoTerceiro, inss, irrf;
            double pensao = DescontoTotalDePensao;
            double dependente = DescontoTotalDeDependentes;

            salarioBrutoDoDecimoTerceiro = CalcularDecimoTerceiro();
            Console.WriteLine();
            inss = FormulaDoInss(salarioBrutoDoDecimoTerceiro);
            irrf = FormulaDoIrrf(salarioBrutoDoDecimoTerceiro, inss, pensao, dependente);
            pagamentoUnicoDoDecimoTerceiro = salarioBrutoDoDecimoTerceiro - inss - irrf;
            Console.WriteLine();
            return pagamentoUnicoDoDecimoTerceiro;
        }
        
        public double CalcularFgts()
        {
            double salarioBruto = SalarioBase;

            Console.WriteLine("---Calcular o FGTS---");
            Console.WriteLine();

            //Console.Write("- Informe o salário bruto do funcionario: R$ ");
            //salarioBruto = double.Parse(Console.ReadLine());
            Fgts = salarioBruto * 0.08;
            Console.WriteLine($"- O valor do FGTS a ser depositado é de: R$ {Fgts:f2}");
            Console.ReadKey();
            return Fgts;
        }

        public double GerarFolhaDePagamento()
        {
            int escolha;
            double valor = 0;

            Console.WriteLine("\t---Gerando o Holerite---");
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

                    do
                    {
                        Console.WriteLine("- Etapa 16");
                        Console.WriteLine("- O funcionario ira receber o décimo salário? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularFormulasDoDecimoTerceiro();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                ValorDoDecimoTerceiro = 0;
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

                    Console.WriteLine("- Etapa 17");
                    Console.WriteLine("- Chegou a hora de calcular o FGTS.");
                    Console.WriteLine();
                    CalcularFgts();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("- CONCLUIDO! O processo chegou ao fim.");
                    Console.WriteLine("- Para gerar a folha de pagamento dígite qualquer coisa.");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();

                    Vencimentos = SalarioBase + AdiantamentoQuinzenal + TotalDeHorasExtras + ValorTotalDePericulosidadeInsalubridade + ValorDoAdicionalNoturno;
                    Descontos = DescontoDoValeTransporte + DescontoDoValeRefeicaoAlimentacao + DescontoDoConvenioMedico + DescontoDoConvenioOdontologico + DescontoDeAtrasos + DescontoTotalDeDependentes + DescontoTotalDePensao + DescontoDoInss + DescontoDoIrrf;
                    SalarioLiquido = Vencimentos - Descontos;

                    Console.WriteLine("Nome Do Funcionário..................................... | Cargo..................................................");
                    Console.WriteLine();
                    Console.WriteLine("Salario................................................. | Empresa................................................");
                    Console.WriteLine();
                    Console.WriteLine("Conta................................................... | Registro...............................................");
                    Console.WriteLine();
                    // Console.WriteLine($"|Férias                   | ");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("VENCIMENTOS");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"|Salário Base           | {SalarioBase:f2}");
                    Console.WriteLine($"|Horas Extras           | {TotalDeHorasExtras:f2}");
                    Console.WriteLine($"|Insalubridade          | {ValorTotalDePericulosidadeInsalubridade:f2}");
                    Console.WriteLine($"|Adicional Noturno      | {ValorDoAdicionalNoturno:f2}");

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("DESCONTOS");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"|Adiantamento Quinzenal | {AdiantamentoQuinzenal:f2}");
                    Console.WriteLine($"|Vale Alimentação       | {DescontoDoValeRefeicaoAlimentacao:f2}");
                    Console.WriteLine($"|Convênio Médico        | {DescontoDoConvenioMedico:f2}");
                    Console.WriteLine($"|Vale Transporte        | {DescontoDoValeTransporte:f2}");
                    Console.WriteLine($"|Convênio Odontológico  | {DescontoDoConvenioOdontologico:f2}");
                    Console.WriteLine($"|Atrasos                | {DescontoDeAtrasos:f2}");
                    Console.WriteLine($"|Dependente             | {DescontoTotalDeDependentes:f2}");
                    Console.WriteLine($"|Pensão                 | {DescontoTotalDePensao:f2}");
                    Console.WriteLine($"|INSS                   | {DescontoDoInss:f2}");
                    Console.WriteLine($"|IRRF                   | {DescontoDoIrrf:f2}");
                    Console.WriteLine();

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("TOTAIS");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"|VENCIMENTOS            | {Vencimentos:f2}");
                    Console.WriteLine($"|DESCONTOS              | {Descontos:f2}");
                    Console.WriteLine($"|LÍQUIDO                | {SalarioLiquido:f2}");
                    Console.WriteLine();
                    Console.WriteLine("- Precione qualquer coisa para concluir e encerrar.");
                    Console.ReadKey();
                    /* Quando a folha de pagamento do funcionario for gerada eu terei que incluir mais uma etapa que sera, gerar o recibo de férias.
                    Para isso eu vou consumir dentro do método GerarFolhaDePagamento() da classe FolhaDePagamento, o método GerarReciboDeFerias() da classe Ferias
                    e só após isso vou encerrar o processo.

                    IMPORTATNE: O método de OpcaoDeFerias() que vai ser usado dentro do método GerarFolhaDePagamento() deve ser chamado ANTES do calculo do FGTS.
                    Caso o funcionário não vá tirar ferias o sistema deve concluir o processo e gerar a folha de pagamento.
                    */
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
