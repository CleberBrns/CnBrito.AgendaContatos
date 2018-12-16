using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Areas.Contato
{
    public class ContatoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Contatos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Contatos_default",
                "Contatos/{controller}/{action}/{id}",
                new { Area = "Contatos", Controller = "Contato", action = "Index", id = UrlParameter.Optional },
                new[] { "CnBrito.AgendaContatos.Web.Areas.Contatos.Controllers" }
            );
        }
    }
}