using System.ComponentModel.DataAnnotations;

namespace CnBrito.AgendaContatos.Model.Agenda
{
    public class EmailModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requerido!")]
        public int IdContato { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o e-mail.", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O {0} não pode conter mais que {1} caracteres.")]
        public string Endereco { get; set; }
    }
}
