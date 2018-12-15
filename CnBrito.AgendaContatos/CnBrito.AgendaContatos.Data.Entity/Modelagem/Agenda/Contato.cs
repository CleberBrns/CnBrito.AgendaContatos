using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario.Usuario Usuario { get; set; }
        public virtual List<Telefone> Telefones { get; set; }
        public virtual List<Email> Emails { get; set; }
    }
}
