using System;
using System.Collections.Generic;

namespace BancoDIO
{
    class Program
    {
        static List<Conta> contas = new List<Conta>();
        static void Main(string[] args)
        {
            Console.WriteLine("\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("$$$ Bem-vindo ao Banco DIO! $$$");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            string opcao = Menu();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1": CadastrarConta(); break;
                    case "2": ListarContas(); break;
                    case "3": Depositar(); break;
                    case "4": Sacar(); break;
                    case "5": Transferir(); break;
                    default: Console.WriteLine("\n$$$ Opção inválida $$$"); break;
                }
                opcao = Menu();
            }

            Console.WriteLine("\n$$$ Operação finalizada $$$");
        }

        private static void CadastrarConta()
        {
            Console.WriteLine("\nDigite o nome para a nova conta: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial para a nova conta: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito inicial para a nova conta: ");
            double credito = double.Parse(Console.ReadLine());

            if (String.IsNullOrEmpty(nome))
            {
                Console.WriteLine("\n$$$ Nome inválido $$$");
            }
            else
            {
                if ((saldo < 0.0d) || (credito < 0.0d))
                {
                    Console.WriteLine("\n$$$ Saldo e/ou Crédito inicial não pode ser negativo $$$");
                }
                else
                {
                    Conta novaConta = new Conta(nome, saldo, credito);
                    contas.Add(novaConta);
                }
            }
        }

        private static void ListarContas()
        {
            Console.WriteLine("");

            if (contas.Count == 0) Console.WriteLine("$$$ Nenhuma conta cadastrada $$$");
            else
                for (int i = 0; i <= (contas.Count - 1); i++)
                    Console.WriteLine("Conta: {0}# {1}", i, contas[i]);
        }

        private static void Depositar()
        {
            Console.WriteLine("\nDigite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            if (ValidaConta(numConta))
            {
                Console.WriteLine("Digite o valor: ");
                double valorDep = double.Parse(Console.ReadLine());

                contas[numConta].Deposito(valorDep);
            }
            else Console.WriteLine("\n$$$ Conta inválida $$$");
        }

        private static void Sacar()
        {
            Console.WriteLine("\nDigite o número da conta: ");
            int numConta = int.Parse(Console.ReadLine());

            if (ValidaConta(numConta))
            {
                Console.WriteLine("Digite o valor: ");
                double valorSaq = double.Parse(Console.ReadLine());

                contas[numConta].Saque(valorSaq);
            }
            else Console.WriteLine("\n$$$ Conta inválida $$$");
        }

        private static void Transferir()
        {
            Console.WriteLine("\nDigite o número da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            if (ValidaConta(contaOrigem))
            {
                Console.WriteLine("Digite o número da conta de destino: ");
                int contaDestino = int.Parse(Console.ReadLine());

                if (ValidaConta(contaDestino))
                {
                    Console.WriteLine("Digite o valor: ");
                    double valorTran = double.Parse(Console.ReadLine());

                    contas[contaOrigem].Transferencia(valorTran, contas[contaDestino]);
                }
                else Console.WriteLine("\n$$$ Conta de destino inválida $$$");
            }
            else Console.WriteLine("\n$$$ Conta de origem inválida $$$");
        }

        private static bool ValidaConta(int numConta)
        {
            return ((contas.Count > 0) && (numConta < contas.Count)) ? true : false;
        }

        private static string Menu()
        {
            Console.WriteLine("_________________________________");
            Console.WriteLine("Informe uma das operações abaixo:\n");
            Console.WriteLine("1 - Cadastrar nova conta");
            Console.WriteLine("2 - Consultar contas existentes");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("X - Sair");
            Console.Write("Opção selecionada: ");

            return Console.ReadLine();
        }
    }
}
