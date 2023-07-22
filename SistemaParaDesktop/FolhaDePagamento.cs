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

        public double CalcularAdicionalNoturno()
        {
            double SalarioBruto, ValorDaHoraNormal, ValorDoAdicionalNoturnoHora, Acrescimo;
            int QuantidadeDeHoras;

            Console.WriteLine("---Calculando Adicional Noturno---");
            Console.WriteLine();

            Console.Write("- Informe o salário bruto do funcionário: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            ValorDaHoraNormal = SalarioBruto / (double) 220;
            Acrescimo = ValorDaHoraNormal * 0.2;
            ValorDoAdicionalNoturnoHora = ValorDaHoraNormal + Acrescimo;

            Console.Write("- Informe a quantidade de horas trabalhadas como adicional noturno: ");
            QuantidadeDeHoras = int.Parse(Console.ReadLine());
            ValorDoAdicionalNoturno = (double) QuantidadeDeHoras * ValorDoAdicionalNoturnoHora;
            Console.WriteLine();

            Console.WriteLine($"- O valor da hora no adicional noturno do funcionário é de: R$ {ValorDoAdicionalNoturnoHora:f2}");
            Console.WriteLine($"- O valor total do adicional noturno do funcionario é de: R$ {ValorDoAdicionalNoturno:f2}");
            Console.WriteLine("- Dígite qualquer coisa para continuar.");
            
            Console.ReadKey();
            return ValorDoAdicionalNoturno;
        }

        public double CalcularConvenioMedico()
        {
            double SalarioBruto, ValorDoConvenioMedico;

            Console.WriteLine("---Calcular Convenio Médico---");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());

            //Console.WriteLine("- Selecione qual a empresa que fornece o plano de saúde: "); Só vou utilizar isso depois que ficar o BD com as empresas e seus valores.
            Console.Write("- Informe o valor cobrado pela empresa que fornece o serviço: R$ ");
            ValorDoConvenioMedico = double.Parse(Console.ReadLine());
            DescontoDoConvenioMedico = SalarioBruto - ValorDoConvenioMedico;
            Console.WriteLine();

            Console.WriteLine($"- O valor do convenio médico descontado do funcionarios é de: R$ {ValorDoConvenioMedico:f2}");
            Console.WriteLine($"- Salario alterado para: R$ {DescontoDoConvenioMedico:f2}"); // Depois não vou precisar disso então vou retirar fazer o retorno do ValorDoConvenioMedico e tornalo um atributo ao invés de uma variavel. 
            Console.ReadKey();
            return DescontoDoConvenioMedico;
        }

        public double CalcularConvenioOdontologico()
        {
            double SalarioBruto, ValorDoConvenioOdontologico;

            Console.WriteLine("---Calcular Convenio Odontológico---");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());

            //Console.WriteLine("- Selecione qual a empresa que fornece o plano odontológico: "); Só vou utilizar isso depois que ficar o BD com as empresas e seus valores.
            Console.Write("- Informe o valor cobrado pela empresa que fornece o serviço: R$ ");
            ValorDoConvenioOdontologico = double.Parse(Console.ReadLine());
            DescontoDoConvenioOdontologico = SalarioBruto - ValorDoConvenioOdontologico;
            Console.WriteLine();

            Console.WriteLine($"- O valor do convenio odontológico descontado do funcionarios é de: R$ {ValorDoConvenioOdontologico:f2}");
            Console.WriteLine($"- Salario alterado para: R$ {DescontoDoConvenioOdontologico:f2}"); // Depois não vou precisar disso então vou retirar fazer o retorno do ValorDoConvenioOdontologico e tornalo um atributo ao invés de uma variavel. 
            Console.ReadKey();
            return DescontoDoConvenioOdontologico;
        }

        public double CalcularDependencia()
        {
            double SalarioBruto;
            double Dependente = 189.59;
            int QuantidadeDeDependentes;

            Console.WriteLine("---Calculando Dependencia---");
            Console.WriteLine();

            Console.Write("- Informe o salário bruto: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de dependentes: R$ ");
            QuantidadeDeDependentes = int.Parse(Console.ReadLine());
            DescontoTotalDeDependentes = (double) QuantidadeDeDependentes * Dependente;

            Console.WriteLine($"- O valor total a ser descontado de dependentes é de: R$ {DescontoTotalDeDependentes:f2}");
            Console.ReadKey();
            return DescontoTotalDeDependentes;
        }

        public double CalcularPensao()
        {
            int Porcento;
            double Porcentagem;
            double SalarioBruto; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do SalarioBase.
            double HoraExtra; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do TotalDaHoraExtra.
            double PericulosidadeEInsalubridade; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do ValorTotalDePericulosidadeEInsalubridade.
            double AdicionalNoturno; //Vou Fazer essa variavel receber o valor que foi calculado no atributo ValorDoAdicionalNoturno.
            double Ferias; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do TotalDaFerias que vai estar na classe de férias.
            double Inss; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do DescontoDoInss.
            double Ir; //Vou Fazer essa variavel receber o valor que foi calculado no atributo do DescontoDoIr.
            double BaseDeCalculoDeDescontoDePensao;


            Console.WriteLine("---Pensão----");
            Console.WriteLine();

            Console.Write("- Informe qual a porcentagem que deverá ser descontado do funcionario: R$ ");
            Porcento = int.Parse(Console.ReadLine());
            Porcentagem = (double) Porcento / 100.0;
            Console.WriteLine();

            Console.WriteLine("- Informe todos proventos obtidos. Caso haja a ausencia de algum deles digite [0].");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe o total obtido de horas extras: R$ ");
            HoraExtra = double.Parse(Console.ReadLine());
            Console.Write("- Informe o total obtido de periculosidade ou insalubridade: R$ ");
            PericulosidadeEInsalubridade = double.Parse(Console.ReadLine());
            Console.Write("- Informe o total obtido de adicional noturno: R$ ");
            AdicionalNoturno = double.Parse(Console.ReadLine());
            Console.Write("- Informe o valor obtido de férias: R$ ");
            Ferias = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("- Agora informe os descontos legais do funcionario.");
            Console.WriteLine();
            Console.Write("- Informe o valor de desconto do INSS: R$ ");
            Inss = double.Parse(Console.ReadLine());
            Console.Write("- Informe o valor de desconto do IR: R$ ");
            Ir = double.Parse(Console.ReadLine());
            Console.WriteLine();

            BaseDeCalculoDeDescontoDePensao = (SalarioBruto + HoraExtra + PericulosidadeEInsalubridade + AdicionalNoturno + Ferias) - (Inss + Ir);
            DescontoTotalDePensao = BaseDeCalculoDeDescontoDePensao * Porcentagem;
            Console.WriteLine($"- A base para o calculo de desconto da pensão foi de: R$ {BaseDeCalculoDeDescontoDePensao:f2}");
            Console.WriteLine($"- O Desconto a ser retirado de pensão é de: R$ {DescontoTotalDePensao:f2}");
            Console.ReadKey();
            return DescontoTotalDePensao;

        }

        public double CalcularAtrasos()
        {
            double HorasConvertidas;
            int Converter, TipoDeDesconto;

            Console.WriteLine("---Atrasos--");
            Console.WriteLine();

            Console.WriteLine("- Se for necessario fazer a conversão de minutos em horas para as proximas formulas digite [1], caso contrario digite [2].");
            Console.Write("- Converter...: ");
            Converter = int.Parse(Console.ReadLine());

            if(Converter == 1)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                HorasConvertidas = this.ConversorDeMinutosEmHoras();
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
            TipoDeDesconto = int.Parse(Console.ReadLine());
            Console.Clear();


            switch (TipoDeDesconto)
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
            int QuantidadeDehorasFechadas, QuantidadeDeMinutos;
            double TotalDeMinutos;
            //double QuantidadeDehoras;

            Console.WriteLine("---Conversor de Horas Para Minutos---");
            Console.WriteLine();

            Console.Write("- Informe a quantidade de horas fechadas: ");
            QuantidadeDehorasFechadas = int.Parse(Console.ReadLine());

            Console.Write("- Informe a quantidade de minutos: ");
            QuantidadeDeMinutos = int.Parse(Console.ReadLine());
            TotalDeMinutos = (double) QuantidadeDeMinutos / 60.0;

            TotalDeHorasConvertidas = (double) QuantidadeDehorasFechadas + TotalDeMinutos;
            Console.WriteLine();
            Console.WriteLine($"- Total de Horas: {TotalDeHorasConvertidas}");
            return TotalDeHorasConvertidas;
        }

        private double AtrasoComum()
        {
            double SalarioBruto;
            int Jornada, HorasEmAtraso;

            Console.Write("- Informe o salario bruto do funcionario: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de atrasos em horas: ");
            HorasEmAtraso = int.Parse(Console.ReadLine());
            Console.Write("- Informe as horas da jornada de trabalho: ");
            Jornada = int.Parse(Console.ReadLine());

            DescontoDeAtrasos = (SalarioBruto * (double)HorasEmAtraso) / (double) Jornada;
            Console.WriteLine();

            Console.WriteLine($"- O valor de desconto devido a atrasos é de: R$ {DescontoDeAtrasos:f2}");
            Console.WriteLine($"- Total de horas em atraso: {HorasEmAtraso}");
            Console.ReadKey();
            return DescontoDeAtrasos;
        }

        private double FaltaInjustificada()
        {
            double SalarioBruto;
            int Faltas;

            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            Console.Write("- Informe a quantidade de faltas do funcionario: ");
            Faltas = int.Parse(Console.ReadLine());
            DescontoDeFaltasInjustificadas = (SalarioBruto * (double) Faltas) / (double) 30;
            Console.WriteLine();
            Console.WriteLine($"- O valor de desconto devido a faltas injustificadas é de: R$ {DescontoDeFaltasInjustificadas:f2}");
            Console.ReadKey();
            return DescontoDeFaltasInjustificadas;
        }

        private double FaltaInjustificadaComDsr()
        {
            double SalarioBruto, ValorDoDsr, HoraExtra, ValorDoReflexo;
            int Faltas, Dsr, ReflexoDoDsr, DiasUteis, DsrDoMes;

            Console.WriteLine("--- Falta Injustificada com DSR---");
            Console.WriteLine();

            Console.WriteLine("- Primeiro vamos calcular o valor do dsr do funcionario.");
            Console.WriteLine();
            Console.Write("- Informe o salário bruto do funcionario: ");
            SalarioBruto = double.Parse(Console.ReadLine());
            ValorDoDsr = SalarioBruto / 30;
            Console.WriteLine($"- O valor do DSR do funcionario é de: R$ {ValorDoDsr:f2}");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("- Segundo, vamos calcular o desconto por falta ao trabalho com DSR.");
            Console.WriteLine();
            Console.Write("- Informe a quantidade de faltas do funcionario: ");
            Faltas = int.Parse(Console.ReadLine());
            Console.Write("- informe a quantidade de DSR´s que deve ser descontado: ");
            Dsr = int.Parse(Console.ReadLine());
            FaltasInjustificadasComDsr = ((SalarioBruto * (double) Faltas) / (double) 30) + ((double) Dsr * ValorDoDsr) ;
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
            ReflexoDoDsr = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if( ReflexoDoDsr == 1)
            {
                Console.Write("- Informe o valor da hora extra/comissão obtido pelo funcionario no mês: R$ ");
                HoraExtra = double.Parse(Console.ReadLine());
                Console.Write("- Informe a quantidade de dias uteis do mes: ");
                DiasUteis = int.Parse(Console.ReadLine());
                Console.Write("- Informe a quantidade de DSR do mes: ");
                DsrDoMes = int.Parse(Console.ReadLine());
                ValorDoReflexo = (HoraExtra / (double) DiasUteis) * (double) DsrDoMes;
                FaltasInjustificadasComDsr += ValorDoReflexo;
                Console.WriteLine();
                Console.WriteLine($"- O valor do reflexo é de: R$ {ValorDoReflexo:f2}");
                Console.WriteLine($"- O valor a ser descontado por falta ao trabalho + DSR + reflexo do DSR é de: R$ {FaltasInjustificadasComDsr:f2}");
                Console.ReadKey();
            }
            else if( ReflexoDoDsr == 2)
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
            double SalarioBruto;

            Console.WriteLine("---Calcular o FGTS---");
            Console.WriteLine();

            Console.Write("- Informe o salário bruto do funcionario: R$ ");
            SalarioBruto = double.Parse(Console.ReadLine());
            Fgts = SalarioBruto * 0.08;
            Console.WriteLine();
            Console.WriteLine($"- O valor do FGTS a ser depositado é de: R$ {Fgts:f2}");
            Console.ReadKey();
            return Fgts;
        }
    }
}
