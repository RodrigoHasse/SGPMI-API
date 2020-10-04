using CamadaCore.Context.CadastrosBasicoContext.Interfaces.Entity.Maquinas;
using CamadaCore.Context.CadastrosBasicoContext.Models.Maquinas;
using CamadaCore.Context.SharedContext.Specifications;
using System.Threading.Tasks;

namespace CamadaCore.Context.CadastrosBasicoContext.Specifications.Maquinas
{
    class MaquinaValidSpec<T> : CenarioSpecification<T>
    {
        private readonly IRepositorioMaquina _repositorioMaquina;

        public MaquinaValidSpec(IRepositorioMaquina repositorioMaquina)
        {
            _repositorioMaquina = repositorioMaquina;
        }
        public override async Task<ResultSpecification> ValidateRules(T candidate)
        {
            return await ValidateRulesWrapper(async specificationResult =>
            {
                var maquina = candidate as Maquina;

                var cidadeCodigoIbgeSpec= new MaquinaNomeUnicoValidSpec<Maquina>(_repositorioMaquina);
                if (!cidadeCodigoIbgeSpec.IsSatisfiedBy(maquina))
                    specificationResult.Add("Já existe uma máquina com esse nome cadastrada, Verifique");
            });
        }
    }
}
