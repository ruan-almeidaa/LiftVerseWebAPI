using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Validation
{
    public class UsuarioEhCredenciaisDtoValidation : AbstractValidator<UsuarioEhCredenciais>
    {
        public UsuarioEhCredenciaisDtoValidation()
        {
            RuleFor(u => u.Nickname)
                .NotEmpty()
                .WithMessage("Campo obrigatório");

            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("Campo obrigatório");            
            
            RuleFor(u => u.Sobrenome)
                .NotEmpty()
                .WithMessage("Campo obrigatório");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Campo obrigatório");


            RuleFor(u => u.Senha)
                 .NotEmpty()
                .WithMessage("Campo obrigatório");
        }
    }
}
