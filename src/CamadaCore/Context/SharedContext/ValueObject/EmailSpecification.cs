using CamadaCore.Context.SharedContext.Specifications.Emails;

namespace CamadaCoreCamadaCore.Context.SharedContext.ValueObject
{
    class EmailSpecification : ValueObject
    {
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 255;

        public EmailSpecification(string address)
        {
            Address = address;
            ValidSpecification = new EmailValidSpecification<object>();
        }

        public string Address { get; }

        public override string ToString() => Address;
    }
}
