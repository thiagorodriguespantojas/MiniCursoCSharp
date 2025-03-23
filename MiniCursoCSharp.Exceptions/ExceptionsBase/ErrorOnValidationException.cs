using System.Runtime.Serialization;

namespace MiniCursoCSharp.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException(string message) : MiniCursoCSharpException(message), ISerializable
    {
        private readonly List<string> _error = [];

        public override List<string> GetErrors()
        {
            return _error;
        }
    }
}
