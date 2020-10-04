using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas
{
    public class MaquinaInputModel : InputBasico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ligada { get; set; }
    }
}