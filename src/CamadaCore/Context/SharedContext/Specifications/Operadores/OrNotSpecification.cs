﻿using CamadaCore.Context.SharedContext.Interfaces.Specifications;

namespace CamadaCore.Context.SharedContext.Specifications.Operadores
{
    public class OrNotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrNotSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            (_leftSpecification.IsSatisfiedBy(candidate) ||
             _rightSpecification.IsSatisfiedBy(candidate)) != true;
    }
}
