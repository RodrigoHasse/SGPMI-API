using CamadaCoreCamadaCore.Context.SharedContext.ValueObject;
using System.Text.RegularExpressions;

namespace CamadaCore.Context.SharedContext.Specifications.Emails
{
    public class EmailValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;

        public EmailValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var email = candidate as EmailSpecification;

            if (string.IsNullOrEmpty(email?.Address) && !_required)
                return true;

            if ((email?.Address ?? "").Length < EmailSpecification.AddressMinLength)
                return false;

            if ((email?.Address ?? "").Length > EmailSpecification.AddressMaxLength)
                return false;

            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email?.Address ?? "", pattern);
        }
    }
}
