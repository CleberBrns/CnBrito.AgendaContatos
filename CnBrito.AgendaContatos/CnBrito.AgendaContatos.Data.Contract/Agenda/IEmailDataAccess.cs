using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract.Agenda
{
    public interface IEmailDataAccess : IRepositoryBase<EmailModel>
    {
        EmailModel GetEmailContato(int idContato);
        List<EmailModel> ListEmailsContato(int idContato);
    }
}
