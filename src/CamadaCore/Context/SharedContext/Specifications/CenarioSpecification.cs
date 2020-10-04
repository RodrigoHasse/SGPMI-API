using System;
using System.Threading.Tasks;

namespace CamadaCore.Context.SharedContext.Specifications
{
    public abstract class CenarioSpecification<T>: CompositeSpecification<T>
    {       
        public abstract Task<ResultSpecification> ValidateRules(T candidate);

        protected static async Task<ResultSpecification> ValidateRulesWrapper(Func<ResultSpecification, Task> action)
        {
            var specificationResult = ResultSpecification.Create();
            await action?.Invoke(specificationResult);
            return specificationResult;
        }
    }
}
