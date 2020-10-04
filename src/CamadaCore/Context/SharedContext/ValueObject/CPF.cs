using CamadaCore.Context.SharedContext.Validacoes;
using System;

namespace CamadaCoreCamadaCore.Context.SharedContext.ValueObject
{
    public class CPF
    {
        public string Numero { get; private set; }
        public const int CPFMaxLength = 14;

        public CPF(string numero)
        {
            Numero = numero;
        }

        private void Validar(string cpf)
        {
            if (!Helpers.ValidarCPF(cpf))
                throw new Exception("CPF Inválido");
        }
    }
}
