using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Make3DProjectUI.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-mail :")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe :")]
        public string Password { get; set; }
    }
}
