using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Paradas;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using System.Collections.Generic;

namespace CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas
{
    public class MaquinaOutputModel: OutputBasico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ligada { get; set; }

        public List<ParadaOutputModel> Paradas { get; set; }
    }    
}
