using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectDAL.Repositories
{
    public abstract class AbstractRepository
    {
        protected string _url = "https://localhost:44334/api/";
        protected HttpClient _client;

        public AbstractRepository()
        {
            setClient();
        }

        public void setClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_url);
        }

        public void setClient(string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_url);
            // interception du token 
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            // syntaxe différente 
            // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);
        }
    }
}
