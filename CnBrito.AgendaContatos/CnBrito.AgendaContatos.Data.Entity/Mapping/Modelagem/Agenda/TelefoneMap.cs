using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using System.Data.Entity.ModelConfiguration;

namespace CnBrito.AgendaContatos.Data.Entity.Mapping.Modelagem.Agenda
{
    class TelefoneMap : EntityTypeConfiguration<Telefone>, IMapping
    {
        public TelefoneMap()
        {
            ToTable("Telefone", "agendaContatos");

            HasKey(x => x.Id);

            Property(x => x.Numero)
                .HasMaxLength(20);

            Property(x => x.Descricao)
                .HasMaxLength(50);                

            HasRequired(x => x.Contato)
               .WithMany(x => x.Telefones)
               .HasForeignKey(x => x.IdContato);               
        }    
    }
}
