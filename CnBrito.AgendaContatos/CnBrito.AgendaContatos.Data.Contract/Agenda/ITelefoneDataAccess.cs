using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract.Agenda
{
    public interface ITelefoneDataAccess : IRepositoryBase<TelefoneModel>
    {
        TelefoneModel GetTelefone(int id);
        TelefoneModel GetTelefoneContato(int idContato);
        TelefoneModel GetTelefoneContato(int idContato, string telefone);
        List<TelefoneModel> ListTelefonesContato(int idContato);
    }
}
