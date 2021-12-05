using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectBLL.Models
{
    public enum ArticleStatutEnum
    {
        [Description("N'importe")]
        Tout,     // affiche tout les article sans considération

        [Description("Ok")]
        Ok,   // article ni signalé ni bloqué

        [Description("Signalé")]
        Signaler, // article signalé

        [Description("Bloqué")]
        Bloquer,  // article bloqué
    }
}
