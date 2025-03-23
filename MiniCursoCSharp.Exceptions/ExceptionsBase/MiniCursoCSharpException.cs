namespace MiniCursoCSharp.Exceptions.ExceptionsBase
{
    public abstract class MiniCursoCSharpException(string message) : SystemException(message)
    {
        public abstract List<string> GetErrors();
    }
}
