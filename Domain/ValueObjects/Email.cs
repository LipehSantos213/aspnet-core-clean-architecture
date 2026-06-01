using api_csharp.Domain.Exception;

namespace api_csharp.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
                throw new DomainException("Formato de e-mail inválido.");

            Address = address;
        }
    }
}
