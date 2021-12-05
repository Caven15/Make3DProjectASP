using Make3DProjectBLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Make3DProjectUI.Models
{
    public class ArticleASPModel
    {
        public int Id { get; set; }

        [DisplayName("Nom:")]
        public string Nom { get; set; }


        [DisplayName("Description :")]
        public string Description { get; set; }


        public int Id_utilisateur { get; set; }


        [DisplayName("Date création :")]
        public DateTime Date_envoi { get; set; }


        [DisplayName("Date modification :")]
        public DateTime Date_modif { get; set; }


        [DisplayName("Créateur :")]
        public string NomCreateur { get; set; }


        [DisplayName("Statut :")]
        public ArticleStatutEnum Statut { get; set; }
    }
}
