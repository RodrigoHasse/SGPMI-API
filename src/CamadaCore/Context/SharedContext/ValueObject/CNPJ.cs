using CamadaCore.Context.SharedContext.Validacoes;
using System;

namespace CamadaCoreCamadaCore.Context.SharedContext.ValueObject
{
    public class CNPJ
    {
        public string Numero { get; private set; }
        public const int CNPJMaxLength = 18;

        public CNPJ(string numero)
        {
            Numero = numero;
            Validar(numero);
        }

        protected CNPJ()
        {
        }

        private void Validar(string cnpj)
        {
            if (!Helpers.ValidarCnpj(cnpj))
                throw new Exception("CNPJ Inválido!");
        }
    }
}
