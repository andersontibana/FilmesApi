﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dto
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string Repassword { get; set; }
    }
}
