using Make3DProjectBLL.Interfaces;
using Make3DProjectUI.Infrastructure;
using Make3DProjectUI.Mapper;
using Make3DProjectUI.Models;
using Make3DProjectUI.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Make3DProjectUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ISessionManager _sessionManager;

        public ArticleController(IArticleService articleService, ISessionManager sessionManager)
        {
            _articleService = articleService;
            _sessionManager = sessionManager;
        }

        public string Token
        {
            get
            {
                return _sessionManager.CurrentUser?.Token;
            }
        }

        public IActionResult Index()
        {
            IEnumerable<ArticleASPModel> articleASPModels = _articleService.GetAll(Token).Select(a => a.BllToAsp());
            return View(articleASPModels);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            try
            {
                ArticleASPModel articleASPModel = _articleService.GetById(id, Token)?.BllToAsp();
                if (articleASPModel is not null)
                {
                    return View(articleASPModel);
                }
            }
            catch (Exception e) { }

            return RedirectToAction("Index", "Article");
        }

        [HttpGet("Bloquer/{id}")]
        public IActionResult Bloquer(int id)
        {
            try
            {
                ArticleASPModel articleASPModel = _articleService.GetById(id, Token)?.BllToAsp();
                if (articleASPModel is not null)
                {
                    MotivationForm form = new MotivationForm
                    {
                        Article = articleASPModel
                    };
                    return View(form);
                }
            }
            catch (Exception e) { }

            return RedirectToAction("Index", "Article");
            
        }

        [HttpPost("Bloquer/{id}")]
        public IActionResult Bloquer(int id, MotivationForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            _articleService.Bloquer(id, form.Motivation,Token);
            return RedirectToAction("Index", "Article");
        }

        [HttpGet("Debloquer/{id}")]
        public IActionResult Debloquer(int id)
        {
            try
            {
                ArticleASPModel articleASPModel = _articleService.GetById(id, Token)?.BllToAsp();
                if (articleASPModel is not null)
                {
                    return View(articleASPModel);
                }
            }
            catch (Exception e) { }

            return RedirectToAction("Index", "Article");
        }

        [HttpPost("Debloquer/{id}")]
        public IActionResult Debloquer(int id, IFormCollection form)
        {
            _articleService.Debloquer(id, Token);
            return RedirectToAction("Index", "Article");
        }

        [HttpGet("Designaler/{id}")]
        public IActionResult Designaler(int id)
        {
            try
            {
                ArticleASPModel articleASPModel = _articleService.GetById(id, Token)?.BllToAsp();
                if (articleASPModel is not null)
                {
                    return View(articleASPModel);
                }
            }
            catch (Exception e) { }

            return RedirectToAction("Index", "Article");
        }

        [HttpPost("Designaler/{id}")]
        public IActionResult Designaler(int id, IFormCollection form)
        {
            _articleService.Designaler(id, Token);
            return RedirectToAction("Index", "Article");
        }
    }
}
