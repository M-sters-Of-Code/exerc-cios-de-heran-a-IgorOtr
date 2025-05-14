using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class ContaCaixinha : Conta
    {
        public decimal Limite { get; private set; }
        public ContaCaixinha(decimal saldo) : base(saldo)
        {
        }

        public ContaCaixinha(Cliente cliente) : base(cliente)
        {
        }
        public ContaCaixinha(decimal saldo, decimal limite) : base(saldo)
        {
            if (limite < 0)
                throw new ArgumentException("O limite não pode ser negativo.");
            Limite = limite;
        }

        public override void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            if (valor > Saldo + Limite)
                throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
            Saldo -= valor; // Saldo = Saldo - valor;
        }
        public override void Transferir(decimal valor, Conta contaDestino)
        {
            if (valor > Saldo + Limite)
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            base.Transferir(valor, contaDestino);
        }
    }
}
