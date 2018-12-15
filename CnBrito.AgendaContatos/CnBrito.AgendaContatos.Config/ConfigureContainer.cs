using AutoMapper;
using CnBrito.AgendaContatos.Business.Agenda;
using CnBrito.AgendaContatos.Business.Contract.Agenda;
using CnBrito.AgendaContatos.Business.Contract.Usuarios;
using CnBrito.AgendaContatos.Business.Usuarios;
using CnBrito.AgendaContatos.Data.Contract.Agenda;
using CnBrito.AgendaContatos.Data.Contract.Usuarios;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Usuario;
using CnBrito.AgendaContatos.DataAccess.Agenda;
using CnBrito.AgendaContatos.DataAccess.Usuarios;
using CnBrito.AgendaContatos.Model.Agenda;
using CnBrito.AgendaContatos.Model.Usuario;
using CnBrito.AgendaEmails.DataAccess.Agenda;
using Unity;

namespace CnBrito.AgendaContatos.Config
{
    public class ConfigureContainer
    {
        public static void InitializeContainer(IUnityContainer container, bool fake = false)
        {
            container.RegisterInstance<IMapper>(InitializeAutoMapper().CreateMapper());

            #region DataAccess
            //Agenda
            container.RegisterType<IContatoDataAccess, ContatoDataAccess>();
            container.RegisterType<IEmailDataAccess, EmailDataAccess>();
            container.RegisterType<ITelefoneDataAccess, TelefoneDataAccess>();

            //Usuário             
            container.RegisterType<IUsuarioDataAccess, UsuarioDataAccess>();

            #endregion

            #region Business
            
            container.RegisterType<IAgendaContatoBusiness, AgendaContatoBusiness>();
            container.RegisterType<IUsuarioBusiness, UsuarioBusiness>();

            #endregion
        }

        private static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                /*O 'ReverseMap()' cria apenas um mapeamento inverso simples.
                  Caso o mapeamento tenha alguma configuração especifica, 
                  devemos criar manualmente os dois formato do map*/

                #region Model to Entity

                //Agenda
                cfg.CreateMap<ContatoModel, Contato>().ReverseMap();
                cfg.CreateMap<TelefoneModel, Telefone>().ReverseMap();
                cfg.CreateMap<EmailModel, Email>().ReverseMap();

                //Usuário                
                cfg.CreateMap<UsuarioModel, Usuario>().ReverseMap();

                #endregion
            });
            return config;
        }
    }
}
