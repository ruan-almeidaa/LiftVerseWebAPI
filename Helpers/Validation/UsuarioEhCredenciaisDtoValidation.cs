using Entities.Dtos.Input.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Validation
{
    public class UsuarioEhCredenciaisDtoValidation : AbstractValidator<UsuarioEhCredenciaisDto>
    {
        public UsuarioEhCredenciaisDtoValidation()
        {
            RuleFor(u => u.Nickname)
                .NotEmpty().WithMessage("Campo obrigatório")
                .Length(4, 50).WithMessage("O nickname deve ter entre 2 e 50 caracteres.");

            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Campo obrigatório")
                .Length(4, 50).WithMessage("O nome deve ter entre 2 e 50 caracteres.")
                .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("O nome deve conter apenas letras e espaços.");

            RuleFor(u => u.Sobrenome)
                .NotEmpty().WithMessage("Campo obrigatório")
                .Length(4, 50).WithMessage("O sobrenome deve ter entre 2 e 50 caracteres.")
                .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("O sobrenome deve conter apenas letras e espaços.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Campo obrigatório")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Campo obrigatório")
                .Length(10, 50).WithMessage("A senha deve ter entre 10 e 50 caracteres.");
        }
    }
}
