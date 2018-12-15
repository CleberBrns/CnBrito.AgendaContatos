using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using System.Data.Entity.ModelConfiguration;

namespace CnBrito.AgendaContatos.Data.Entity.Mapping.Modelagem.Agenda
{
    public class EmailMap : EntityTypeConfiguration<Email>, IMapping
    {
        public EmailMap()
        {
            ToTable("Email", "agendaContatos");

            HasKey(x => x.Id);

            Property(x => x.Endereco)
                .HasMaxLength(100)
                .IsRequired();

            HasRequired(x => x.Contato)
               .WithMany(x => x.Emails)
               .HasForeignKey(x => x.IdContato);

        }
    }
}
