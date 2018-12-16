using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Areas.Usuario
{
    public class UsuarioAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Usuario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Usuario_default",
                "Usuario/{controller}/{action}/{id}",
                new { Area = "Usuario", Controller = "Usuario", action = "Index", id = UrlParameter.Optional },
                new[] { "CnBrito.AgendaContatos.Web.Areas.Usuario.Controllers" }
            );
        }
    }
}