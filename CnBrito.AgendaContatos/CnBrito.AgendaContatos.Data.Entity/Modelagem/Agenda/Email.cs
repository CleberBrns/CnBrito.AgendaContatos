using System.ComponentModel.DataAnnotations.Schema;

namespace CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda
{
    public class Email
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
