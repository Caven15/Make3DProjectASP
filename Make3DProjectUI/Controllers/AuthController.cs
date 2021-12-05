using Make3DProjectBLL.Interfaces;
using Make3DProjectBLL.Models;
using Make3DProjectUI.Infrastructure;
using Make3DProjectUI.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Make3DProjectUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUtilisateurService _utilisateurService;
        private readonly ISessionManager _sessionManager;

        public AuthController(IUtilisateurService utilisateurService, ISessionManager sessionManager)
        {
            _utilisateurService = utilisateurService;
            _sessionManager = sessionManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            try
            {
                UserConnectedModel utilisateur = _utilisateurService.Login(form.Email, form.Password);
                if (utilisateur is not null)
                {
                    _sessionManager.CurrentUser = utilisateur;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch(Exception e)
            {  }
            ModelState.AddModelError("", "vos identifiants sont incorects...");
            return View(form);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _sessionManager.ClearUser();
            return RedirectToAction("Index", "Home");
        }
    }
}
