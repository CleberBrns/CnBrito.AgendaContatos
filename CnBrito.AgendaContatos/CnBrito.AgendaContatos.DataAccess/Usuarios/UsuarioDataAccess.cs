using AutoMapper;
using CnBrito.AgendaContatos.Data.Contract.Usuarios;
using CnBrito.AgendaContatos.Data.Entity;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Usuario;
using CnBrito.AgendaContatos.Model.Usuario;
using System.Data.Entity;
using System.Linq;

namespace CnBrito.AgendaContatos.DataAccess.Usuarios
{
    public class UsuarioDataAccess : RepositoryBase<UsuarioModel, Usuario>, IUsuarioDataAccess
    {
        public UsuarioDataAccess(IMapper mapper) : base(mapper) { }

        public UsuarioModel GetUsuario(int id)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<UsuarioModel>(
                        context.Usuario.Where(f => f.Id == id)                                    
                                       .Include(c => c.Contatos)
                                       .FirstOrDefault());
            }
        }

        public UsuarioModel GetByLogin(string login)
        {
            using (var context = new AgdCtContext())
            {
                return Mapper.Map<UsuarioModel>(
                        context.Usuario.Where(f => f.Login == login)                                       
                                       .FirstOrDefault());
            }
        }
    }
}
