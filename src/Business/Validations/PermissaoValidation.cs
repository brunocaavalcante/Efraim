using Business.Core.Validations;
using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class PermissaoValidation : BaseValidator<Perfil>
    {
        public PermissaoValidation()
        {
            RuleFor(m => m.DataCadastro)
               .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
               .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(m => m.Funcionalidade)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(m => m.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleFor(m => m.Permissoes)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");
        }
    }
}
