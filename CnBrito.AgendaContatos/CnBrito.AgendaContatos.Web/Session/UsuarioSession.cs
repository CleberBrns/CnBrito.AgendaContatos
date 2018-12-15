using CnBrito.AgendaContatos.Model.Usuario;
using CnBrito.AgendaContatos.Web.Session.Contract;

namespace CnBrito.AgendaContatos.Web.Session
{
    public class UsuarioSession : SessionBase<UsuarioModel>, ISessionUsuario
    {
    }
}
