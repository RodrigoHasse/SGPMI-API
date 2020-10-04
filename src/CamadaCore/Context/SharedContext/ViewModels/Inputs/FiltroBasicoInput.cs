using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.SharedContext.ViewModels.Inputs
{
    public abstract class FiltroBasicoInput 
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
    }
}
