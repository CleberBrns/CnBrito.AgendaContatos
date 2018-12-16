using CnBrito.AgendaContatos.Business.Contract.Usuarios;
using CnBrito.AgendaContatos.Model.Common;
using CnBrito.AgendaContatos.Model.Usuario;
using CnBrito.AgendaContatos.Web.Session;
using CnBrito.AgendaContatos.Web.Util;
using System;
using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Controllers
{
    public class LoginController : BaseController
    {
        #region Propriedades e Construtor

        IUsuarioBusiness _usuarioBusiness;
        readonly UsuarioSession session = new UsuarioSession();
        readonly string sessionName = Constants.ConstSessions.usuario;

        public LoginController(IUsuarioBusiness usuarioBusiness)
        {
            this._usuarioBusiness = usuarioBusiness;
        }

        #endregion

        public ActionResult Login()
        {
            if (GetUsuarioSession().Item2)
                return RedirectToAction("Index", "Inicio");

            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(UsuarioModel model)
        {
            var mensagens = new Mensagens();            

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            var resultService = new ResultModel<UsuarioModel>();
            resultService.Status = false;

            try
            {
                resultService = _usuarioBusiness.Autenticar(model);
                model = resultService.Value;

                if (resultService.Status)
                    session.AddModelToSession(model, sessionName);

                msgExibicao = resultService.Message;
                msgAnalise = !resultService.Status ? "Falha" : string.Empty;

            }
            catch (Exception ex)
            {                
                msgExibicao = "Falha ao autenticar!";
                msgAnalise = ex.ToString();
            }

            var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
            return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            //Remove todas as sessões criadas
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}