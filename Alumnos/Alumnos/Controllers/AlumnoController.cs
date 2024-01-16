using Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        private Alumno alu = new Alumno();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar Nuevo Alumno";
            return View(alu.listar());
        }
        [HttpPost]
        public ActionResult Index(string dni, string nom, string ape)
        {
            if (alu.Insertar(dni, nom, ape))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Alumno Registrado";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Alumno no Registrado";
            }
            return View(alu.listar());
        }
        public ActionResult Editar(int id)
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Actualizar Alumno";
            return View(alu.un_registro(id));
        }
        [HttpPost]
        public ActionResult Editar(int id, string nom, string ape, string dni)
        {
            if (alu.Actualizar(id, nom, ape, dni))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Datos del alumno actualizados";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Ocurrio un error :( ";
            }
            return View(alu.un_registro(id));
        }
        public ActionResult Eliminar(int id)
        {
            if (alu.Eliminar(id))
            {
                return RedirectToAction("Index", "Alumno");
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "El alumno se encuentra en una sección";
                return View(alu.un_registro(id));
            }
        }
    }
}