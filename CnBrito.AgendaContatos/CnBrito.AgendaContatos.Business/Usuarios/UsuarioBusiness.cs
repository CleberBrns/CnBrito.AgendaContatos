using CnBrito.AgendaContatos.Business.Contract.Usuarios;
using CnBrito.AgendaContatos.Data.Contract.Usuarios;
using CnBrito.AgendaContatos.Model.Common;
using CnBrito.AgendaContatos.Model.Usuario;
using System;

namespace CnBrito.AgendaContatos.Business.Usuarios
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        #region Propriedades e Construtor        
        readonly IUsuarioDataAccess _usuarioDataAccess;

        public UsuarioBusiness(IUsuarioDataAccess usuarioDataAccess)
        {
            this._usuarioDataAccess = usuarioDataAccess;            
        }
        #endregion

        public ResultModel<UsuarioModel> Autenticar(UsuarioModel model)
        {
            var result = new ResultModel<UsuarioModel>();
            result.Status = false;
            var usuarioValido = false;

            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Senha))
                result.Message = "O campo Login e Senha são obrigatórios!";
            else
            {
                var retorno = _usuarioDataAccess.GetByLogin(model.Login);

                if (retorno != null)
                {
                    if (model.Senha != retorno.Senha)
                        result.Message = "Senha inválida!";
                    else
                        usuarioValido = true;
                }
                else
                    result.Message = "Usuário inválido!";

                if (usuarioValido)
                {
                    result.Value = retorno;
                    result.Status = usuarioValido;
                }
            }

            return result;
        }

        public ResultModel<UsuarioModel> Get(int idUsuario)
        {
            var result = new ResultModel<UsuarioModel>();

            var registro = _usuarioDataAccess.GetUsuario(idUsuario);

            if (registro != null)
            {
                result.Value = registro;                
            }
            else
            {
                result.Message = Constants.msgFalhaAoBuscar;
                result.Status = false;
            }

            return result;
        }

        public ResultModel<bool> Salvar(UsuarioModel model)
        {
            var result = new ResultModel<bool>();

            var loginJahUtilizado = VerificaExistenciaLogin(model);

            if (loginJahUtilizado.Item2)
            {
                result = loginJahUtilizado.Item1;
            }
            else
            {
                if (model.Id == 0)
                {
                    model = _usuarioDataAccess.Salvar(model);
                    if (model.Id != 0)
                    {
                        result.Message = Constants.msgSucessoSalvar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoSalvar;
                }
                else
                {
                    result.Value = _usuarioDataAccess.Atualizar(model);

                    if (result.Value)
                    {
                        result.Message = Constants.msgSucessoAtualizar;
                        result.Value = true;
                        result.Status = true;
                    }
                    else
                        result.Message = Constants.msgFalhaAoAtualizar;
                }
            }

            return result;
        }

        public ResultModel<bool> Excluir(int idUsuario)
        {
            var result = new ResultModel<bool>();
            result.Status = false;

            var registro = _usuarioDataAccess.GetUsuario(idUsuario);

            if (registro != null)            
                result.Value = _usuarioDataAccess.Excluir(registro);

            if (result.Value)
            {
                result.Message = Constants.msgSucessoExcluir;
                result.Status = true;
            }
            else
                result.Message = Constants.msgFalhaAoExcluir;

            return result;
        }

        #region Métodos Privados

        private Tuple<ResultModel<bool>, bool> VerificaExistenciaLogin(UsuarioModel model)
        {
            var result = new ResultModel<bool>();

            var loginExistente = false;
            var usuario = _usuarioDataAccess.GetByLogin(model.Login);

            if (usuario != null && usuario.Id != model.Id)
            {
                result.Message = "Login já utilizado por outro usuário, não é permitido sua reutilização";
                result.Status = false;
                loginExistente = true;
            }

            return new Tuple<ResultModel<bool>, bool>(result, loginExistente);
        }

        #endregion
    }
}
