namespace CamadaCore.Context.SharedContext.Specifications
{
    public abstract class Entity
    {
        protected CompositeSpecification<object> ValidSpecification = null;

        public bool IsValid()
        {
            return ValidSpecification?.IsSatisfiedBy(this) ?? true;
        }
    }
}
