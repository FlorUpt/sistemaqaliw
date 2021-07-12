using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_QaliWarma_Condori.Models;

namespace Sistema_QaliWarma_Condori.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario objUsuario = new Usuario();
       
        // GET: Usuario
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Usuario() // Agregarmos un nuevo objeto
                : objUsuario.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {
                objUsuario.Guardar();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml", objUsuario);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objUsuario.usuario_id = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}