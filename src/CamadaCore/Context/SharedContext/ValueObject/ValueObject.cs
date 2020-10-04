using CamadaCore.Context.SharedContext.Specifications;

namespace CamadaCoreCamadaCore.Context.SharedContext.ValueObject
{
    public abstract class ValueObject
    {
        protected CompositeSpecification<object> ValidSpecification = null;

        public bool IsValid()
        {
            return ValidSpecification?.IsSatisfiedBy(this) ?? true;
        }
    }
}
