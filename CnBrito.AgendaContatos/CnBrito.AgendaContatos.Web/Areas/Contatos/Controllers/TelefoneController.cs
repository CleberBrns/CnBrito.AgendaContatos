﻿using CnBrito.AgendaContatos.Business.Contract.Agenda;
using CnBrito.AgendaContatos.Model.Agenda;
using CnBrito.AgendaContatos.Web.Controllers;
using CnBrito.AgendaContatos.Web.Util;
using System;
using System.Web.Mvc;

namespace CnBrito.AgendaContatos.Web.Areas.Contatos.Controllers
{
    public class TelefoneController : BaseController
    {
        #region Propriedades e Construtor

        IAgendaContatoBusiness _agendaContatoBusiness;
        readonly Mensagens mensagens = new Mensagens();

        public TelefoneController(IAgendaContatoBusiness agendaContatoBusiness)
        {
            this._agendaContatoBusiness = agendaContatoBusiness;
        }

        #endregion
        public ActionResult Salvar(TelefoneModel model)
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            try
            {
                var resultService = _agendaContatoBusiness.SalvarTelefone(model);

                msgExibicao = resultService.Message;
                msgAnalise = !resultService.Status ? "Falha!" : string.Empty;
            }
            catch (Exception ex)
            {
                msgExibicao = Model.Common.Constants.msgFalhaAoSalvar;
                msgAnalise = ex.ToString();
            }

            var mensagensRetorno = mensagens.ConfiguraMensagemRetorno(msgExibicao, msgAnalise);
            return Json(new { mensagensRetorno }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarTelefonesContato(int idContato)
        {
            var userInfo = GetUsuarioSession();
            if (!userInfo.Item2)
                return RedirectToAction("Login", "Login", new { area = "" });

            ViewBag.Usuario = userInfo.Item1;

            string msgExibicao = string.Empty;
            string msgAnalise = string.Empty;

            try
            {
                var resultService = _agendaContatoBusiness.GetTelefonesContato(idContato);
                var list = resultService.Value;

                msgExibicao = resultService.Message;
                msgAnalise = !resultService.Status ? "Falha!" : string.Empty;

                return PartialView("../Contato/_GridTelefones", list);
            }
            catch (Exception ex)
            {
                msgExibicao = Model.Common.Constants.msgFalhaAoCarregar;
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
                var resultService = _agendaContatoBusiness.ExcluirTelefone(id);

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