using System.Data.Entity.ModelConfiguration;

namespace CnBrito.AgendaContatos.Data.Entity.Mapping.Modelagem.Usuario
{
    public class UsuarioMap : EntityTypeConfiguration<Entity.Modelagem.Usuario.Usuario>, IMapping
    {
        public UsuarioMap()
        {
            ToTable("Usuario", "agendaContatos");

            HasKey(x => x.Id);

            Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Nome)
               .HasMaxLength(20)
               .IsRequired();
        }
    }
}
