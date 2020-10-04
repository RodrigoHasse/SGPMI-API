using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.SharedContext.Excecoes
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
