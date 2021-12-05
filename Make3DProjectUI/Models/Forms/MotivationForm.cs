using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Make3DProjectUI.Models.Forms
{
    public class MotivationForm
    {
        [Required]
        [DisplayName("Raison :")]
        public string Motivation { get; set; }
        public ArticleASPModel Article { get; set; }

    }
}
