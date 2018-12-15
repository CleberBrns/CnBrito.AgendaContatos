using AutoMapper;
using CnBrito.AgendaContatos.Data.Contract.Usuarios;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Usuario;
using CnBrito.AgendaContatos.Model.Usuario;

namespace CnBrito.AgendaContatos.DataAccess.Usuarios
{
    public class UsuarioDataAccess : RepositoryBase<UsuarioModel, Usuario>, IUsuarioDataAccess
    {
        public UsuarioDataAccess(IMapper mapper) : base(mapper) { }

        public UsuarioModel GetUsuario(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
