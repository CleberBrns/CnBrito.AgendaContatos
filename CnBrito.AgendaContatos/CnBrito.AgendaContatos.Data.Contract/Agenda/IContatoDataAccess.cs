using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract.Agenda
{
    public interface IContatoDataAccess : IRepositoryBase<ContatoModel>
    {
        ContatoModel GetContatoUsuario(int idUsuario);
        List<ContatoModel> ListaContatosUsuario(int idUsuario);
    }
}
