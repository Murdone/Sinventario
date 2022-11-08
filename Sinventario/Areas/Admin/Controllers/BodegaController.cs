using Microsoft.AspNetCore.Mvc;
using SInventario.AccesoDatos.Repositorio.IRepositorio;

namespace Sinventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodegaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo; //unidad de trabajo
        public BodegaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Api
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Bodega.ObtenerTodos();
            return Json(new {data = _unidadTrabajo});
        }
        #endregion
    }
}
