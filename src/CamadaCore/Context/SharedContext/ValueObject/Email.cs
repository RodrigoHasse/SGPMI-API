using System;

namespace CamadaCoreCamadaCore.Context.SharedContext.ValueObject
{
    public class Email
    {
        public string Endereco { get; private set; }
        public const int EnderecoMaxLength = 200;

        public Email(string endereco)
        {
            Endereco = endereco;

            if (!Validar(endereco))
                throw new Exception("Email Inválido!");
        }

        protected Email()
        {
        }

        private bool Validar(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true;

            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(email, strModelo))
                return true;
            else
                return false;
        }
    }
}
