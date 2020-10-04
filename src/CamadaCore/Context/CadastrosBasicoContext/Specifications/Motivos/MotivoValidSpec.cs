using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Motivos;
using CamadaCore.Context.CadastrosBasicoContext.Models.Motivos;
using CamadaCore.Context.SharedContext.Specifications;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Specifications.Motivos
{
    class MotivoValidSpec<T> : CenarioSpecification<T>
    {
        private readonly IRepositorioMotivo _repositorioMotivo;

        public MotivoValidSpec(IRepositorioMotivo repositorioMotivo)
        {
            _repositorioMotivo = repositorioMotivo;
        }
        public override async Task<ResultSpecification> ValidateRules(T candidate)
        {
            return await ValidateRulesWrapper(async specificationResult =>
            {
                var motivo = candidate as Motivo;

                var cidadeCodigoIbgeSpec= new MotivoNomeUnicoValidSpec<Motivo>(_repositorioMotivo);
                if (!cidadeCodigoIbgeSpec.IsSatisfiedBy(motivo))
                    specificationResult.Add("Já existe um motivo com esse nome cadastrado, Verifique");
            });
        }
    }
}
