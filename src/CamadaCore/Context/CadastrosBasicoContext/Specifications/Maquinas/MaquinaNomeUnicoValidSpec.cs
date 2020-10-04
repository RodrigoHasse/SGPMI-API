using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.SharedContext.Specifications;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Specifications.Maquinas
{
    class MaquinaNomeUnicoValidSpec<T> : CompositeSpecification<T>
    {
        private readonly IRepositorioMaquina _repositorioMaquina;

        public MaquinaNomeUnicoValidSpec(IRepositorioMaquina repositorioMaquina)
        {
            _repositorioMaquina = repositorioMaquina;
        }

        public  override bool IsSatisfiedBy(T candidate)
        {
            var Maquina = candidate as Maquina;

            var retorno = Task.Run(() => _repositorioMaquina.RetornarPorNome(Maquina.Nome)).Result;

            var resultado = retorno.Match
                (
                some: x => x,
                none: () => {
                    return default; 
                });

            return resultado != null;
        }
    }
}
