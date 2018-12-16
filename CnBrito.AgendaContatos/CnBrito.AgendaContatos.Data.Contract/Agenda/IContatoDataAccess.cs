using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Contract.Agenda
{
    public interface IContatoDataAccess : IRepositoryBase<ContatoModel>
    {
        ContatoModel Get(int id);
        ContatoModel GetContatoUsuario(int idUsuario);
        ContatoModel GetContatoUsuario(int idUsuario, string nome);
        List<ContatoModel> ListaContatosUsuario(int idUsuario);
        bool Excluir(int id);
    }
}
