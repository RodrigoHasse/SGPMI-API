using System.Collections.Generic;
using System.Linq;

namespace CamadaCore.Context.SharedContext.Specifications
{
    public class ResultSpecification
    {
        private readonly IList<string> errors;

        private ResultSpecification() { errors = new List<string>(); }

        public ResultSpecification Add(string errorMessage)
        {
            errors.Add(errorMessage);
            return this;
        }

        public bool IsSatisfied() => !errors.Any();

        public IEnumerable<string> Errors => errors;

        public static ResultSpecification Create() => new ResultSpecification();
    }
}
