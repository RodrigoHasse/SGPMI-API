using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.SharedContext.Specifications;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Specifications.Motivos
{
    class MotivoNomeUnicoValidSpec<T> : CompositeSpecification<T>
    {
        private readonly IRepositorioMotivo _repositorioMotivo;

        public MotivoNomeUnicoValidSpec(IRepositorioMotivo repositorioMotivo)
        {
            _repositorioMotivo = repositorioMotivo;
        }

        public  override bool IsSatisfiedBy(T candidate)
        {
            var Motivo = candidate as Motivo;

            var retorno = Task.Run(() => _repositorioMotivo.RetornarPorNome(Motivo.Nome)).Result;

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
