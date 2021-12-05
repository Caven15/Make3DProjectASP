using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectDAL.Entities
{
    public class ArticleEntity
    {
        public int Id { get; set; }
        public int Id_utilisateur { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date_envoi { get; set; }
        public DateTime Date_modif { get; set; }
        public string NomCreateur { get; set; }
    }
}
