using System;

namespace BancoDIO
{
    class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double CreditoTotal { get; set; }
        private double CreditoRestante { get; set; }

        public Conta(string nome, double saldo, double credito)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.CreditoTotal = credito;
            this.CreditoRestante = credito;
        }

        public void Deposito(double valorDeposito)
        {
            if (this.CreditoRestante < this.CreditoTotal)
            {
                if (valorDeposito > (this.CreditoTotal - this.CreditoRestante)) this.CreditoRestante = this.CreditoTotal;
                else this.CreditoRestante += valorDeposito;
            }

            this.Saldo += valorDeposito;
            Console.WriteLine("\nSaldo atual: " + this.Saldo);
            Console.WriteLine("Crédito restante/total: {0}/{1}", this.CreditoRestante, this.CreditoTotal);
        }

        public void Saque(double valorSaque)
        {
            if (valorSaque <= (this.Saldo + this.CreditoRestante))
            {
                if (valorSaque > this.Saldo) this.CreditoRestante -= (valorSaque - this.Saldo);

                this.Saldo -= valorSaque;
                Console.WriteLine("\nSaldo atual: " + this.Saldo);
                Console.WriteLine("Crédito restante/total: {0}/{1}", this.CreditoRestante, this.CreditoTotal);
            }
            else
            {
                Console.WriteLine("\n$$$ Saldo/Crédito insuficiente $$$");
            }
        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            Console.WriteLine("\nConta origem: ");
            Saque(valorTransferencia);
            
            Console.WriteLine("\nConta destino: ");
            contaDestino.Deposito(valorTransferencia);
        }

        public override string ToString()
        {
            string detalhesConta = "Nome: " + this.Nome;
            detalhesConta += " | Saldo: " + this.Saldo;
            detalhesConta += " | Crédito total: " + this.CreditoTotal;
            detalhesConta += " | Crédito restante: " + this.CreditoRestante;

            return detalhesConta;
        }
    }
}