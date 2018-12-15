using CnBrito.AgendaContatos.Model.Usuario;
using CnBrito.AgendaContatos.Web.Session;
using System;
using System.Net;
using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Controllers
{
    public class BaseController : Controller
    {
        public void ValidaAutorizaoAcessoUsuario(string permissaoAcesso)
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
            {
                BadRequestCustomizado((int)HttpStatusCode.Unauthorized);
            }               
        }

        public Tuple<UsuarioModel, bool> GetUsuarioSession()
        {
            UsuarioSession sessionUsuario = new UsuarioSession();
            return sessionUsuario.GetModelFromSession(Constants.ConstSessions.usuario);
        }

        public void BadRequestCustomizado(int statusCode)
        {
            HttpContext.Response.Clear();
            HttpContext.Response.TrySkipIisCustomErrors = true;

            HttpContext.Response.StatusCode = statusCode;
        }
    }
}