using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using System.Data.Entity.ModelConfiguration;

namespace CnBrito.AgendaContatos.Data.Entity.Mapping.Modelagem.Agenda
{
    public class ContatoMap : EntityTypeConfiguration<Contato>, IMapping
    {
        public ContatoMap()
        {
            ToTable("Contato", "agendaContatos");

            HasKey(x => x.Id);

            Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.IdUsuario)                
                .IsRequired();
        }    
    }
}
