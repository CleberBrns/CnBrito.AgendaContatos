using CnBrito.AgendaContatos.Data.Entity.Mapping;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using CnBrito.AgendaContatos.Data.Entity.Modelagem.Usuario;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace CnBrito.AgendaContatos.Data.Entity
{
    public class AgdCtContext : DbContext
    {
        public AgdCtContext() : base("CnBrito.AgendaContatos")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        #region Tabelas

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Email> Email { get; set; }

        #endregion

        #region Configurações Padrões

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            //Altera as configurações padrões do Entity ao criar as tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == "Id").Configure(x => x.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Properties<DateTime>().Configure(p => p.HasColumnType("datetime2"));


            //Recuperando todas as classes que herdam da IMapping
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var type in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(mappingClass);
            }

            base.OnModelCreating(modelBuilder);
        }

        public void ChangeObjectState(object model, EntityState state)
        {
            //Trocando o estado de um objeto
            ((IObjectContextAdapter)this)
                .ObjectContext
                .ObjectStateManager
                .ChangeObjectState(model, state);
        }

        #endregion
    }
}
