using AutoMapper;
using CnBrito.AgendaContatos.Data.Contract.Agenda;
using CnBrito.AgendaContatos.Data.Entity;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;
using System.Linq;

namespace CnBrito.AgendaContatos.DataAccess.Agenda
{
    public class TelefoneDataAccess : RepositoryBase<TelefoneModel, Telefone>, ITelefoneDataAccess
    {
        public TelefoneDataAccess(IMapper mapper) : base(mapper) { }

        public TelefoneModel GetTelefone(int id)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<TelefoneModel>(
                        context.Telefone.Where(f => f.Id == id)
                                       .FirstOrDefault());
            }
        }

        public TelefoneModel GetTelefoneContato(int idContato)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<TelefoneModel>(
                        context.Telefone.Where(f => f.IdContato == idContato)
                                       .FirstOrDefault());
            }
        }

        public TelefoneModel GetTelefoneContato(int idContato, string telefone)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<TelefoneModel>(
                        context.Telefone.Where(f => f.IdContato == idContato &&
                                                    f.Numero == telefone)
                                       .FirstOrDefault());
            }
        }

        public List<TelefoneModel> ListTelefonesContato(int idContato)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<List<TelefoneModel>>(
                        context.Telefone.Where(f => f.IdContato == idContato)
                                       .ToList());
            }
        }
    }
}
