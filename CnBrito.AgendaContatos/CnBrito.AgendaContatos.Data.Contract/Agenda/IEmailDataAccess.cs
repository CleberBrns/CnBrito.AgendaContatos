using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract.Agenda
{
    public interface IEmailDataAccess : IRepositoryBase<EmailModel>
    {
        EmailModel GetEmail(int id);
        EmailModel GetEmailContato(int idContato);
        EmailModel GetEmailContato(int idContato, string email);
        List<EmailModel> ListEmailsContato(int idContato);
    }
}
