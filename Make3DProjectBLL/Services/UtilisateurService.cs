using Make3DProjectBLL.Interfaces;
using Make3DProjectBLL.Mapper;
using Make3DProjectBLL.Models;
using Make3DProjectDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make3DProjectBLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public UserConnectedModel Login(string email, string password)
        {
            return _utilisateurRepository.Login(email, password)?.DalToBll();
        }
    }
}
