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
        private int DiasVendidos { get; set; }
        private int Saida { get; set; }
        private int Retorno { get; set; }
        private double BrutoDeFerias { get; set; }
        private double LiquidoDeFerias { get; set; }
        private double AbonoPecuniario { get; set; }
        private double UmTercoDoAbonoPecuniario { get; set; }
        private double InssFerias { get; set; }
        private double IrrfFerias { get; set; }
        

        public void ConsultarBeneficioDasFerias()
        {
            // Aqui eu vou fazer algumas consultas ao banco de dados e retornar algumas informações para o usuario.
        }

        public void AgendarFerias()
        {
            string primeiroMes, segundoMes, terceiroMes;
            int escolha, periodo, diasVendidos, ferias = 30, primeiroPeriodo = 0, segundoPeriodo = 0, terceiroPeriodo = 0;
            char venda;

            Console.WriteLine("- Informe como o funcionário deseja tirar as férias.");
            Console.WriteLine();
            Console.WriteLine("- Para férias completas dígite [1]");
            Console.WriteLine("- Para férias em dois periodos dígite [2]");
            Console.WriteLine("- Para férias em três periodos dígite [3]");
            Console.Write("- Escolha...: ");
            escolha = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (escolha)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("- O funcionário optou por fazer a venda das férias. [S] ou [N] ?");
                        Console.Write("- Vender...: ");
                        venda = char.Parse(Console.ReadLine().ToUpper());
                        Console.WriteLine();
                        if (venda == 'S')
                        {
                            do
                            {
                                Console.WriteLine("- Informe quantos dias ele deseja vender. MÁXIMO Permitido 10 dias");
                                Console.Write("- Dias vendidos...: ");
                                diasVendidos = int.Parse(Console.ReadLine());
                                ferias = 30;
                                ferias = ferias - diasVendidos;
                                Console.WriteLine();
                            } while (diasVendidos > 10);
                            Console.WriteLine($"- O funcionário téra {ferias} dias de ferias devido a venda de {diasVendidos} dias.");
                            Console.WriteLine();
                            Console.WriteLine("- Informe o mes que o funcionario solicitou as férias: ");
                            Console.Write("- Mês...: ");
                            primeiroMes = Console.ReadLine();
                            Console.WriteLine();
                        }
                        else if (venda == 'N') 
                        {
                        }
                        else
                        {
                            Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                            Console.WriteLine("- Dígite qualquer coisa para continuar.");
                            Console.ReadKey();
                            Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                            Console.WriteLine();
                        }
                    } while (venda != 'S' && venda != 'N');
                    // Aqui vou precisar enviar as informações das variaveis para o banco de dados.
                    break;

                case 2:
                    Console.WriteLine("- O funcionário optou por fazer a venda das férias. [S] ou [N] ?");
                    Console.Write("- Vender...: ");
                    venda = char.Parse(Console.ReadLine().ToUpper());
                    Console.WriteLine();
                    if (venda == 'S')
                    {
                        do
                        {
                            Console.WriteLine("- Informe quantos dias ele deseja vender. MÁXIMO Permitido 10 dias");
                            Console.Write("- Dias vendidos...: ");
                            diasVendidos = int.Parse(Console.ReadLine());
                            ferias = 30;
                            ferias = ferias - diasVendidos;
                            Console.WriteLine();
                            
                        } while (diasVendidos > 10);
                        Console.WriteLine($"- O funcionário téra {ferias} dias de férias devido a venda de {diasVendidos} dias.");   
                        do
                        {
                            Console.WriteLine();
                            Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                            primeiroPeriodo = int.Parse(Console.ReadLine());
                            Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                            segundoPeriodo = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (primeiroPeriodo + segundoPeriodo > ferias)
                            {
                                Console.WriteLine("--- ATENÇÃO!");
                                Console.WriteLine($"- Por optar em realizar a venda de {diasVendidos} dias das férias, os dias gozados do funcionário não podem exceder a {ferias}.");
                            }
                        } while (primeiroPeriodo + segundoPeriodo > ferias);
                        Console.WriteLine("- Informe o mes do primeiro periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        primeiroMes = Console.ReadLine();
                        Console.WriteLine("- Informe o mes do segundo periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        segundoMes = Console.ReadLine();
                    }
                    else if(venda == 'N')
                    {
                        do
                        {
                            Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                            primeiroPeriodo = int.Parse(Console.ReadLine());
                            Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                            segundoPeriodo = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (primeiroPeriodo + segundoPeriodo > ferias)
                            {
                                Console.WriteLine("--- ATENÇÃO!");
                                Console.WriteLine($"- Os dias gozados do funcionário não podem exceder a {ferias} dias.");
                                Console.WriteLine();
                            }
                        } while (primeiroPeriodo + segundoPeriodo > ferias);
                        Console.WriteLine("- Informe o mes do primeiro periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        primeiroMes = Console.ReadLine();
                        Console.WriteLine("- Informe o mes do segundo periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        segundoMes = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                        Console.WriteLine("- Dígite qualquer coisa para continuar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                    }
                    // Aqui vou precisar enviar as informações das variaveis para o banco de dados.
                    break;

                case 3:
                    Console.WriteLine("- O funcionário optou por fazer a venda das férias. [S] ou [N] ?");
                    Console.Write("- Vender...: ");
                    venda = char.Parse(Console.ReadLine().ToUpper());
                    Console.WriteLine();
                    if (venda == 'S')
                    {
                        do
                        {
                            Console.WriteLine("- Informe quantos dias ele deseja vender. MÁXIMO Permitido 10 dias");
                            Console.Write("- Dias vendidos...: ");
                            diasVendidos = int.Parse(Console.ReadLine());
                            ferias = 30;
                            ferias = ferias - diasVendidos;
                            Console.WriteLine();
                        } while (diasVendidos > 10);
                        Console.WriteLine($"- O funcionário téra {ferias} dias de férias devido a venda de {diasVendidos} dias.");
                        Console.WriteLine();


                        Console.WriteLine("- Um dos periodos deve ser de no minimo 14 dias. Escolha um deles.");
                        Console.WriteLine();
                        Console.WriteLine("- Para primeiro periodo dígite [1]");
                        Console.WriteLine("- Para segundo periodo dígite [2]");
                        Console.WriteLine("- Para terceiro periodo dígite [3]");
                        Console.Write("- Periodo...: ");
                        periodo = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        do {
                            if (periodo == 1)
                            {
                                do
                                {
                                    Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                                    primeiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                } while (primeiroPeriodo < 14);
                                do
                                {
                                    Console.WriteLine("- Agora informe os outros dois periodos. Nenhum deles pode ser menor que 5 dias.");
                                    Console.WriteLine();
                                    Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                                    segundoPeriodo = int.Parse(Console.ReadLine());
                                    Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
                                    terceiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("--- ATENÇÃO!");
                                        Console.WriteLine($"- Por optar em realizar a venda de {diasVendidos} dias das férias, os dias gozados do funcionário não podem exceder ou ser menor que os {ferias} das férias.");
                                    }
                                    Console.WriteLine();
                                } while (!(segundoPeriodo >= 5 && terceiroPeriodo >= 5 && primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias));
                            }
                            else if (periodo == 2)
                            {
                                do
                                {
                                    Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                                    segundoPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                } while (segundoPeriodo < 14);
                                do
                                {
                                    Console.WriteLine("- Agora informe os outros dois periodos. Nenhum deles pode ser menor que 5 dias.");
                                    Console.WriteLine();
                                    Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                                    primeiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
                                    terceiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("--- ATENÇÃO!");
                                        Console.WriteLine($"- Por optar em realizar a venda de {diasVendidos} dias das férias, os dias gozados do funcionário não podem exceder ou ser menor que os {ferias} das férias.");
                                    }
                                    Console.WriteLine();
                                } while (!(primeiroPeriodo >= 5 && terceiroPeriodo >= 5 && primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias));
                                
                            }
                            else if (periodo == 3)
                            {
                                do
                                {
                                    Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
                                    terceiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                } while (terceiroPeriodo < 14);
                                do
                                {
                                    Console.WriteLine("- Agora informe os outros dois periodos. Nenhum deles pode ser menor que 5 dias.");
                                    Console.WriteLine();
                                    Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                                    primeiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                                    segundoPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("--- ATENÇÃO!");
                                        Console.WriteLine($"- Por optar em realizar a venda de {diasVendidos} dias das férias, os dias gozados do funcionário não podem exceder ou ser menor que os {ferias} das férias.");
                                    }
                                    Console.WriteLine();
                                } while (!(primeiroPeriodo >= 5 && segundoPeriodo >= 5 && primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias));
                                
                            }
                            else
                            {
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                            }
                        } while (periodo != 1 && periodo != 2 && periodo != 3);
                        Console.WriteLine();

                        Console.WriteLine("- Informe o mes do primeiro periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        primeiroMes = Console.ReadLine();
                        Console.WriteLine("- Informe o mes do segundo periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        segundoMes = Console.ReadLine();
                        Console.WriteLine("- Informe o mes do segundo periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        terceiroMes = Console.ReadLine();
                    }
                    else if (venda == 'N')
                    {
                        Console.WriteLine("- Um dos periodos deve ser de no minimo 14 dias. Escolha um deles.");
                        Console.WriteLine();
                        Console.WriteLine("- Para primeiro periodo dígite [1]");
                        Console.WriteLine("- Para segundo periodo dígite [2]");
                        Console.WriteLine("- Para terceiro periodo dígite [3]");
                        Console.Write("- Periodo...: ");
                        periodo = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        do
                        {
                            if (periodo == 1)
                            {
                                do
                                {
                                    Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                                    primeiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                } while (primeiroPeriodo < 14);
                                do
                                {
                                    Console.WriteLine("- Agora informe os outros dois periodos. Nenhum deles pode ser menor que 5 dias.");
                                    Console.WriteLine();
                                    Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                                    segundoPeriodo = int.Parse(Console.ReadLine());
                                    Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
                                    terceiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("--- ATENÇÃO!");
                                        Console.WriteLine($"- Os dias gozados do funcionário não podem exceder ou ser menor que os {ferias} das férias.");
                                    }
                                    Console.WriteLine();
                                } while (!(segundoPeriodo >= 5 && terceiroPeriodo >= 5 && primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias));
                            }
                            else if (periodo == 2)
                            {
                                do
                                {
                                    Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                                    segundoPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                } while (segundoPeriodo < 14);
                                do
                                {
                                    Console.WriteLine("- Agora informe os outros dois periodos. Nenhum deles pode ser menor que 5 dias.");
                                    Console.WriteLine();
                                    Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                                    primeiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
                                    terceiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("--- ATENÇÃO!");
                                        Console.WriteLine($"- Os dias gozados do funcionário não podem exceder ou ser menor que os {ferias} das férias.");
                                    }
                                    Console.WriteLine();
                                } while (!(primeiroPeriodo >= 5 && terceiroPeriodo >= 5 && primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias));

                            }
                            else if (periodo == 3)
                            {
                                do
                                {
                                    Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
                                    terceiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                } while (terceiroPeriodo < 14);
                                do
                                {
                                    Console.WriteLine("- Agora informe os outros dois periodos. Nenhum deles pode ser menor que 5 dias.");
                                    Console.WriteLine();
                                    Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
                                    primeiroPeriodo = int.Parse(Console.ReadLine());
                                    Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
                                    segundoPeriodo = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias)
                                    {

                                    }
                                    else
                                    {
                                        Console.WriteLine("--- ATENÇÃO!");
                                        Console.WriteLine($"- Os dias gozados do funcionário não podem exceder ou ser menor que os {ferias} das férias.");
                                    }
                                    Console.WriteLine();
                                } while (!(primeiroPeriodo >= 5 && segundoPeriodo >= 5 && primeiroPeriodo + segundoPeriodo + terceiroPeriodo == ferias));

                            }
                            else
                            {
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                            }
                        } while (periodo != 1 && periodo != 2 && periodo != 3);
                        Console.WriteLine();

                        Console.WriteLine("- Informe o mes do primeiro periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        primeiroMes = Console.ReadLine();
                        Console.WriteLine("- Informe o mes do segundo periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        segundoMes = Console.ReadLine();
                        Console.WriteLine("- Informe o mes do segundo periodo que o funcionario solicitou as férias: ");
                        Console.Write("- Mês...: ");
                        terceiroMes = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                        Console.WriteLine("- Dígite qualquer coisa para continuar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                    }
                    break;

                default:
                    Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                    break;
            }
        }

        public double OpcaoDeFerias()
        {
            //Aqui eu vou mostrar ao usuario as opções de férias que ele possui
            double ferias = 0;
            int escolha;

            do
            {
                Console.WriteLine("- Selecione o modelo de férias que o funcionário solicitou.");
                Console.WriteLine();
                Console.WriteLine("- Para periodo completo dígite [1]");
                Console.WriteLine("- Para 2 periodos dígite [2]");
                Console.WriteLine("- Para 3 periodos dígite [3]");
                Console.WriteLine("- Para a venda das férias dígite [4]");
                Console.Write("- Escolha...: ");
                escolha = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("- O funcionário solicitou as férias por completo");
                        ferias = CalcularPeriodoCompletoDeDeFerias();
                        break;

                    case 2:
                        Console.WriteLine("- O fucnionário solicitou as férias em 2 periodos");
                        ferias = CalcularFeriasEmDoisPeriodos();
                        break;

                    case 3:
                        Console.WriteLine("- O fucnionário solicitou as férias em 3 periodos");
                        ferias = CalcularFeriasEmTresPeriodos();
                        break;

                    case 4:
                        Console.WriteLine("- O funcionário solicitou a venda das férias");
                        ferias = CalcularVendaDasFerias();
                        break;

                    default:
                        Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                        Console.WriteLine("- Dígite qualquer coisa para continuar.");
                        Console.ReadKey();
                        Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                        Console.WriteLine();
                        break;
                }
            } while (escolha != 1 && escolha != 2 && escolha != 3);

            LiquidoDeFerias = ferias;
            return DiasGozados;
        }

        public double CalcularPeriodoCompletoDeDeFerias()
        {
            // Depois vou fazer este metodo buscar os valores de INSS e IRRF ja calculados para serem utilizados aqui.
            double salarioBase, umTercoSalarioBase, salarioBrutoFerias, inss, irrf, pensao = 300, dependente = 400, salarioLiquidoFerias;

            // Aqui eu vou perguntar se ele vendeu as ferias e chamar o método de calculo de venda das férias.
            Console.WriteLine("- Terceiro passo para calcular as férias:");
            Console.WriteLine();

            Console.Write("- Informe o salário base do funcionario: R$ ");
            salarioBase = double.Parse(Console.ReadLine());

            umTercoSalarioBase = salarioBase / 3;
            salarioBrutoFerias = salarioBase + umTercoSalarioBase;
            BrutoDeFerias = salarioBrutoFerias;
            DiasGozados = 30;
            Console.WriteLine();

            Console.WriteLine($"- O salario bruto das férias é de: R$ {salarioBrutoFerias:f2}");
            Console.WriteLine();

            inss = FolhaDePagamento.FormulaDoInss(salarioBrutoFerias);
            InssFerias = inss;
            irrf = FolhaDePagamento.FormulaDoIrrf(salarioBrutoFerias, inss, pensao, dependente);
            IrrfFerias = irrf;
            salarioLiquidoFerias = salarioBrutoFerias - inss - irrf;
            Console.WriteLine();

            Console.WriteLine($"- O valor das férias que o funcionario ira receber é de: R$ {salarioLiquidoFerias:f2}");
            return salarioLiquidoFerias;
        }
        
        public double CalcularFeriasEmDoisPeriodos()
        {
            double salarioBase, umTercoValorFerias, salarioBrutoFerias, inss, irrf, pensao = 300, dependente = 400, valorFerias, diaria, salarioLiquidoFerias;
            int dias;

            // Vou precisar puxar do banco qual é o periodo que esta sendo calculado e qual o usuario ja retirou. Tambem preciso colocar um limite para 30 dias de férias.
            // Aqui eu vou perguntar se ele vendeu as ferias e chamar o método de calculo de venda das férias.
            Console.WriteLine("- Terceiro passo para calcular as férias:");
            Console.WriteLine();

            //aqui eu vou puxar esta informação do banco de dados.
            Console.Write("- Quantos dias o funcionario solicitou de férias: ");
            dias = int.Parse(Console.ReadLine());

            Console.Write("- Informe o salário base do funcionario: R$ ");
            salarioBase = double.Parse(Console.ReadLine());

            diaria = salarioBase / 30;
            valorFerias = (double) dias * diaria;
            umTercoValorFerias = valorFerias / 3;
            salarioBrutoFerias = valorFerias + umTercoValorFerias;
            BrutoDeFerias = salarioBrutoFerias;
            Console.WriteLine();

            Console.WriteLine($"- O salario bruto das férias é de: R$ {salarioBrutoFerias:f2}");
            Console.WriteLine();

            inss = FolhaDePagamento.FormulaDoInss(salarioBrutoFerias);
            InssFerias = inss;
            irrf = FolhaDePagamento.FormulaDoIrrf(salarioBrutoFerias, inss, pensao, dependente);
            IrrfFerias = irrf;
            salarioLiquidoFerias = salarioBrutoFerias - inss - irrf;
            Console.WriteLine();

            Console.WriteLine($"- O valor das férias que o funcionario ira receber é de: R$ {salarioLiquidoFerias:f2}");
            return salarioLiquidoFerias;
        }
        
        public double CalcularFeriasEmTresPeriodos()
        {
            // Ese método esta imcompleto preciso terminar
            double salarioBase, umTercoValorFerias, salarioBrutoFerias, inss, irrf, pensao = 300, dependente = 400, valorFerias, diaria, salarioLiquidoFerias;
            int dias, primeiroPeriodo, segundoPerido, terceiroPeriodo;
            // Aqui eu vou perguntar se ele vendeu as ferias e chamar o método de calculo de venda das férias.
            Console.Write("- Quantos dias o fucionario solicitou para o 1º periodo: ");
            primeiroPeriodo = int.Parse(Console.ReadLine());
            Console.Write("- Quantos dias o fucionario solicitou para o 2º periodo: ");
            segundoPerido = int.Parse(Console.ReadLine());
            Console.Write("- Quantos dias o fucionario solicitou para o 3º periodo: ");
            terceiroPeriodo = int.Parse(Console.ReadLine());

            Console.Write("- Quantos dias o funcionario solicitou de férias: ");
            dias = int.Parse(Console.ReadLine());

            Console.Write("- Informe o salário base do funcionario: R$ ");
            salarioBase = double.Parse(Console.ReadLine());

            diaria = salarioBase / 30;
            valorFerias = (double)dias * diaria;
            umTercoValorFerias = valorFerias / 3;
            salarioBrutoFerias = valorFerias + umTercoValorFerias;
            BrutoDeFerias = salarioBrutoFerias;
            Console.WriteLine();

            Console.WriteLine($"- O salario bruto das férias é de: R$ {salarioBrutoFerias:f2}");
            Console.WriteLine();

            inss = FolhaDePagamento.FormulaDoInss(salarioBrutoFerias);
            InssFerias = inss;
            irrf = FolhaDePagamento.FormulaDoIrrf(salarioBrutoFerias, inss, pensao, dependente);
            IrrfFerias = irrf;
            salarioLiquidoFerias = salarioBrutoFerias - inss - irrf;
            Console.WriteLine();

            Console.WriteLine($"- O valor das férias que o funcionario ira receber é de: R$ {salarioLiquidoFerias:f2}");
            return salarioLiquidoFerias;
        }
        
        public double CalcularVendaDasFerias()
        {
            // Aqui eu vou calcular o valor dos dias vendidos das ferias recebendo a quantidade de dias por parametros e retornando o valor da venda.
            // Preciso colocar um limite para 30 dias de férias
            double salarioBase, diaria, valorFerias, umTercoValorFerias, abonoPecuniario, umTercoAbonoPecuniaro, salarioBrutoFerias, baseDoInssIrrf, inss, irrf, pensao = 300, dependente = 400, salarioLiquidoFerias;
            int diasVendidos, restante;

            Console.WriteLine("- Venda das férias.");
            Console.WriteLine();
            Console.Write("- Informe quantos dias o funcionario deseja vender. Máximo de 10 dias permitidos: ");
            diasVendidos = int.Parse(Console.ReadLine());
            DiasVendidos = diasVendidos;
            Console.Write("- Informe o salário base do funcionario: R$ ");
            salarioBase = double.Parse(Console.ReadLine());
            Console.WriteLine();

            restante = 30 - diasVendidos;
            DiasGozados = restante;

            diaria = salarioBase / 30; // Aqui eu vou descobri qual o valor que o funcionario ganha por dia.
            valorFerias = (double) restante * diaria; // Aqui eu vou calcular quanto ele vai receber de férias .
            umTercoValorFerias = valorFerias / 3; // Aqui eu calculo 1/3 do valor que ele vai receber das férias.

            abonoPecuniario = (double) diasVendidos * diaria; // Aqui eu calculo o valor que ele vai receber pelos dias vendidos.
            AbonoPecuniario = abonoPecuniario;

            umTercoAbonoPecuniaro = abonoPecuniario / 3; // Aqui eu calculo 1/3 do valor da venda das férias
            UmTercoDoAbonoPecuniario = umTercoAbonoPecuniaro;

            salarioBrutoFerias = valorFerias + umTercoValorFerias + abonoPecuniario + umTercoAbonoPecuniaro; // Aqui é o valor bruto que ele tem para receber
            BrutoDeFerias = salarioBrutoFerias;
            Console.WriteLine();

            Console.WriteLine($"- O salario bruto das férias é de: R$ {salarioBrutoFerias:f2}");
            Console.WriteLine();

            baseDoInssIrrf = valorFerias + umTercoValorFerias; // Aqui eu calculo o valor sobre o qual vai ser descontado o INSS e IRRF pois ele não é calculado sobre o abono pecuniario nem o valor de 1/3 do mesmo.

            inss = this.FolhaDePagamento.FormulaDoInss(baseDoInssIrrf);
            InssFerias = inss;
            irrf = this.FolhaDePagamento.FormulaDoIrrf(salarioBrutoFerias, inss, pensao, dependente);
            IrrfFerias = irrf;

            salarioLiquidoFerias = salarioBrutoFerias - inss - irrf;
            Console.WriteLine();

            Console.WriteLine($"- Valor dos 20 dias de férias: R$ {valorFerias:f2}");
            Console.WriteLine($"- Valor de 1/3 dos 20 dias: R$ {umTercoValorFerias:f2}");
            Console.WriteLine();
            Console.WriteLine($"- Valor da venda dos dias: R$ {abonoPecuniario:f2}");
            Console.WriteLine($"- Valor de 1/3 do abono pecuniario: R$ {umTercoAbonoPecuniaro:f2}");
            Console.WriteLine();
            Console.WriteLine($"- Desconto do INSS: R$ {inss:f2}");
            Console.WriteLine($"- Desconto do IRRF: R$ {irrf:f2}");
            Console.WriteLine();
            Console.WriteLine($"- Valor líquido a reber de férias: R$ {salarioLiquidoFerias:f2}");
            return salarioLiquidoFerias;
        }

        public void GerarReciboDeFerias()
        {
            // Aqui vai ser um método a parte apenas para gerar a folha do recibo de férias com as informações que o funcionario ira assinar.
        }
    }
}
