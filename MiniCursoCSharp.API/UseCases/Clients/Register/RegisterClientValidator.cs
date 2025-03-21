using FluentValidation;
using MIniCursoCSharp.Communication.Requests;

namespace MiniCursoCSharp.API.UseCases.Clients.Register
{
    public class RegisterClientValidator : AbstractValidator<RequestClientJson>
    {
        public RegisterClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("O nome do cliente é obrigatório");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O e-mail informado não é válido");
        }
    }
}
