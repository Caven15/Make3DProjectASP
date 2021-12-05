using Make3DProjectBLL.Interfaces;
using Make3DProjectBLL.Models;
using Make3DProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectBLL.Mapper
{
    internal static class Mapper
    {

        #region Utilisateur

        internal static UtilisateurEntity BllToDal(this UtilisateurModel model)
        {
            return new UtilisateurEntity()
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
                Email = model.Email,
                DateNaissance = model.DateNaissance,
                Password = model.Password,
                IsAdmin = model.IsAdmin
            };
        }

        internal static UtilisateurModel DalToBll(this UtilisateurEntity entity)
        {
            return new UtilisateurModel()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                DateNaissance = entity.DateNaissance,
                IsAdmin = entity.IsAdmin
            };
        }

        internal static UserConnectedModel DalToBll(this UserConnectedEntity entity)
        {
            return new UserConnectedModel()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                DateNaissance = entity.DateNaissance,
                IsAdmin = entity.IsAdmin,
                Token =entity.Token
            };
        }

        #endregion

        #region Article

        internal static ArticleEntity BllToDal(this ArticleModel model)
        {
            return new ArticleEntity()
            {
                Id_utilisateur = model.Id_utilisateur,
                Nom = model.Nom,
                Description = model.Description,
                Date_envoi = model.Date_envoi,
                Date_modif = model.Date_modif,
                NomCreateur = model.NomCreateur
            };
        }

        internal static ArticleModel DalToBll(this ArticleEntity entity, IArticleService articleService, string token)
        {
            ArticleModel articleModel =  new ArticleModel()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Description = entity.Description,
                Id_utilisateur = entity.Id_utilisateur,
                Date_envoi = entity.Date_envoi,
                Date_modif = entity.Date_modif,
                NomCreateur = entity.NomCreateur
            };

            if (articleService.EstSignale(entity.Id, token))
            {
                articleModel.Statut = ArticleStatutEnum.Signaler;
            }
            else if (articleService.EstBloquer(entity.Id, token))
            {
                articleModel.Statut = ArticleStatutEnum.Bloquer;
            }
            else
            {
                articleModel.Statut = ArticleStatutEnum.Ok;
            }
            return articleModel;
        }

        #endregion
    }
}
