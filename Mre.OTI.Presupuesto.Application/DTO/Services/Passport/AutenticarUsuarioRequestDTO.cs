using FluentValidation;
using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Autentication;

namespace Mre.OTI.Presupuesto.Application.DTO.Services.Passport
{
    public class AutenticarUsuarioRequestDTO  
    {

        public string ipAcceso { get; set; }

        public string userName { get; set; }
        public string password { get; set; }
        public string dispositivo { get; set; }


        public string tokenCaptcha { get; set; }

        public string login { get; set; }
        public string pwd { get; set; }

        public string usuarioNT { get; set; }
        public string claveNT { get; set; }

        public int codigoPerfilCentroCosto { get; set; }
        /// <summary>
        /// SOLO USADO PARA LA DESENCRIPTACION EN BD DEL PERSONAL NT
        /// </summary>
        public string fraseEncriptacion { get; set; }
    }
    //public class AutenticarUsuarioViewModelValidator : AbstractValidator<AutenticarUsuarioViewModel>
    //{
    //    public AutenticarUsuarioViewModelValidator()
    //    {
    //        RuleFor(x => x.userName).NotEmpty().WithMessage("{PropertyName} no puede ser vacio");


    //        //RuleFor(x => x.plazas).Custom((data, context) =>
    //        //{
    //        //    if (data.Sum(x => x.cantidadJornadaLaboral) > 30)
    //        //    {
    //        //        //context.AddFailure(new ValidationFailure("Error", Constantes.MensajesError.EX_ADJUDICACION_PUN_JORNADA_LABORAL_MINIMO));
    //        //    }
    //        //    else
    //        //    {
    //        //        var index = 1;
    //        //        foreach (var d in data)
    //        //        {
    //        //            if (d.inicioContrato > d.finContrato)
    //        //            {
    //        //                context.AddFailure(new ValidationFailure("Error", "FILA " + index + ": " + Constantes.MensajesError.EX_ADJUDICACION_PUN_FECHA_FIN_MAYOR_A_INI));
    //        //            }
    //        //            index++;
    //        //        }
    //        //    }
    //        //});
    //    }
    //}
}
