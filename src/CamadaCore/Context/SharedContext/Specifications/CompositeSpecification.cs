using CamadaCore.Context.SharedContext.Interfaces.Specifications;
using CamadaCore.Context.SharedContext.Specifications.Operadores;
using CamadaCore.Operadores.Specifications;

namespace CamadaCore.Context.SharedContext.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public virtual bool IsSatisfiedBy(T candidate) => false;
        public ISpecification<T> And(ISpecification<T> specification) =>
            new AndSpecification<T>(this, specification);
        public ISpecification<T> AndNot(ISpecification<T> specification) =>
            new AndNotSpecification<T>(this, specification);
        public ISpecification<T> Or(ISpecification<T> specification) =>
            new OrSpecification<T>(this, specification);
        public ISpecification<T> OrNot(ISpecification<T> specification) =>
            new OrNotSpecification<T>(this, specification);
        public ISpecification<T> Not(ISpecification<T> specification) =>
            new NotSpecification<T>(specification);
    }
}
