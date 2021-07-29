using Catalogo.DB;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Controllers
{
    public class HomeController : Controller
    {
        private CatalogoContext context;

        public HomeController(CatalogoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var productos = context.Productos.OrderByDescending(o => o.fecha).ToList();
            ViewBag.imagen = context.Imagenes.ToList();
            return View(productos);
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
