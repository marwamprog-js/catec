using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catec.Controllers
{
    public class ComunidadeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaComunidade = new ComunidadeModel().ListarTodasComunidades();
            return View();
        }
    }
}