using AutoMapper;
using CnBrito.AgendaContatos.Data.Contract.Agenda;
using CnBrito.AgendaContatos.Data.Entity;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using CnBrito.AgendaContatos.DataAccess;
using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;
using System.Linq;

namespace CnBrito.AgendaEmails.DataAccess.Agenda
{
    public class EmailDataAccess : RepositoryBase<EmailModel, Email>, IEmailDataAccess
    {
        public EmailDataAccess(IMapper mapper) : base(mapper) { }

        public EmailModel GetEmail(int id)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<EmailModel>(
                        context.Email.Where(f => f.Id == id)
                                       .FirstOrDefault());
            }
        }

        public EmailModel GetEmailContato(int idContato)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<EmailModel>(
                        context.Email.Where(f => f.IdContato == idContato)                                       
                                       .FirstOrDefault());
            }
        }

        public EmailModel GetEmailContato(int idContato, string email)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<EmailModel>(
                        context.Email.Where(f => f.IdContato == idContato &&
                                                 f.Endereco == email)
                                       .FirstOrDefault());
            }
        }

        public List<EmailModel> ListEmailsContato(int idContato)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<List<EmailModel>>(
                        context.Email.Where(f => f.IdContato == idContato)
                                       .ToList());
            }
        }
    }
}
