using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catec.Controllers
{
    public class CatequisandoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaCatequisando = new CatequisandoModel().ListarTodosCatequisando();
            return View();
        }
    }
}