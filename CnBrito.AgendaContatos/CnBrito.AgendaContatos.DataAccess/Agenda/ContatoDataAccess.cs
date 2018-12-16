using AutoMapper;
using CnBrito.AgendaContatos.Data.Contract.Agenda;
using CnBrito.AgendaContatos.Data.Entity;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CnBrito.AgendaContatos.DataAccess.Agenda
{
    public class ContatoDataAccess : RepositoryBase<ContatoModel, Contato>, IContatoDataAccess
    {
        public ContatoDataAccess(IMapper mapper) : base(mapper) { }

        public ContatoModel Get(int id)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<ContatoModel>(
                        context.Contato.Where(f => f.Id == id)
                                       .Include(c => c.Telefones)
                                       .Include(c => c.Emails)
                                       .FirstOrDefault());
            }
        }

        public ContatoModel GetContatoUsuario(int idUsuario)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<ContatoModel>(
                        context.Contato.Where(f => f.IdUsuario == idUsuario)
                                       .Include(c => c.Telefones)
                                       .Include(c => c.Emails)
                                       .FirstOrDefault());
            }
        }

        public ContatoModel GetContatoUsuario(int idUsuario, string nome)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<ContatoModel>(
                        context.Contato.Where(f => f.IdUsuario == idUsuario &&
                                                    f.Nome == nome)
                                       .FirstOrDefault());
            }
        }

        public List<ContatoModel> ListaContatosUsuario(int idUsuario)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<List<ContatoModel>>(
                        context.Contato.Where(f => f.IdUsuario == idUsuario)
                                       .Include(c => c.Telefones)
                                       .Include(c => c.Emails)
                                       .ToList());
            }
        }
    }
}
