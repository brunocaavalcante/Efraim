using Business.Models;
using FluentValidation;

namespace Business.Validations
{
    public class DepartamentoValidation : AbstractValidator<Departamento>
    {
        public DepartamentoValidation()
        {
            RuleFor(m => m.DataCadastro)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido."); 

            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

            RuleForEach<Membro>(m => m.Membros)
                .SetValidator(new MembroValidation());

             RuleForEach<Membro>(m => m.Lideres)
                .SetValidator(new MembroValidation());  
        }
    }
}