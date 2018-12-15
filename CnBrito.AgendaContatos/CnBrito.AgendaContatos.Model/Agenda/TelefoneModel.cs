using System.ComponentModel.DataAnnotations;

namespace CnBrito.AgendaContatos.Model.Agenda
{
    public class TelefoneModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requerido!")]
        public int IdContato { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(50, ErrorMessage = "O {0} não pode conter mais que {1} caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Informe o telefone.", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "O {0} não pode conter mais que {1} caracteres.")]
        public string Numero { get; set; }
    }
}
