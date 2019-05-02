using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Catec.Models;


namespace Catec.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Inicio()
        {
           
            return View();
        }


        public IActionResult Login(int? id)
        {
            if(id != null)
            {
                //Realizar logout
                if(id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("CatequistaLogado", string.Empty);
                    HttpContext.Session.SetString("PerfilLogado", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel usuario)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = usuario.ValidarLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUsuarioLogodo", usuario.IdCatequista);
                    HttpContext.Session.SetString("CatequistaLogado", usuario.Catequista);
                    HttpContext.Session.SetString("PerfilLogado", usuario.Perfil);
                    return RedirectToAction("Inicio", "Home");
                }
            }
            else
            {
                TempData["ErrorLogin"] = "E-mail ou Senha são inválidos!";
            }

            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
