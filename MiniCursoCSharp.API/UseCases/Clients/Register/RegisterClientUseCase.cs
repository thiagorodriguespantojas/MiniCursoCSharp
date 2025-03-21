using MIniCursoCSharp.Communication.Requests;
using MIniCursoCSharp.Communication.Responses;

namespace MiniCursoCSharp.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid == false)
            {
                throw new DivideByZeroException("Erro ao validar os dados do cliente");
            }

            // CONTINUA A REGRA DE NEGÓCIO

            return new ResponseClientJson();
        }
    }
}
