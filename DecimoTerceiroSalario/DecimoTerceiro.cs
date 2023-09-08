using FolhaDePagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimoTerceiroSalario
{
    public class DecimoTerceiro
    {
        FolhaPG folhaPG = new FolhaPG();

        private double ValorDoDecimoTerceiro { get; set; }

        // Coloquei comentario em todas as linhas que estavam retornando erro quando fiz a criação desta nova classe para pode continuar com o desenvolvimento
        // Da classe FolhaDePagamento, quando termina-la vou arrumar essa e as linhas que estão sendo afetadas por erro terei q fazelas receber o valor
        // Necessario para realizxar a fomula através de parametros.
        // ou seja, VOU PRECISAR REFATORAR O CODIGO!!

        private double ContabilizarDecimoTerceiroBruto()
        {
            double decimoTerceiroBruto;
           // double salarioBruto = SalarioBase; O atributo SalarioBase é privado da classe FolhaPG, então vou alterar o código para o ususario digitar na classe DEcimoTerceiro.
            int mesesTrabalhados;
            double salarioBruto = 0; //Declarei essa variavel só para não dar erro no projeto por enquanto.

            Console.Write("- Informe quantos meses do ano o funcionário trabalhou: ");
            mesesTrabalhados = int.Parse(Console.ReadLine());
            decimoTerceiroBruto = (salarioBruto / 12) * (double)mesesTrabalhados;
            return decimoTerceiroBruto;
        }

        public double ContabilizarDecimoTerceiro()
        {
            int tipoDePagamento;
            double valorDoPagamento = 0;

            do
            {
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
            } while (tipoDePagamento != 1 && tipoDePagamento != 2 && tipoDePagamento != 3);
            ValorDoDecimoTerceiro = valorDoPagamento;
            return ValorDoDecimoTerceiro;
        }

        private double CalcularPrimeiraParcelaDoDecimoTerceiro()
        {
            double salarioBrutoDoDecimoTerceiro = ContabilizarDecimoTerceiroBruto();
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
           // double pensao = DescontoTotalDePensao;
          //  double dependente = DescontoTotalDeDependentes;

            salarioBrutoDoDecimoTerceiro = ContabilizarDecimoTerceiroBruto();
            Console.WriteLine();
          //  inss = FormulaDoInss(salarioBrutoDoDecimoTerceiro);
           // irrf = FormulaDoIrrf(salarioBrutoDoDecimoTerceiro, inss, pensao, dependente);
          //  valorDaSegundaParcelaDoDecimo = (salarioBrutoDoDecimoTerceiro / 2) - inss - irrf;
            Console.WriteLine();
            //  return valorDaSegundaParcelaDoDecimo;
            return salarioBrutoDoDecimoTerceiro; // Declarei ess return só pra o sistema não dar mais erro
        }

        private double CalcularPagamentoUnicoDoDecimoTerceiro()
        {
            double salarioBrutoDoDecimoTerceiro, pagamentoUnicoDoDecimoTerceiro, inss, irrf;
           // double pensao = DescontoTotalDePensao;
           // double dependente = DescontoTotalDeDependentes;

            salarioBrutoDoDecimoTerceiro = ContabilizarDecimoTerceiroBruto();
            Console.WriteLine();
          //  inss = FormulaDoInss(salarioBrutoDoDecimoTerceiro);
          //  irrf = FormulaDoIrrf(salarioBrutoDoDecimoTerceiro, inss, pensao, dependente);
           // pagamentoUnicoDoDecimoTerceiro = salarioBrutoDoDecimoTerceiro - inss - irrf;
            Console.WriteLine();
            //   return pagamentoUnicoDoDecimoTerceiro;
            return salarioBrutoDoDecimoTerceiro; // Declarei ess return só pra o sistema não dar mais erro
        }
    }
}
