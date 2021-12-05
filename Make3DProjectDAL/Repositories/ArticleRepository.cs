using Make3DProjectDAL.Entities;
using Make3DProjectDAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectDAL.Repositories
{
    public class ArticleRepository : AbstractRepository, IArticleRepository
    {
        

        #region Récupération

        public IEnumerable<ArticleEntity> GetAll(string token)
        {
            setClient(token);

            using (HttpResponseMessage message = _client.GetAsync("Article/GetAll").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<ArticleEntity>>(json);
            }
        }

        public IEnumerable<ArticleEntity> GetAllByUserId(int id, string token)
        {
            setClient(token);

            using (HttpResponseMessage message = _client.GetAsync("Article/GetAllByUser/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<ArticleEntity>>(json);
            }
        }

        public ArticleEntity GetById(int id, string token)
        {
            setClient(token);

            using (HttpResponseMessage message = _client.GetAsync($"Article/{id}/Detail").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ArticleEntity>(json);
            }
        }

        #endregion

        #region Signalement

        public void Designaler(int articleId, string token)
        {
            setClient(token);

            using (HttpResponseMessage message = _client.PutAsync($"Article/{articleId}/DesignalerAdmin", null).Result)
            {
                if (!message.IsSuccessStatusCode)
                    throw new HttpRequestException();
            }

        }

        public bool EstSignale(int articleId, string token)
        {
            setClient(token);
            using (HttpResponseMessage message = _client.GetAsync($"Article/{articleId}/EstSignale").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<bool>(json);
            }
        }

        public bool EstSignaleParUserId(int articleId, int signaleurId, string token)
        {
            setClient(token);
            using (HttpResponseMessage message = _client.GetAsync($"Article/{articleId}/EstSignaleParUserId/{signaleurId}").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<bool>(json);
            }
        }

        #endregion

        #region Bloquage

        public void Bloquer(int articleId, string motivation, string token)
        {
            setClient(token);

            string jsonBody = JsonConvert.SerializeObject(new { motivation = motivation });
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = _client.PostAsync($"Article/{articleId}/Bloquer", content).Result)
            {
                if (!message.IsSuccessStatusCode)
                    throw new HttpRequestException();
            }
        }

        public void Debloquer(int articleId, string token)
        {
            setClient(token);
            using (HttpResponseMessage message = _client.GetAsync($"Article/{articleId}/Debloquer").Result)
            {
                if (!message.IsSuccessStatusCode)
                    throw new HttpRequestException();
            }
        }

        public bool EstBloquer(int articleId, string token)
        {
            setClient(token);
            using (HttpResponseMessage message = _client.GetAsync($"Article/{articleId}/EstBloquer").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<bool>(json);
            }
        }

        #endregion
    }
}
