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
        // Terei que refatoras todo o código inserindo tratamento de erros, laços de repetição etc a todos os metodos. 
        private double SalarioBase { get; set; }
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

        public double CalcularValeTransporte()
        {
            double porcentagem, passagem, valorPorcentagem,valorPassagem, salarioBruto;
            int diasUteis;

            Console.WriteLine("-Vamos verificar qual o menor valor para desconto do VT.");
            Console.WriteLine();

            Console.WriteLine("-Primeiro passo:");
            Console.Write("-Ensira o Sálario bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-Segundo passo:");
            Console.Write("-Ensira a porcentagem correspondente ao vale transporte: ");
            porcentagem = double.Parse(Console.ReadLine());
            valorPorcentagem = salarioBruto * (porcentagem / 100);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-Terceiro passo:");
            Console.Write("-Ensira o valor da passagem somando ida e volta: R$ ");
            passagem = double.Parse(Console.ReadLine());
            Console.Write("-Ensira a quantidade de dias uteis: ");
            diasUteis = int.Parse(Console.ReadLine());
            valorPassagem =  passagem * (double) diasUteis;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();

            if(valorPorcentagem < valorPassagem)
            {
                Console.WriteLine("\t-Menor Valor.");
                Console.Write($"-Valor a ser descontado por porcentagem: R$ {valorPorcentagem:f2}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t-Maior valor.");
                Console.Write($"-Valor a ser descontado por dias uteis: R$ {valorPassagem:f2}");
                Console.ReadKey();
                Console.WriteLine();
                DescontoDoValeTransporte = valorPorcentagem;
                return DescontoDoValeTransporte;
            }
            else
            {
                Console.WriteLine("\t-Menor valor.");
                Console.Write($"-Valor a ser descontado por dias uteis: R$ {valorPassagem:f2}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t-Maior valor.");
                Console.Write($"-Valor a ser descontado por porcentagem: R$ {valorPorcentagem:f2}");
                Console.ReadKey();
                Console.WriteLine();
                DescontoDoValeTransporte = valorPassagem;
                return DescontoDoValeTransporte;
            }
        } 

        public double CalcularValeAlimentacao()
        {
            int diasUteis;
            double percentual, valorDoVale, descontoDoVale;

            Console.WriteLine("---Vale Refeição/Alimentação---");
            Console.WriteLine();
            Console.Write("-Informe o valor do vale refeição diario: R$ ");
            valorDoVale = double.Parse(Console.ReadLine());
            Console.Write("-Informe a quantidade de dias uteis do mês: ");
            diasUteis = int.Parse(Console.ReadLine());
            Console.Write("-Informe o percentual de desconto do vale: ");
            percentual = double.Parse(Console.ReadLine());
            descontoDoVale = valorDoVale * (double) diasUteis * (percentual / 100);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"-Valor a se descontado de vale refeição/alimentação: R$ {descontoDoVale:f2}");
            Console.ReadKey();
            DescontoDoValeRefeicaoAlimentacao = descontoDoVale;
            return DescontoDoValeRefeicaoAlimentacao;
        } 

        public double CalcularInss()
        {
            double salarioBruto, percentualInss;
            double parcela1 = 0;
            double parcela2 = 19.53;
            double parcela3 = 96.00;
            double parcela4 = 173.81;
            double parcela5 = 877.24;

            Console.WriteLine("---Calculo do INSS---");
            Console.WriteLine();
            Console.Write("- Informe o salario bruto do funcionario sobre o qual será gerado o desconto de INSS: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------------------------");

            if (salarioBruto <= 1302.00) {
                Console.WriteLine("---Desconto feito com base na aliquota de 7,5%---");
                Console.WriteLine();
                percentualInss = 7.5 / 100;
                DescontoDoInss = (salarioBruto * percentualInss) - parcela1;
                Console.WriteLine("- Funcionario isento do desconto de INSS.");
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.ReadKey();
            }

            else if (salarioBruto <= 2571.29) {
                Console.WriteLine("---Desconto feito com base na aliquota de 9%---");
                Console.WriteLine();
                percentualInss = 9.0 / 100;
                DescontoDoInss = (salarioBruto * percentualInss) - parcela2;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.ReadKey();
            }

            else if (salarioBruto <= 3856.94) {
                Console.WriteLine("---Desconto feito com base na aliquota de 12%---");
                Console.WriteLine();
                percentualInss = 12.0 / 100;
                DescontoDoInss = (salarioBruto * percentualInss) - parcela3;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.ReadKey();
            }

            else if (salarioBruto <= 7507.49) {
                Console.WriteLine("---Desconto feito com base na aliquota de 14%---");
                Console.WriteLine();
                percentualInss = 14.0 / 100;
                DescontoDoInss = (salarioBruto * percentualInss) - parcela4;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.ReadKey();
            }

            else {
                Console.WriteLine("---Valores acima de 7.507.49 R$ possuem um desconto fixo de 877.24 R$---");
                Console.WriteLine();
                DescontoDoInss = salarioBruto - parcela5;
                Console.Write($"- Valor de Desconto do INSS: R$ {DescontoDoInss:f2}");
                Console.ReadKey();
            }
            return DescontoDoInss;
        } 

        public double CalcularIr()
        {
            double salarioBruto, baseIr, inss, pensao = 0, dependente = 0, percentual, descontoIr = 0;
            double parcela2 = 142.80;
            double parcela3 = 354.80;
            double parcela4 = 636.13;
            double parcela5 = 869.69;

            Console.WriteLine("---Calculo do IR---");
            Console.WriteLine();
            /* A formula para calcular o IR é: Proventos (entradas) - INSS - Pensão - Dependentes. O valor obtido desse calculo vai ser atribuido a porcentagem de acordo
             com a tabela de desconto do IR.
            O valor por dependentes é de R$ 189,59 */

            Console.Write("- Informe o salário bruto do funcionário: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            inss = DescontoDoInss;
           // Pensao = this.CalcularPensao(); Ainda irei incluir este método.
           // Dependente = this.CalcularDependencia(); Ainda irei incluir este método.
            baseIr = salarioBruto - inss - pensao - dependente;
            Console.WriteLine();

            if (baseIr <= 1903.98)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 0,00%.");
                Console.WriteLine();
                Console.WriteLine("- Isento do desconto de IR, parcela a deduzir: R$ 0,00.");
                Console.ReadKey();
            }
            else if(baseIr <= 2826.65)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 7,50%.");
                Console.WriteLine();
                percentual = 7.50 / 100;
                descontoIr = (baseIr * percentual) - parcela2;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
            }
            else if (baseIr <= 3751.05)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 15,00%.");
                Console.WriteLine();
                percentual = 15.00 / 100;
                descontoIr = (baseIr * percentual) - parcela3;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
            }
            else if(baseIr <= 4664.68)
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIr:f2}");
                Console.WriteLine("- Desconto feito com base na aliquota de: 22,50%.");
                Console.WriteLine();
                percentual = 22.50 / 100;
                descontoIr = (baseIr * percentual) - parcela4;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"- Base de cálculo para IR de: R$ {baseIr:f2}");
                Console.WriteLine("- Base de cálculo de IR maior que 4.664,687 o desconto feito com base na aliquota de: 27,50%.");
                Console.WriteLine();
                percentual = 27.50 / 100;
                descontoIr = (baseIr * percentual) - parcela5;
                Console.Write($"- Valor de Desconto do IR: R$ {descontoIr:f2}");
                Console.ReadKey();
            }
            DescontoDoIrrf = descontoIr;
            return DescontoDoIrrf;

        } 

        public double CalcularAdiantamentoQuinzenal()
        {
            double salarioBruto;
            double porcentagem = 0.4;

            Console.Write("- Informe o Salario bruto: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.WriteLine();

            AdiantamentoQuinzenal = salarioBruto * porcentagem;
            Console.WriteLine($"- Valor do Salário bruto: R$ {salarioBruto:f2}");
            Console.WriteLine($"- Valor do Adiantamento: R$ {AdiantamentoQuinzenal:f2}");

            return AdiantamentoQuinzenal;
        } 

        public double CalcularHoraExtra()
        {
            double valorHora, porcentagem = 0.5, valorHoraExtra, hora, valorTotalHoraExtra = 0, salarioBruto;
            //double HoraMes; - Vou utilizar esta forma quando tiver os métodos todos feitos.
            //double PorcentagemVariavel; vai ser utilizado mais a frente para as Org decidirem qual a porcentagem de Hora Extra deve ser somada.
            //double PorcentagemDeCemPorCento = 1; 

            Console.Write("- Informe seu salario bruto: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            //Console.Write("- Informe  quantidade de horas trabalhadas ao mes: "); - Vou utilizar esta forma quando tiver os métodos todos feitos.
            
            valorHora = salarioBruto / 220;
            valorHoraExtra = valorHora + (valorHora * porcentagem);

            Console.Write("- Informe a quantidade de horas feita de extra: ");
            hora = double.Parse(Console.ReadLine());
            valorTotalHoraExtra = hora * valorHoraExtra;
            Console.WriteLine();

            Console.WriteLine($"- Valor da hora: R${valorHora:f2}");
            Console.WriteLine($"- Valor da hora extra: R${valorHoraExtra:f2}");
            Console.WriteLine($"- Valor total hora extra: R$ {valorTotalHoraExtra:f2}");

            TotalDeHorasExtras = valorHoraExtra;
            return TotalDeHorasExtras;

        } 

        public double CalcularPericulosidadeInsalubridade()
        {
            double valorDaPorcentagem, salarioBruto;
            int beneficio;

            Console.WriteLine();
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
                        //Console.WriteLine($"- Valor do salário base acrescido do percentual de periculosidade: R$ {ValorTotalDePericulosidadeInsalubridade:f2}"); //Depois vou tirar essa linha porque eu não vou precisar retornar o valor ja acrescido, somento o valor que vai ser acrescido.
                        Console.ReadKey();
                        break;

                    case 2:
                            Console.WriteLine("---Cálculo da Insalubridade---");
                            Console.WriteLine();
                            int grau;
                        do
                        {
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
                                valorDaPorcentagem = salarioBruto * 0.1;
                                ValorTotalDePericulosidadeInsalubridade = valorDaPorcentagem + salarioBruto;
                                Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 10% correspodente a: R$ {valorDaPorcentagem:f2}");
                                //Console.WriteLine($"- Valor do salário acrescido do percentual de insalubridade de 10% correspode a: R$ {ValorTotalDePericulosidadeInsalubridade:f2}");
                                Console.ReadKey();
                            }
                            else if (grau == 2)
                            {
                                valorDaPorcentagem = salarioBruto * 0.2;
                                ValorTotalDePericulosidadeInsalubridade = valorDaPorcentagem + salarioBruto;
                                Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 20% correspodente a: R$ {valorDaPorcentagem:f2}");
                                //Console.WriteLine($"- Valor do salário acrescido do percentual de insalubridade de 20% correspode a: R$ {ValorTotalDePericulosidadeInsalubridade:f2}");
                                Console.ReadKey();
                            }
                            else if (grau == 3)
                            {
                                valorDaPorcentagem = salarioBruto * 0.4;
                                ValorTotalDePericulosidadeInsalubridade = valorDaPorcentagem + salarioBruto;
                                Console.WriteLine($"- Valor de acréscimo devido a insalubridade de 40% correspodente a: R$ {valorDaPorcentagem:f2}");
                                //Console.WriteLine($"- Valor do salário acrescido do percentual de insalubridade de 40% correspode a: R$ {ValorTotalDePericulosidadeInsalubridade:f2}");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("- ERRO! Opção inválida, selecione entre [1] ou [2].");
                                Console.WriteLine("- Dígite qualquer coisa para retornar.");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                        }while (grau != 1 && grau != 2 && grau != 3);
                        break;

                    default:
                        Console.WriteLine("- ERRO! Opção inválida, selecione entre [1] ou [2].");
                        Console.WriteLine("- Dígite qualquer coisa para retornar.");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            } while (beneficio != 1 && beneficio != 2);
            return ValorTotalDePericulosidadeInsalubridade;
            
        } 

        public double CalcularAdicionalNoturno()
        {
            double salarioBruto, valorDaHoraNormal, valorDoAdicionalNoturnoHora, acrescimo;
            int quantidadeDeHoras;

            Console.Write("- Informe o salário bruto do funcionário: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            valorDaHoraNormal = salarioBruto / (double) 220;
            acrescimo = valorDaHoraNormal * 0.2;
            valorDoAdicionalNoturnoHora = valorDaHoraNormal + acrescimo;

            Console.Write("- Informe a quantidade de horas trabalhadas como adicional noturno: ");
            quantidadeDeHoras = int.Parse(Console.ReadLine());
            ValorDoAdicionalNoturno = (double) quantidadeDeHoras * valorDoAdicionalNoturnoHora;
            Console.WriteLine();

            Console.WriteLine($"- O valor hora de adicional noturno do funcionário é de: R$ {valorDoAdicionalNoturnoHora:f2}");
            Console.WriteLine($"- O valor total que o funcionário ira receber de adicional noturno é: R$ {ValorDoAdicionalNoturno:f2}");
            return ValorDoAdicionalNoturno;
        } 

        public double CalcularConvenioMedico()
        {
            double salarioBruto, valorDoConvenioMedico;

            Console.WriteLine("---Calcular Convenio Médico---");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());

            //Console.WriteLine("- Selecione qual a empresa que fornece o plano de saúde: "); Só vou utilizar isso depois que ficar o BD com as empresas e seus valores.
            Console.Write("- Informe o valor cobrado pela empresa que fornece o serviço: R$ ");
            valorDoConvenioMedico = double.Parse(Console.ReadLine());
            DescontoDoConvenioMedico = salarioBruto - valorDoConvenioMedico;
            Console.WriteLine();

            Console.WriteLine($"- O valor do convenio médico descontado do funcionarios é de: R$ {valorDoConvenioMedico:f2}");
            Console.WriteLine($"- Salario alterado para: R$ {DescontoDoConvenioMedico:f2}"); // Depois não vou precisar disso então vou retirar fazer o retorno do ValorDoConvenioMedico e tornalo um atributo ao invés de uma variavel. 
            Console.ReadKey();
            return DescontoDoConvenioMedico;
        }  

        public double CalcularConvenioOdontologico()
        {
            double salarioBruto, valorDoConvenioOdontologico;

            Console.WriteLine("---Calcular Convenio Odontológico---");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());

            //Console.WriteLine("- Selecione qual a empresa que fornece o plano odontológico: "); Só vou utilizar isso depois que ficar o BD com as empresas e seus valores.
            Console.Write("- Informe o valor cobrado pela empresa que fornece o serviço: R$ ");
            valorDoConvenioOdontologico = double.Parse(Console.ReadLine());
            DescontoDoConvenioOdontologico = salarioBruto - valorDoConvenioOdontologico;
            Console.WriteLine();

            Console.WriteLine($"- O valor do convenio odontológico descontado do funcionarios é de: R$ {valorDoConvenioOdontologico:f2}");
            Console.WriteLine($"- Salario alterado para: R$ {DescontoDoConvenioOdontologico:f2}"); // Depois não vou precisar disso então vou retirar fazer o retorno do ValorDoConvenioOdontologico e tornalo um atributo ao invés de uma variavel. 
            Console.ReadKey();
            return DescontoDoConvenioOdontologico;
        } 

        public double CalcularDependencia()
        {
            double salarioBruto;
            double dependente = 189.59;
            int quantidadeDeDependentes;

            Console.WriteLine("---Calculando Dependencia---");
            Console.WriteLine();

            Console.Write("- Informe o salário bruto: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de dependentes: R$ ");
            quantidadeDeDependentes = int.Parse(Console.ReadLine());
            DescontoTotalDeDependentes = (double) quantidadeDeDependentes * dependente;

            Console.WriteLine($"- O valor total a ser descontado de dependentes é de: R$ {DescontoTotalDeDependentes:f2}");
            Console.ReadKey();
            return DescontoTotalDeDependentes;
        } 

        public double CalcularPensao()
        {
            int porcento;
            double porcentagem;
            double salarioBruto; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do SalarioBase.
            double horaExtra; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do TotalDaHoraExtra.
            double periculosidadeInsalubridade; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do ValorTotalDePericulosidadeEInsalubridade.
            double adicionalNoturno; //Vou Fazer essa variavel receber o valor que foi calculado no atributo ValorDoAdicionalNoturno.
            double ferias; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do TotalDaFerias que vai estar na classe de férias.
            double inss; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do DescontoDoInss.
            double irrf; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do DescontoDoIr.
            double baseDeCalculoDeDescontoDePensao;


            Console.WriteLine("---Pensão----");
            Console.WriteLine();

            Console.Write("- Informe qual a porcentagem que deverá ser descontado do funcionario: R$ ");
            porcento = int.Parse(Console.ReadLine());
            porcentagem = (double) porcento / 100.0;
            Console.WriteLine();

            Console.WriteLine("- Informe todos proventos obtidos. Caso haja a ausencia de algum deles digite [0].");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe o total obtido de horas extras: R$ ");
            horaExtra = double.Parse(Console.ReadLine());
            Console.Write("- Informe o total obtido de periculosidade ou insalubridade: R$ ");
            periculosidadeInsalubridade = double.Parse(Console.ReadLine());
            Console.Write("- Informe o total obtido de adicional noturno: R$ ");
            adicionalNoturno = double.Parse(Console.ReadLine());
            Console.Write("- Informe o valor obtido de férias: R$ ");
            ferias = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("- Agora informe os descontos legais do funcionario.");
            Console.WriteLine();
            Console.Write("- Informe o valor de desconto do INSS: R$ ");
            inss = double.Parse(Console.ReadLine());
            Console.Write("- Informe o valor de desconto do IR: R$ ");
            irrf = double.Parse(Console.ReadLine());
            Console.WriteLine();

            baseDeCalculoDeDescontoDePensao = (salarioBruto + horaExtra + periculosidadeInsalubridade + adicionalNoturno + ferias) - (inss + irrf);
            DescontoTotalDePensao = baseDeCalculoDeDescontoDePensao * porcentagem;
            Console.WriteLine($"- A base para o calculo de desconto da pensão foi de: R$ {baseDeCalculoDeDescontoDePensao:f2}");
            Console.WriteLine($"- O Desconto a ser retirado de pensão é de: R$ {DescontoTotalDePensao:f2}");
            Console.ReadKey();
            return DescontoTotalDePensao;
        } 

        public double CalcularAtrasos()
        {
            double horasConvertidas;
            int converter, tipoDeDesconto;

            Console.WriteLine("---Atrasos--");
            Console.WriteLine();

            Console.WriteLine("- Se for necessario fazer a conversão de minutos em horas para as proximas formulas digite [1], caso contrario digite [2].");
            Console.Write("- Converter...: ");
            converter = int.Parse(Console.ReadLine());

            if(converter == 1)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                horasConvertidas = this.ConversorDeMinutosEmHoras();
            }
            else{ }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("- Selecione qual o tipo de atraso deseja calcular.");
            Console.WriteLine();
            Console.WriteLine("- Para desconto de atraso comum dígite............................[1]");
            Console.WriteLine("- Para desconto de falta injustifícada ao trabalho dígite.........[2]");
            Console.WriteLine("- Para desconto de falta ao trabalho com DSR dígite...............[3]");
            Console.WriteLine("- Para sair dígite................................................[4]");
            Console.Write("- Tipo de desconto...: ");
            tipoDeDesconto = int.Parse(Console.ReadLine());
            Console.Clear();


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
                    Console.WriteLine("-Error, Valor Invalido");
                    break;
            }
            return TotalDeAtrasos;
        } 

        private double ConversorDeMinutosEmHoras()
        {
            int quantidadeDehorasFechadas, quantidadeDeMinutos;
            double totalDeMinutos;
            //double QuantidadeDehoras;

            Console.WriteLine("---Conversor de Horas Para Minutos---");
            Console.WriteLine();

            Console.Write("- Informe a quantidade de horas fechadas: ");
            quantidadeDehorasFechadas = int.Parse(Console.ReadLine());

            Console.Write("- Informe a quantidade de minutos: ");
            quantidadeDeMinutos = int.Parse(Console.ReadLine());
            totalDeMinutos = (double) quantidadeDeMinutos / 60.0;

            TotalDeHorasConvertidas = (double) quantidadeDehorasFechadas + totalDeMinutos;
            Console.WriteLine();
            Console.WriteLine($"- Total de Horas: {TotalDeHorasConvertidas}");
            return TotalDeHorasConvertidas;
        }

        private double AtrasoComum()
        {
            double salarioBruto;
            int jornada, horasEmAtraso;

            Console.Write("- Informe o salario bruto do funcionario: R$ ");
            salarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de atrasos em horas: ");
            horasEmAtraso = int.Parse(Console.ReadLine());
            Console.Write("- Informe as horas da jornada de trabalho: ");
            jornada = int.Parse(Console.ReadLine());

            DescontoDeAtrasos = (salarioBruto * (double) horasEmAtraso) / (double) jornada;
            Console.WriteLine();

            Console.WriteLine($"- O valor de desconto devido a atrasos é de: R$ {DescontoDeAtrasos:f2}");
            Console.WriteLine($"- Total de horas em atraso: {horasEmAtraso}");
            Console.ReadKey();
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
            Console.ReadKey();
            return DescontoDeFaltasInjustificadas;
        } 

        private double FaltaInjustificadaComDsr()
        {
            double salarioBruto, valorDoDsr, horaExtra, valorDoReflexo;
            int faltas, dsr, reflexoDoDsr, diasUteis, dsrDoMes;

            Console.WriteLine("--- Falta Injustificada com DSR---");
            Console.WriteLine();

            Console.WriteLine("- Primeiro vamos calcular o valor do dsr do funcionario.");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: ");
            salarioBruto = double.Parse(Console.ReadLine());
            valorDoDsr = salarioBruto / 30;
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
            Console.ReadKey();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("- O funcionario realizou horas extras ou teve algum acrescimo ao salário no mes? Caso sim o reflexo do DSR deverá ser calculado.");
            Console.WriteLine();
            Console.WriteLine("- Para sim dígite [1]");
            Console.WriteLine("- Para não dígite [2]");
            Console.Write("- Reflexo...: ");
            reflexoDoDsr = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if(reflexoDoDsr == 1)
            {
                Console.Write("- Informe o valor da hora extra/comissão obtido pelo funcionario no mês: R$ ");
                horaExtra = double.Parse(Console.ReadLine());
                Console.Write("- Informe a quantidade de dias uteis do mes: ");
                diasUteis = int.Parse(Console.ReadLine());
                Console.Write("- Informe a quantidade de DSR do mes: ");
                dsrDoMes = int.Parse(Console.ReadLine());
                valorDoReflexo = (horaExtra / (double) diasUteis) * (double) dsrDoMes;
                FaltasInjustificadasComDsr += valorDoReflexo;
                Console.WriteLine();
                Console.WriteLine($"- O valor do reflexo é de: R$ {valorDoReflexo:f2}");
                Console.WriteLine($"- O valor a ser descontado por falta ao trabalho + DSR + reflexo do DSR é de: R$ {FaltasInjustificadasComDsr:f2}");
                Console.ReadKey();
            }
            else if(reflexoDoDsr == 2)
            {
                Console.WriteLine("- Dígite qualquer coisa para retornar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("- ERROR, Valor invalida selecione entre as opções [1] ou [2].");
                Console.WriteLine("- Dígite qualquer coisa para retornar");
                Console.ReadKey(); // Aqui eu vou fazer um laço para repetir o processo quando um valor invalido for digitado.
            }
            return FaltasInjustificadasComDsr;
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
                    double salarioBase;
                    int simNao;

                    Console.WriteLine("\t\t---Modelo Sequência---");
                    Console.WriteLine();
                    Console.WriteLine("- Etapa 1");
                    Console.Write("- Informe o salário base do funcionário: R$ ");
                    salarioBase = double.Parse(Console.ReadLine());
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
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
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
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
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
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
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
                    Console.WriteLine();
                }

            } while (escolha != 1 && escolha != 2);
            return valor;
        }
      
    }
}
