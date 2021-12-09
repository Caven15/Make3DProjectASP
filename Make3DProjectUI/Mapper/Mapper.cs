using Make3DProjectBLL.Models;
using Make3DProjectUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Make3DProjectUI.Mapper
{
    internal static class Mapper
    {
        internal static ArticleASPModel BllToAsp(this ArticleModel model)
        {
            ArticleASPModel articleASPModel = new ArticleASPModel()
            {
                Id = model.Id,
                Nom = model.Nom,
                Description = model.Description,
                Id_utilisateur = model.Id_utilisateur,
                Date_envoi = model.Date_envoi,
                Date_modif = model.Date_modif,
                NomCreateur = model.NomCreateur,
                Statut = model.Statut,
                Id_fichiers = model.Id_fichiers
            };
            return articleASPModel;
        }
    }
}
