using CamadaCore.Context.SharedContext.Interfaces.Specifications;

namespace CamadaCore.Context.SharedContext.Specifications.Operadores
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _notSpecification;

        public NotSpecification(ISpecification<T> not)
        {
            _notSpecification = not;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            !_notSpecification.IsSatisfiedBy(candidate);
    }
}
