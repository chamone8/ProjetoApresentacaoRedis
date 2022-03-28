using FluentValidation;
using Projeto.Redis.Domain.Entities;

namespace Projeto.Redis.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Email)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Telefone)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Telefone2)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Rua)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Bairro)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Cep)
                .Length<Cliente>(8, 8)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Cidade)
                .Length<Cliente>(3, 30)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Estado)
                .Length<Cliente>(2, 2)
                .NotEmpty()
                .NotNull();
        }
    }
}