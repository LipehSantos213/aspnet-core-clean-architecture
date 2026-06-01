namespace api_csharp.Domain.Exception
{
    public class DomainException : FormatException
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
