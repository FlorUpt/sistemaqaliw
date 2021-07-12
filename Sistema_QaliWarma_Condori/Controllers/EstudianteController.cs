using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_QaliWarma_Condori.Models;

namespace Sistema_QaliWarma_Condori.Controllers
{
    public class EstudianteController : Controller
    {
        private Estudiante objEstudiante = new Estudiante();

        // GET: Estudiante
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objEstudiante.Listar());
            }
            else
            {
                return View(objEstudiante.Buscar(criterio));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objEstudiante.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Estudiante() // Agregarmos un nuevo objeto
                : objEstudiante.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(Estudiante objEstudiante)
        {
            if (ModelState.IsValid)
            {
                objEstudiante.Guardar();
                return Redirect("~/Estudiante");
            }
            else
            {
                return View("~/Views/Estudiante/AgregarEditar.cshtml", objEstudiante);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objEstudiante.estudiante_id = id;
            objEstudiante.Eliminar();
            return Redirect("~/Estudiante");
        }
    }
}