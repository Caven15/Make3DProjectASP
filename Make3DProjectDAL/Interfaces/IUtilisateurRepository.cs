using Make3DProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectDAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        UserConnectedEntity Login(string email, string password);

    }
}
