using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CE_Entidad;
using CN_Negocio;

namespace CP_Control_Herramientas.Controllers
{
   public class HomeController : Controller
   {
      //Pagina de inicio 
      public ActionResult Index()
      {
         return View();
      }

      //Devuelve la vista ingresar nuevo coloborador
      public ActionResult Ingres_Nuev_Colab()
      {
         return View();
      }

      //Devuelve la vista ingresar nueva herramienta
      public ActionResult Ingres_Nuev_Herram()
      {
         return View();
      }

      //Devuelve la vista prestar herramienta 
      public ActionResult Prestar_Herram()
      {
         return View();
      }

      //Devuelve la vista recibir herramienta 
      public ActionResult Recibir_Herram()
      {
         return View();
      }

      //Consultar lista de personas de la base de datos y retornarla como un archivo Json 
      public JsonResult ListaUsuarios()
      {
         List<persona> listaPersonas = new List<persona>();

         listaPersonas = new CNX_ET_Persona().listaUsuarios();

         return Json(listaPersonas, JsonRequestBehavior.AllowGet);
      }

      //Consultar lista de personas de la base de datos y retornarla como un archivo Json 
      [HttpGet]
      public JsonResult BuscarUsuario(int idUsuario)
      {
         List<persona> listaPersonas = new List<persona>();

         listaPersonas = new CNX_ET_PrestamoHerramienta().listaPersonaPrestHerram(idUsuario);

         return Json(listaPersonas, JsonRequestBehavior.AllowGet);
      }


      //Registrar persona en base de datos
      [HttpPost]
      public JsonResult GuardarUsuario(persona person)
      {

         object resultado;
         string mensaje = string.Empty;


         resultado = new CNX_ET_Persona().RegistrarPersonaBD(person, out mensaje);



         return Json(new { resultado = resultado, mensage = mensaje }, JsonRequestBehavior.AllowGet);
      }

      //Consultar siguiente id de la herramienta 
      [HttpGet]
      public string SiguienteIdHerramienta()
      {
         string cantidadHerramientas;

         cantidadHerramientas = new CNX_ET_Herramienta().CantidadHerramientasBD();

         return cantidadHerramientas;
      }

      //Consultar lista de herramientas y obtener una herramienta por nombre 
      [HttpGet]
      public JsonResult BuscarHerramienta(string nombreHerramienta)
      {

         List<herramienta> listaHerramienta = new List<herramienta>();

         listaHerramienta = new CNX_ET_Herramienta().BuscarHerramienta(nombreHerramienta);

         return Json(listaHerramienta, JsonRequestBehavior.AllowGet);
      }

      //Registrar herramienta en base de datos
      [HttpPost]
      public JsonResult GuardarHerramienta(herramienta herramient)
      {
         object resultado;
         string mensaje = string.Empty;

         resultado = new CNX_ET_Herramienta().RegistrarHerramientaBD(herramient, out mensaje);

         return Json(new { resultado = resultado, mensage = mensaje }, JsonRequestBehavior.AllowGet);
      }

      //Registrar herramienta en base de datos
      [HttpPost]
      public JsonResult GuardarRegPrestaHerramienta(prestamoHerramienta prestamoHerramient)
      {
         object resultado;
         string mensaje = string.Empty;

         resultado = new CNX_ET_PrestamoHerramienta().RegistrarPrestamoHerramientaBD(prestamoHerramient, out mensaje);

         return Json(new { resultado = resultado, mensage = mensaje }, JsonRequestBehavior.AllowGet);
      }      
   }
}