using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract.Agenda
{
    public interface ITelefoneDataAccess : IRepositoryBase<TelefoneModel>
    {
        TelefoneModel GetTelefone(int id);
        TelefoneModel GetTelefoneContato(int idContato);
        List<TelefoneModel> ListTelefonesContato(int idContato);
    }
}
