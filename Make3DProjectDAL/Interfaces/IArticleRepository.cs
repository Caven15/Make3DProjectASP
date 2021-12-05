using Make3DProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectDAL.Interfaces
{
    public interface IArticleRepository
    {
        #region Récupération
        IEnumerable<ArticleEntity> GetAll(string token); // service admin

        IEnumerable<ArticleEntity> GetAllByUserId(int id, string token);

        ArticleEntity GetById(int id, string token);

        #endregion

        #region Signalement
        void Designaler(int articleId, string token); // service admin

        bool EstSignale(int articleId, string token);

        bool EstSignaleParUserId(int articleId, int signaleurId, string token);

        #endregion

        #region Bloquage

        void Bloquer(int articleId, string motivation, string token); // service admin

        void Debloquer(int articleId, string token);

        bool EstBloquer(int articleId, string token);

        #endregion
    }
}
