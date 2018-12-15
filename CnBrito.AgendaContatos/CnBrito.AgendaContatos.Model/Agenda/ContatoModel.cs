using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Model.Agenda
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public List<TelefoneModel> Telefones { get; set; }
        public List<EmailModel> Emails { get; set; }
    }
}
