using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas
{
    public class AlterarStatusMaquinaInputModel 
    {
        public int MaquinaId { get; set; }
        public bool Ligada { get; set; }
    }
}
