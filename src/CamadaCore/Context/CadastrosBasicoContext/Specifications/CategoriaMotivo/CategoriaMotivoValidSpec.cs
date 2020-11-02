using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.CategoriaMotivos;
using CamadaCore.Context.CadastrosBasicoContext.Specifications.CategoriaMotivos;
using CamadaCore.Context.SharedContext.Specifications;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Specifications.CategoriaMotivos
{
    class CategoriaMotivoValidSpec<T> : CenarioSpecification<T>
    {
        private readonly IRepositorioCategoriaMotivo _repositorioCategoriaMotivo;

        public CategoriaMotivoValidSpec(IRepositorioCategoriaMotivo repositorioCategoriaMotivo)
        {
            _repositorioCategoriaMotivo = repositorioCategoriaMotivo;
        }
        public override async Task<ResultSpecification> ValidateRules(T candidate)
        {
            return await ValidateRulesWrapper(async specificationResult =>
            {
                var categoriaMotivo = candidate as CategoriaMotivo;

                var cidadeCodigoIbgeSpec= new CategoriaMotivoNomeUnicoValidSpec<CategoriaMotivo>(_repositorioCategoriaMotivo);
                if (!cidadeCodigoIbgeSpec.IsSatisfiedBy(categoriaMotivo))
                    specificationResult.Add("Já existe uma categoria com esse nome cadastrado, Verifique");
            });
        }
    }
}
