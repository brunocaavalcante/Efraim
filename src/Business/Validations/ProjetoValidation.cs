using Business.Core.Validations;
using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class ProjetoValidation : BaseValidator<Projeto>
    {
        public ProjetoValidation()
        {
            When(x => x == null, () =>
            {
                RuleFor(m => m == null).NotNull().WithMessage("Entidade não pode ser nula");
            });

            RuleFor(m => m.DataCadastro)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(m => m.DataInicio)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(m => m.DataFim)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(m => m.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");
        }
    }
}
