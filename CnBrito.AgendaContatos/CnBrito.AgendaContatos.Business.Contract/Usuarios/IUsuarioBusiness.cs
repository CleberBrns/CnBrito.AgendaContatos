using CnBrito.AgendaContatos.Model.Common;
using CnBrito.AgendaContatos.Model.Usuario;

namespace CnBrito.AgendaContatos.Business.Contract.Usuarios
{
    public interface IUsuarioBusiness
    {
        ResultModel<UsuarioModel> Get(int idUsuario);
        ResultModel<UsuarioModel> Autenticar(UsuarioModel usuario);
        ResultModel<bool> Salvar(UsuarioModel usuario);
        ResultModel<bool> Excluir(int idUsuario);

    }
}
