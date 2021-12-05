using Make3DProjectBLL.Models;
using Make3DProjectDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Make3DProjectBLL.Mapper;
using Make3DProjectBLL.Interfaces;

namespace Make3DProjectBLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        #region Récupération

        public IEnumerable<ArticleModel> GetAll(string token)
        {
            return _articleRepository.GetAll(token).Select(a => a.DalToBll(this,token));
        }

        public IEnumerable<ArticleModel> GetAllByUserId(int id, string token)
        {
            return _articleRepository.GetAllByUserId(id, token).Select(a => a.DalToBll(this, token));
        }

        public ArticleModel GetById(int id, string token)
        {
            return _articleRepository.GetById(id, token).DalToBll(this, token);
        }

        #endregion

        #region Signalement

        public void Designaler(int articleId, string token)
        {
            _articleRepository.Designaler(articleId, token);
        }

        public bool EstSignale(int articleId, string token)
        {
            return _articleRepository.EstSignale(articleId, token);
        }

        public bool EstSignaleParUserId(int articleId, int signaleurId, string token)
        {
            return _articleRepository.EstSignaleParUserId(articleId, signaleurId, token);
        }

        #endregion

        #region Bloquage

        public void Bloquer(int articleId, string motivation, string token)
        {
            _articleRepository.Bloquer(articleId, motivation, token);
        }

        public void Debloquer(int articleId, string token)
        {
            _articleRepository.Debloquer(articleId, token);
        }

        public bool EstBloquer(int articleId, string token)
        {
            return _articleRepository.EstBloquer(articleId, token);
        }

        #endregion
    }
}
