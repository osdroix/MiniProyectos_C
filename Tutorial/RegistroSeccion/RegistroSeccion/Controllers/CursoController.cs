using RegistroSeccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroSeccion.Controllers
{
    public class CursoController : Controller
    {
        private Curso cur = new Curso();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar Cursos";
            return View(cur.listar());
        }
        [HttpPost]
        public ActionResult Index(string des, bool est)
        {
            if (cur.Insertar(des, est))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "El curso se registro correctamente";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Hubo un problema al registrar el curso";
            }
            return View(cur.listar());
        }
        public ActionResult Editar(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Actualizar Curso";
            return View(cur.un_registro(id));
        }
        [HttpPost]
        public ActionResult Editar(int id, string des, bool est)
        {
            if (cur.Actualizar(id, des, est))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "El curso se actualizo correctamente";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Ocurrio un error al actualizar los datos del curso :( ";
            }
            return View(cur.un_registro(id));
        }

        public ActionResult Eliminar(int id)
        {
            if (cur.Eliminar(id))
            {
                return RedirectToAction("Index", "Curso");
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Ocurrio un error al eliminar el curso";
                return View(cur.un_registro(id));
            }
        }
    }
}