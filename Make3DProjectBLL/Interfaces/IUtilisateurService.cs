using Make3DProjectBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectBLL.Interfaces
{
    public interface IUtilisateurService
    {
        UserConnectedModel Login(string email, string password);
    }
}
