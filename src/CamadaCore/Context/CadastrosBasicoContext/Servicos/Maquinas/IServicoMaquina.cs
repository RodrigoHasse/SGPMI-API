using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.SharedContext.Servicos.Basico;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Servicos.Maquinas
{
    public interface IServicoMaquina: IServicoBasico<Maquina>
    {
        Task AlterarStatusMaquina(Maquina maquina);
    }
}
