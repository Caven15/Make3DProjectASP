using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectBLL.Models
{
    public class UserConnectedModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
