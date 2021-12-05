using Make3DProjectBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectBLL.Interfaces
{
    public interface IArticleService
    {

        #region Récupération
        public IEnumerable<ArticleModel> GetAll(string token);

        public IEnumerable<ArticleModel> GetAllByUserId(int id, string token);

        public ArticleModel GetById(int id, string token);

        #endregion

        #region Signalement
        public void Designaler(int articleId, string token);

        public bool EstSignale(int articleId, string token);

        public bool EstSignaleParUserId(int articleId, int signaleurId, string token);

        #endregion

        #region Bloquage

        public void Bloquer(int articleId, string motivation, string token);

        public void Debloquer(int articleId, string token);

        public bool EstBloquer(int articleId, string token);

        #endregion

    }
}
