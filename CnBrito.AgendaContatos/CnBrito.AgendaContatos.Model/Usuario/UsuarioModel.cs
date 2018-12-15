﻿using CnBrito.AgendaContatos.Model.Agenda;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CnBrito.AgendaContatos.Model.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O {0} não pode conter mais que {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login do usuário", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "O {0} não pode conter mais que {1} caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "A {0} não pode conter mais que {1} caracteres.")]
        public string Senha { get; set; }

        public List<ContatoModel> Contatos { get; set; }
    }
}
