using CnBrito.AgendaContatos.Business.Contract.Agenda;
using CnBrito.AgendaContatos.Data.Contract.Agenda;
using CnBrito.AgendaContatos.Model.Agenda;
using CnBrito.AgendaContatos.Model.Common;
using System;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Business.Agenda
{
    public class AgendaContatoBusiness : IAgendaContatoBusiness
    {
        #region Propriedades e Construtor        
        readonly IContatoDataAccess _contatoDataAccess;
        readonly ITelefoneDataAccess _telefoneDataAccess;
        readonly IEmailDataAccess _emailDataAccess;

        public AgendaContatoBusiness(IContatoDataAccess contatoDataAccess, 
                                     ITelefoneDataAccess telefoneDataAccess, 
                                     IEmailDataAccess emailDataAccess)
        {
            this._contatoDataAccess = contatoDataAccess;
            this._telefoneDataAccess = telefoneDataAccess;
            this._emailDataAccess = emailDataAccess;
        }
        #endregion

        #region Contato

        public ResultModel<ContatoModel> GetContato(int idContato)
        {
            var result = new ResultModel<ContatoModel>();
            result.Value = _contatoDataAccess.Get(idContato);

            if (result.Value == null)
            {
                result.Status = false;
                result.Message = Constants.msgFalhaAoBuscar;
            }

            return result;
        }
        public ResultModel<ContatoModel> GetContatoUsuario(int idUsuario)
        {
            var result = new ResultModel<ContatoModel>();
            result.Value = _contatoDataAccess.GetContatoUsuario(idUsuario);

            if (result.Value == null)
            {
                result.Status = false;
                result.Message = Constants.msgFalhaAoBuscar;
            }

            return result;
        }
        public ResultModel<List<ContatoModel>> ListContatosUsuario(int idUsuario)
        {
            var result = new ResultModel<List<ContatoModel>>();
            result.Value = _contatoDataAccess.ListaContatosUsuario(idUsuario);

            return result;
        }
        public ResultModel<bool> SalvarContato(ContatoModel model)
        {
            var result = new ResultModel<bool>();

            var nomeJahUtilizado = VerificaExistenciaNomeContato(model);

            if (nomeJahUtilizado.Item2)
            {
                result = nomeJahUtilizado.Item1;
            }
            else
            {
                if (model.Id != 0)
                {
                    model = _contatoDataAccess.Salvar(model);
                    if (model.Id != 0)
                    {
                        result.Message = Constants.msgSucessoSalvar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoSalvar;
                }
                else
                {
                    result.Value = _contatoDataAccess.Atualizar(model);

                    if (result.Value)
                    {
                        result.Message = Constants.msgSucessoAtualizar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoAtualizar;
                }
            }

            return result;
        }

        public ResultModel<bool> ExcluirContato(int idContato)
        {
            var result = new ResultModel<bool>();
            result.Status = false;

            var registro = _contatoDataAccess.Get(idContato);

            if (registro != null)
                result.Value = _contatoDataAccess.Excluir(registro);

            if (result.Value)
            {
                result.Message = Constants.msgSucessoExcluir;
                result.Status = true;
            }
            else
                result.Message = Constants.msgFalhaAoExcluir;

            return result;
        }

        #endregion

        #region Telefone

        public ResultModel<TelefoneModel> GetTelefone(int idTelefone)
        {
            var result = new ResultModel<TelefoneModel>();
            result.Value = _telefoneDataAccess.GetTelefone(idTelefone);

            if (result.Value == null)
            {
                result.Status = false;
                result.Message = Constants.msgFalhaAoBuscar;
            }

            return result;
        }

        public ResultModel<List<TelefoneModel>> GetTelefonesContato(int idContato)
        {
            var result = new ResultModel<List<TelefoneModel>>();
            result.Value = _telefoneDataAccess.ListTelefonesContato(idContato);

            return result;
        }

        public ResultModel<bool> SalvarTelefone(TelefoneModel model)
        {
            var result = new ResultModel<bool>();

            var telefoneJahUtilizado = VerificaExistenciaTelefoneContato(model);

            if (telefoneJahUtilizado.Item2)
            {
                result = telefoneJahUtilizado.Item1;
            }
            else
            {
                if (model.Id != 0)
                {
                    model = _telefoneDataAccess.Salvar(model);
                    if (model.Id != 0)
                    {
                        result.Message = Constants.msgSucessoSalvar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoSalvar;
                }
                else
                {
                    result.Value = _telefoneDataAccess.Atualizar(model);

                    if (result.Value)
                    {
                        result.Message = Constants.msgSucessoAtualizar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoAtualizar;
                }
            }

            return result;
        }

        public ResultModel<bool> ExcluirTelefone(int idTelefone)
        {
            var result = new ResultModel<bool>();
            result.Status = false;

            var registro = _telefoneDataAccess.GetTelefone(idTelefone);

            if (registro != null)
                result.Value = _telefoneDataAccess.Excluir(registro);

            if (result.Value)
            {
                result.Message = Constants.msgSucessoExcluir;
                result.Status = true;
            }
            else
                result.Message = Constants.msgFalhaAoExcluir;

            return result;
        }

        #endregion

        #region Email
        public ResultModel<EmailModel> GetEmail(int idEmail)
        {
            var result = new ResultModel<EmailModel>();
            result.Value = _emailDataAccess.GetEmail(idEmail);

            if (result.Value == null)
            {
                result.Status = false;
                result.Message = Constants.msgFalhaAoBuscar;
            }

            return result;
        }

        public ResultModel<List<EmailModel>> GetEmailsContato(int idContato)
        {
            var result = new ResultModel<List<EmailModel>>();
            result.Value = _emailDataAccess.ListEmailsContato(idContato);

            return result;
        }

        public ResultModel<bool> SalvarEmail(EmailModel model)
        {
            var result = new ResultModel<bool>();

            var telefoneJahUtilizado = VerificaExistenciaEmailContato(model);

            if (telefoneJahUtilizado.Item2)
            {
                result = telefoneJahUtilizado.Item1;
            }
            else
            {
                if (model.Id != 0)
                {
                    model = _emailDataAccess.Salvar(model);
                    if (model.Id != 0)
                    {
                        result.Message = Constants.msgSucessoSalvar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoSalvar;
                }
                else
                {
                    result.Value = _emailDataAccess.Atualizar(model);

                    if (result.Value)
                    {
                        result.Message = Constants.msgSucessoAtualizar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoAtualizar;
                }
            }

            return result;
        }
        public ResultModel<bool> ExcluirEmail(int idEmail)
        {
            var result = new ResultModel<bool>();
            result.Status = false;

            var registro = _emailDataAccess.GetEmail(idEmail);

            if (registro != null)
                result.Value = _emailDataAccess.Excluir(registro);

            if (result.Value)
            {
                result.Message = Constants.msgSucessoExcluir;
                result.Status = true;
            }
            else
                result.Message = Constants.msgFalhaAoExcluir;

            return result;
        }
        #endregion

        #region Métodos Privados

        private Tuple<ResultModel<bool>, bool> VerificaExistenciaNomeContato(ContatoModel model)
        {
            var result = new ResultModel<bool>();

            var registroExistente = false;
            var usuario = _contatoDataAccess.GetContatoUsuario(model.IdUsuario, model.Nome);

            if (usuario != null && usuario.Id != model.Id)
            {
                result.Message = "Nome já utilizado por outro contato, não é permitido sua reutilização";
                result.Status = false;
                registroExistente = true;
            }

            return new Tuple<ResultModel<bool>, bool>(result, registroExistente);
        }

        private Tuple<ResultModel<bool>, bool> VerificaExistenciaTelefoneContato(TelefoneModel model)
        {
            var result = new ResultModel<bool>();

            var registroExistente = false;
            var usuario = _telefoneDataAccess.GetTelefoneContato(model.IdContato, model.Numero);

            if (usuario != null && usuario.Id != model.Id)
            {
                result.Message = "Telefone já utilizado por outro contato, não é permitido sua reutilização";
                result.Status = false;
                registroExistente = true;
            }

            return new Tuple<ResultModel<bool>, bool>(result, registroExistente);
        }

        private Tuple<ResultModel<bool>, bool> VerificaExistenciaEmailContato(EmailModel model)
        {
            var result = new ResultModel<bool>();

            var registroExistente = false;
            var usuario = _emailDataAccess.GetEmailContato(model.IdContato, model.Endereco);

            if (usuario != null && usuario.Id != model.Id)
            {
                result.Message = "Email já utilizado por outro contato, não é permitido sua reutilização";
                result.Status = false;
                registroExistente = true;
            }

            return new Tuple<ResultModel<bool>, bool>(result, registroExistente);
        }

        #endregion
    }
}
