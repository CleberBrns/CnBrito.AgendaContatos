using CnBrito.AgendaContatos.Business.Contract.Usuarios;
using CnBrito.AgendaContatos.Model.Usuario;
using CnBrito.AgendaContatos.Web.Controllers;
using CnBrito.AgendaContatos.Web.Session;
using CnBrito.AgendaContatos.Web.Util;
using System;
using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Areas.Usuario.Controllers
{
    public class UsuarioController : BaseController
    {
        #region Propriedades e Construtor

        IUsuarioBusiness _usuarioBusiness;
        readonly UsuarioSession session = new UsuarioSession();
        readonly Mensagens mensagens = new Mensagens();

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            this._usuarioBusiness = usuarioBusiness;
        }

        #endregion

        // GET: Usuario/Usuario
        public ActionResult Index()
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            return View();
        }

        public ActionResult NovoUsuario()
        {
            return PartialView("_NovoUsuario", new UsuarioModel());
        }

        [HttpPost]        
        public ActionResult Cadastrar(UsuarioModel model)
        {
            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            if (ModelState.IsValid) //verifica se é válido
            {
                try
                {
                    var resultService = _usuarioBusiness.Salvar(model);

                    msgExibicao = resultService.Message;
                    msgAnalise = !resultService.Status ? "Falha" : string.Empty;
                }
                catch (Exception ex)
                {
                    //var msgsRetornos = ErrosService.GetMensagemService(ex, HttpContext.Response);
                    msgExibicao = Model.Common.Constants.msgFalhaAoSalvar;
                    msgAnalise = ex.ToString();
                }

                var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
                return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return PartialView("_NovoUsuario", model);
            }           
        }
    }
}