using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;

namespace CnBrito.AgendaContatos.Model.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<ContatoModel> Contatos { get; set; }
    }
}
