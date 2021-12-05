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
    public class UtilisateurRepository : AbstractRepository, IUtilisateurRepository
    {
        public UserConnectedEntity Login(string email, string password)
        {
           setClient();

            string jsonBody = JsonConvert.SerializeObject(new { email = email, password = password });
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using (HttpResponseMessage message = _client.PostAsync("Auth/LoginAdmin", content).Result)
            {
                if (!message.IsSuccessStatusCode)
                    throw new HttpRequestException();

                string json = message.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<UserConnectedEntity>(json);
            }
        }
    }
}
