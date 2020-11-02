using CamadaCore.Context.SharedContext.ViewModels.Inputs;
using System;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Paradas
{
    public class FiltroParadasInputModel: FiltroBasicoInput
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
