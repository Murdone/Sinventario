using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SInventario.AccesoDatos;
using SInventario.Utilidades;
using System;
using System.Data;
using System.Linq;

namespace Sinventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Ds.Role_Admin)]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var usuarioLista = _db.UsuarioAplicacions.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var usuario in usuarioLista)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == usuario.Id).RoleId;
                usuario.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }

            return Json(new { data = usuarioLista });
        }


        [HttpPost]
        public IActionResult BloquearDesbloquear([FromBody] string id)
        {
            var usuario = _db.UsuarioAplicacions.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return Json(new { success = false, message = "Error de Usuario" });
            }

            if (usuario.LockoutEnd != null && usuario.LockoutEnd > DateTime.Now)
            {
                // Usuario Bloqueado
                usuario.LockoutEnd = DateTime.Now;
            }
            else
            {
                usuario.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Operacion Exitosa" });

        }

        #endregion
    }
}
