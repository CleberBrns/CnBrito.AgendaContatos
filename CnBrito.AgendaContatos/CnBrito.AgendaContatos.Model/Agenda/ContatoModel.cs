using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CnBrito.AgendaContatos.Model.Agenda
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do contato.", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Requerido!")]
        public int IdUsuario { get; set; }

        public List<TelefoneModel> Telefones { get; set; }
        public List<EmailModel> Emails { get; set; }
    }
}
