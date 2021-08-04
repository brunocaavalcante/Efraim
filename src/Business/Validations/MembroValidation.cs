using Business.Models;
using Business.Core.Validations.Documentos;
using FluentValidation;

namespace Business.Validations
{
    public class MembroValidation : AbstractValidator<Membro>
    {
        public MembroValidation()
        {
            RuleFor(m => m.CPF.Length).Equal(CPFValidation.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(m => CPFValidation.Validar(m.CPF)).Equal(true)
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
        }
    }
}