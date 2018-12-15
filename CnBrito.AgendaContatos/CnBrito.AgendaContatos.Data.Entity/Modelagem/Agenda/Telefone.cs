using System.ComponentModel.DataAnnotations.Schema;

namespace CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }  
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
