using PracticaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticaMVC.Controllers
{
    public class EquiposController : Controller
    {

        private readonly equiposDbContext _equiposDBContext;
        public EquiposController(equiposDbContext equiposDBContext)
        {
            _equiposDBContext = equiposDBContext;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDBContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listaDeEquipos = (from e in _equiposDBContext.equipos
                                  join m in _equiposDBContext.marcas on e.id_marcas equals m.id_marcas
                                  select new
                                  {
                                      nombre = e.nombre,
                                      descripcion = e.descripcion,
                                      nombre_marca = m.nombre_marca,
                                  }).ToList(); 
            ViewData["listadoDeEquipos"] = listaDeEquipos;
            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDBContext.Add(nuevoEquipo);
            _equiposDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
