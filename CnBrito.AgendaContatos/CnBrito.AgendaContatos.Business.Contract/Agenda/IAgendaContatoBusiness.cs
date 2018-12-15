using CnBrito.AgendaContatos.Model.Agenda;
using CnBrito.AgendaContatos.Model.Common;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Business.Contract.Agenda
{
    public interface IAgendaContatoBusiness
    {
        #region Contato
        ResultModel<ContatoModel> GetContato(int idContato);
        ResultModel<ContatoModel> GetContatoUsuario(int idUsuario);
        ResultModel<List<ContatoModel>> ListContatosUsuario(int idUsuario);
        ResultModel<bool> SalvarContato(ContatoModel contato);
        ResultModel<bool> ExcluirContato(int idContato);
        #endregion

        #region Telefone
        ResultModel<TelefoneModel> GetTelefone(int idTelefone);
        ResultModel<List<TelefoneModel>> GetTelefonesContato(int idContato);
        ResultModel<bool> SalvarTelefone(TelefoneModel telefone);
        ResultModel<bool> ExcluirTelefone(int idTelefone);
        #endregion

        #region Email

        ResultModel<EmailModel> GetEmail(int idEmail);
        ResultModel<List<EmailModel>> GetEmailsContato(int idContato);
        ResultModel<bool> SalvarEmail(EmailModel email);
        ResultModel<bool> ExcluirEmail(int idEmail);

        #endregion
    }
}
