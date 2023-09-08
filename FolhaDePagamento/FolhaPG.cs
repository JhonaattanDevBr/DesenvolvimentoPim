﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class FolhaPG
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
        private double Fgts { get; set; }
        public string MensagemIRRF { get; set; }


        public double ContabilizarValeTransporte(double salario, double passagem, int dias)
        {
            double valorPorcentagem, valorPassagem, porcentagem;
            int percentual = 6;
            try
            {
                porcentagem = (double) percentual / 100;
                valorPorcentagem = salario * porcentagem;
                valorPassagem = passagem * (double) dias;
                if (valorPorcentagem < valorPassagem)
                {
                    DescontoDoValeTransporte = valorPorcentagem;
                    return valorPorcentagem;
                }
                else
                {
                    DescontoDoValeTransporte = valorPassagem;
                    return valorPassagem;
                }
            }
            catch (Exception ex)
            {
                // Depois vou incluir uma msg de retorno com erro. 
                throw new Exception("Falha ao calcular o vale transporte."+ ex);
            }
        } 

        public double CalcularValeAlimentacao(double valorDoVale, int diasUteis, int percentual)
        {  
            double porcentagem, descontoDoVale;
            try
            {
                porcentagem =  percentual / (double) 100;
                descontoDoVale = valorDoVale * (double) diasUteis * porcentagem;
                DescontoDoValeRefeicaoAlimentacao = descontoDoVale;
                return descontoDoVale;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao calcular o vale alimentação." + ex);
            }
        } 

        public double CalcularInss(double salarioBase)
        {
            try
            {
                double valorDoInss;
                valorDoInss = FormulaDoInss(salarioBase);
                DescontoDoInss = valorDoInss;
                return valorDoInss;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação!" + ex); ;
            }
        } 

        public double FormulaDoInss(double salario)
        {
            double ValorDeDescontoDoInss, faixa2, faixa3, faixa4, restante;
            double valorPadraoFaixa1 = 99.00;
            double valorPadraoFaixa2 = 112.62;
            double valorPadraoFaixa3 = 154.28;
            double valorPadraoFaixa4 = 511.06;
            try
            {
                if (salario <= 1320.00)
                {
                    ValorDeDescontoDoInss = salario * 0.075;
                }
                else if (salario <= 2571.29)
                {
                    restante = salario - 1320.00;
                    faixa2 = restante * 0.09;
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + faixa2;
                }
                else if (salario <= 3856.94)
                {
                    restante = salario - 2571.29;
                    faixa3 = restante * 0.12;
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + faixa3;
                }
                else if (salario <= 7507.49)
                {
                    restante = salario - 3856.94;
                    faixa4 = restante * 0.14;
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + valorPadraoFaixa3 + faixa4;
                }
                else
                {
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + valorPadraoFaixa3 + valorPadraoFaixa4;
                }
                return ValorDeDescontoDoInss;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação!" + ex);
            }
        }

        public double CalcularIrrf(double salarioBase)
        {
            double valorDoInss = DescontoDoInss;
            double valorDaPensao = DescontoTotalDePensao;
            double valorDeDependente = DescontoTotalDeDependentes;
            double valorDoIrrf;
            try
            {
                valorDoIrrf = FormulaDoIrrf(salarioBase, valorDoInss, valorDaPensao, valorDeDependente);
                DescontoDoIrrf = valorDoIrrf;
                return valorDoIrrf;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação!" + ex);
            }
        } 

        public double FormulaDoIrrf(double salario, double inss, double pensao, double dependente)
        {
            double deducoesLegais, descontoSimplificado, baseDeCalculoDoIrrfDefinitivo, valorDeDescontoDoIrrf = 0, percentual;
            double parcela2 = 158.40;
            double parcela3 = 370.40;
            double parcela4 = 651.73;
            double parcela5 = 884.96;
            double valorSimplificado = 528.00;
            try
            {
                deducoesLegais = salario - inss - pensao - dependente;
                descontoSimplificado = salario - valorSimplificado;

                if (deducoesLegais > descontoSimplificado)
                {
                    baseDeCalculoDoIrrfDefinitivo = deducoesLegais;
                    if (baseDeCalculoDoIrrfDefinitivo <= 2112.00)
                    {
                        MensagemIRRF = "Calculo realizado sobre deduções legais.";
                        valorDeDescontoDoIrrf = 0;
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 2826.65)
                    {
                        percentual = 7.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela2;
                        MensagemIRRF = "Calculo realizado sobre deduções legais.";
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 3751.05)
                    {
                        percentual = 15.00 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela3;
                        MensagemIRRF = "Calculo realizado sobre deduções legais.";
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 4664.68)
                    {
                        percentual = 22.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela4;
                        MensagemIRRF = "Calculo realizado sobre deduções legais.";
                    }
                    else
                    {
                        percentual = 27.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela5;
                        MensagemIRRF = "Calculo realizado sobre deduções legais.";
                    }
                }
                else
                {
                    baseDeCalculoDoIrrfDefinitivo = descontoSimplificado;
                    if (baseDeCalculoDoIrrfDefinitivo <= 2112.00)
                    {
                        valorDeDescontoDoIrrf = 0;
                        MensagemIRRF = "Calculo realizado sobre o desconto simplificado.";
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 2826.65)
                    {
                        percentual = 7.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela2;
                        MensagemIRRF = "Calculo realizado sobre o desconto simplificado.";
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 3751.05)
                    {
                        percentual = 15.00 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela3;
                        MensagemIRRF = "Calculo realizado sobre o desconto simplificado.";
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 4664.68)
                    {
                        percentual = 22.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela4;
                        MensagemIRRF = "Calculo realizado sobre o desconto simplificado.";
                    }
                    else
                    {
                        percentual = 27.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela5;
                        MensagemIRRF = "Calculo realizado sobre o desconto simplificado.";
                    }
                }
                return valorDeDescontoDoIrrf;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação." + ex);
            }
        }

        public double CalcularAdiantamentoQuinzenal(double salarioBruto)
        {
            double adiantamento, porcentagem = 0.4;
            adiantamento = salarioBruto * porcentagem;
            AdiantamentoQuinzenal = adiantamento;
            return adiantamento;
        }

        public double ConversorDeMinutosEmHoras(int quantidadeDehorasFechadas, int quantidadeDeMinutos)
        {
            double totalDeMinutos, totalDeHoras;
            try
            {
                do
                {
                    if (quantidadeDeMinutos <= 0 || quantidadeDeMinutos > 60)
                    {
                        // Aqui eu vou mostrar na tela uma mensagem dizendo q o valor não pode ser > 60.
                    }
                } while (quantidadeDeMinutos <= 0 || quantidadeDeMinutos > 60);

                totalDeMinutos = (double) quantidadeDeMinutos / 60.0;
                totalDeHoras = (double) quantidadeDehorasFechadas + totalDeMinutos;
                TotalDeHorasConvertidas = totalDeHoras;
                return totalDeHoras;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a operação!");
            }
           
        }

        private double CalcularDsr(int diasUteis, int descansosFeriados, double valor)
        {
            try
            {
                double valorDoDsr;
                valorDoDsr = (valor / (double)diasUteis) * descansosFeriados;
                return valorDoDsr;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
            
        }

        public double CalcularHoraExtra(double salario, double porcentagem, int hora)
        {
            double valorDaHoraNormal, valorDeUmaHoraExtra, valorTotalDaHoraExtra;
            try
            {
                valorDaHoraNormal = salario / 220;
                valorDeUmaHoraExtra = valorDaHoraNormal * porcentagem;
                valorTotalDaHoraExtra = hora * valorDeUmaHoraExtra;
                TotalDeHorasExtras = valorTotalDaHoraExtra;
                return valorTotalDaHoraExtra;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
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
                    //   horaConvertida = ConversorDeMinutosEmHoras(); Só comentei pra parar de dar erro
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

        public double CalcularConvenioMedico(double salario, double convenio)
        {
            double valorDoConvenioMedico;
            valorDoConvenioMedico = salario - convenio;
            DescontoDoConvenioMedico = valorDoConvenioMedico;
            return valorDoConvenioMedico;
        }  

        public double CalcularConvenioOdontologico(double salario, double convenio)
        {
            double valorDoConvenioOdontologico;
            valorDoConvenioOdontologico = salario - convenio;
            DescontoDoConvenioOdontologico = valorDoConvenioOdontologico;
            return valorDoConvenioOdontologico;
        } 

        public double CalcularDependencia(int quantidadeDeDependentes)
        {
            double valorTotalDeDependente, valorPorDependente = 189.59;
            valorTotalDeDependente = (double) quantidadeDeDependentes * valorPorDependente;
            DescontoTotalDeDependentes = valorTotalDeDependente;
            return valorTotalDeDependente;
        } 

        public double CalcularPensao(int porcentagemFixada)
        {
            double porcentagemFixadaConvertida, salarioMinimo = 1320.00, valorDaPensao;
            porcentagemFixadaConvertida = (double) porcentagemFixada / 100.0;
            valorDaPensao = salarioMinimo * porcentagemFixadaConvertida;
            DescontoTotalDePensao = valorDaPensao;
            return valorDaPensao;
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
                   // horasConvertidas = this.ConversorDeMinutosEmHoras(); Só comentei pra parar de dar erro
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

        public double CalcularFgts(double salario)
        {
            double fgts;
            fgts = salario * 0.08;
            Fgts = fgts;
            return fgts;
        }
        /*
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
                    Console.WriteLine();

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
        }*/
    }
}
