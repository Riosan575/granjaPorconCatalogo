using Catalogo.DB;
using Catalogo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IWebHostEnvironment hosting;
        private CatalogoContext context;

        public AdminController(CatalogoContext context, IWebHostEnvironment hosting)
        {
            this.hosting = hosting;
            this.context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Productos producto, List<IFormFile> files, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                producto.fecha = DateTime.Now;
                producto.imagenCaratula = SaveFile(img);
                context.Productos.Add(producto);
                context.SaveChanges();

                foreach (var item in files)
                {
                    Imagen ig = new Imagen()
                    {
                        idProductos = producto.id,
                        ruta = SaveFile(item)
                    };
                    context.Imagenes.Add(ig);
                }                
                context.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            return View(producto);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var lacteos = context.Productos.Find(id);
            context.Productos.Remove(lacteos);

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lacteos = context.Productos.Where(o => o.id == id).ToList();
            return View(lacteos);
        }
        public IActionResult EditPro(Productos lacteos, int id)
        {           
            var lac_db = context.Productos.Find(id);
            lac_db.nombre = lacteos.nombre;
            lac_db.descripcion = lacteos.descripcion;
            lac_db.precio = lacteos.precio;
            context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
        private string SaveFile(IFormFile item)
        {
            string relativePath = "";
            if (item.Length > 0)
            {
                relativePath = Path.Combine("files", item.FileName);
                var filePath = Path.Combine(hosting.WebRootPath, relativePath);
                var stream = new FileStream(filePath, FileMode.Create);
                item.CopyTo(stream);
                stream.Close();
            }
            return "/" + relativePath.Replace('\\', '/');
        }
    }
}
