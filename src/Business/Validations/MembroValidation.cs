using Business.Models;
using Business.Core.Validations.Documentos;
using FluentValidation;
using Business.Core.Validations;

namespace Business.Validations
{
    public class MembroValidation : BaseValidator<Membro>
    {        
        public MembroValidation()
        {
            When(x => x == null, () => {
               RuleFor(m => m == null).NotNull().WithMessage("Entidade membro não pode ser nula"); 
            });

            When(x => x != null, () => {
                RuleFor(m => m.CPF.Length).Equal(CPFValidation.TamanhoCpf)
                    .NotNull().NotEmpty()
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(m => CPFValidation.Validar(m.CPF)).Equal(true)
                    .NotNull().NotEmpty()
                    .WithMessage("O documento fornecido é inválido.");


                RuleFor(m => m.DataCadastro)
                    .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                    .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");

                RuleFor(m => m.DataNascimento)
                    .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                    .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");   

                RuleFor(m => m.Nome)
                    .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                    .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");        

                RuleFor(m => m.Telefone)
                    .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido.")
                    .NotNull().WithMessage("O campo {PropertyName} deve ser fornecido.");  
             });  
        }
    }
}