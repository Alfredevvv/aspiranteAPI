using aspiranteAPI.DTOs;
using FluentValidation;

namespace aspiranteAPI.Validators
{
    public class AspiranteModifierValidator : AbstractValidator<AspiranteModifiedDto>
    {
        public AspiranteModifierValidator()
        {
            RuleFor(x=> x.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x=> x.Apellidos).NotEmpty().WithMessage("Los apellidos son requeridos");
            RuleFor(x=> x.Edad).NotEmpty().WithMessage("La edad es requerida");
            RuleFor(x=> x.Estatura).NotEmpty().WithMessage("La estatura es requerida");
            RuleFor(x=> x.Correo).NotEmpty().WithMessage("El correo es requerido");
            RuleFor(x=> x.Telefono).NotEmpty().WithMessage("El telefono es requerido");

        }
    }
}
