using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistroSeccion.Models;
namespace RegistroSeccion.Controllers
{
    public class SeccionController : Controller
    {
        private Seccion sec = new Seccion();
        //--------------------------------------INDEX -------------------------------------------
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar Nueva Seccion";
            return View(sec.listar());
        }

        [HttpPost] // -- Inserta un Seccion
        public ActionResult Index(string nu, bool es, string fe, int cu)
        {
            if (sec.Insertar(nu, es, fe, cu, l_indices))
            {
                ViewBag.alerta = "success";
                ViewBag.res = "Seccion Registrado";
            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Seccion No Registrado";
            }
            return View(sec.listar());
        }


        private static List<string> l_indices = new List<string>();
        private static List<string> l_alumnos = new List<string>();

        //--------busqueda de alumno
        [HttpPost]
        public String bus_atr(string dato_bus)
        {
            string res = "";
            var alumnos = new List<Alumno>();
            alumnos = sec.bus_atr(dato_bus);
            foreach (var a in alumnos)
            {
                int id = a.id_alu;
                string dni = a.dni_alu;
                string nom = a.nombre_alu;
                string ape = a.apellidos_alu;
                string boton_sel = "<button class=\"btn btn-warning\" type='button'"
                    + " onclick=\"agr_atr('" + id + "','" + dni + "','" + nom + "','" + ape + "')\""
                    + " data-dismiss='modal'><span class=\"glyphicon glyphicon-check\"> Añadir</span></button>";
                res = res +
                    "<tr><td>" + id + "</td>"
                    + "<td>" + dni + "</td>"
                    + "<td>" + nom + "</td>"
                    + "<td>" + ape + "</td>"
                    + "<td>" + boton_sel + "</td></tr>";
            }
            return res;
        }
        //------------Agregar Alumno 
        public String agr_atr(string id, string dni, string nom, string ape)
        {
            string res = "";
            int cont = 0;
            foreach (var w in l_indices)
            {
                if (w.Equals(id))
                {
                    cont++;
                }
            }
            if (cont == 0)
            {
                if (l_alumnos.Count < 8)
                {
                    string boton_bor = "<button class=\"btn btn-danger\" type='button'"
                        + " onclick=\"bor_atr('" + id + "')\""
                        + "><span class=\"glyphicon glyphicon-trash\"> Borrar</span></button>"; //--Esta variable boton_bor representa un boton
                    l_alumnos.Add(
                        "<tr><td>" + id + "</td>"
                        + "<td>" + dni + "</td>"
                        + "<td>" + nom + "</td>"
                        + "<td>" + ape + "</td>"
                        + "<td>" + boton_bor + "</td></tr>"
                        );
                    l_indices.Add(id);
                }
            }
            foreach (var a in l_alumnos)
            {
                res = res + a;
            }
            return res;
        }

        //--------------Limpieza--------------------
        [HttpPost]
        public void limpiar_atr()
        {
            l_alumnos.Clear();
            l_indices.Clear();
        }
        //-------------- Borrar Alumno de Lista -----------
        public String bor_atr(string id)
        {
            string res = "";
            l_alumnos.RemoveAt(l_indices.IndexOf(id));
            l_indices.RemoveAt(l_indices.IndexOf(id));
            foreach (var a in l_alumnos)
            {
                res = res + a;
            }
            return res;
        }
    }
}