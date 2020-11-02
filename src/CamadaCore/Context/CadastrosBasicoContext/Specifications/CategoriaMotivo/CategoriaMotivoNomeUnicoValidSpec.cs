using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.SharedContext.Specifications;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Specifications.CategoriaMotivos
{
    class CategoriaMotivoNomeUnicoValidSpec<T> : CompositeSpecification<T>
    {
        private readonly IRepositorioCategoriaMotivo _repositorioCategoriaMotivo;

        public CategoriaMotivoNomeUnicoValidSpec(IRepositorioCategoriaMotivo repositorioCategoriaMotivo)
        {
            _repositorioCategoriaMotivo = repositorioCategoriaMotivo;
        }

        public  override bool IsSatisfiedBy(T candidate)
        {
            var CategoriaMotivo = candidate as CategoriaMotivo;

            var retorno = Task.Run(() => _repositorioCategoriaMotivo.RetornarPorNome(CategoriaMotivo.Nome)).Result;

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
