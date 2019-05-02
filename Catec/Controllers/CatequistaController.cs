using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catec.Controllers
{
    public class CatequistaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaCatequista = new CatequistaModel().ListarTodosCatequistas();

            return View();
        }

       
    }
}