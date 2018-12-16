using CnBrito.AgendaContatos.Business.Contract.Agenda;
using CnBrito.AgendaContatos.Model.Agenda;
using CnBrito.AgendaContatos.Web.Controllers;
using CnBrito.AgendaContatos.Web.Util;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Areas.Contatos.Controllers
{
    public class ContatoController : BaseController
    {
        #region Propriedades e Construtor

        IAgendaContatoBusiness _agendaContatoBusiness;
        readonly Mensagens mensagens = new Mensagens();

        public ContatoController(IAgendaContatoBusiness agendaContatoBusiness)
        {
            this._agendaContatoBusiness = agendaContatoBusiness;
        }

        #endregion
        
        public ActionResult Index()
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            ViewBag.Usuario = userInfo.Item1;

            return View();
        }

        public ActionResult Listagem()
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            ViewBag.Usuario = userInfo.Item1;

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            try
            {
                var resultService = _agendaContatoBusiness.ListContatosUsuario(userInfo.Item1.Id);
                var list = resultService.Value;

                msgExibicao = resultService.Message;
                msgAnalise = !resultService.Status ? "Falha!" : string.Empty;
    
                return PartialView("_Listagem", list);
            }
            catch (Exception ex)
            {
                msgExibicao = Model.Common.Constants.msgFalhaAoCarregar;
                msgAnalise = ex.ToString();
            }

            var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
            return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModalCadastrar()
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            ViewBag.Usuario = userInfo.Item1;
            var novoContato = new ContatoModel
            {
                Id = 0,
                IdUsuario = userInfo.Item1.Id,
                Telefones = new List<TelefoneModel>(),
                Emails = new List<EmailModel>()
            };

            return PartialView("_Gerenciar", novoContato);
        }

        public ActionResult ModalEditar(int id)
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            ViewBag.Usuario = userInfo.Item1;

            try
            {
                var resultService = _agendaContatoBusiness.GetContato(id);

                if (resultService.Status)
                {
                    var model = resultService.Value;
                    return PartialView("_Gerenciar", model);
                }
                else
                {
                    msgExibicao = resultService.Message;
                    msgAnalise = "Erro!";
                }
            }
            catch (Exception ex)
            {
                msgExibicao = Model.Common.Constants.msgFalhaAoCarregar;
                msgAnalise = ex.ToString();
            }

            var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
            return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Salvar(ContatoModel model)
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            try
            {
                var resultService = _agendaContatoBusiness.SalvarContato(model);

                msgExibicao = resultService.Message;
                msgAnalise = !resultService.Status ? "Falha!" : string.Empty;

                if (resultService.Status)
                {
                    return PartialView("_Gerenciar", resultService.Value);
                }
            }
            catch (Exception ex)
            {
                msgExibicao = Model.Common.Constants.msgFalhaAoSalvar;
                msgAnalise = ex.ToString();
            }

            var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
            return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            try
            {
                var resultService = _agendaContatoBusiness.ExcluirContato(id);

                msgExibicao = resultService.Message;
                msgAnalise = !resultService.Status ? "Falha" : string.Empty;
            }
            catch (Exception ex)
            {                
                msgExibicao = Model.Common.Constants.msgFalhaAoExcluir;
                msgAnalise = ex.ToString();
            }

            var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
            return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);
        }
    }
}