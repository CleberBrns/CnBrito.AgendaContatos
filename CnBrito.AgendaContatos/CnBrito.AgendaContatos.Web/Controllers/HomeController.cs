using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!GetUsuarioSession().Item2)
                return RedirectToAction("Login", "Login");

            return RedirectToAction("Index", "Contato");
        }
    }
}