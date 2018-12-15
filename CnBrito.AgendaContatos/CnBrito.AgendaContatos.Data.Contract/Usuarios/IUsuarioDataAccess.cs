using CnBrito.AgendaContatos.Model.Usuario;

namespace CnBrito.AgendaContatos.Data.Contract.Usuarios
{
    public interface IUsuarioDataAccess : IRepositoryBase<UsuarioModel>
    {
        UsuarioModel GetUsuario(int id);
    }
}
