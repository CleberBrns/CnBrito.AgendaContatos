using CnBrito.AgendaContatos.Data.Entity.Modelagem.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Data.Entity.Modelagem.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public virtual List<Contato> Contatos { get; set; }
    }
}
