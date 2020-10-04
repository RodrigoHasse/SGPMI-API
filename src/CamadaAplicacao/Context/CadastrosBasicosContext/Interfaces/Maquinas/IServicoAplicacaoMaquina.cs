using CamadaAplicacao.Context.SharedContext.Interfaces;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Inputs.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.ViewModels.Outputs.Maquinas;
using CamadaCore.Context.SharedContext.ViewModels.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamadaAplicacao.Context.CadastrosBasicosContext.Interfaces.Maquinas
{
    public interface IServicoAplicacaoMaquina : IServicoAplicacaoBasico<Maquina, MaquinaInputModel, MaquinaOutputModel, FiltroMaquinasInputModel>
    {
        Task AlterarStatusMaquina(AlterarStatusMaquinaInputModel statusMaquina);
    }
}
