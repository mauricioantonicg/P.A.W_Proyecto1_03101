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

      //Consultar lista de personas de la base de datos 
      public JsonResult ListaUsuarios()
      {
         List<persona> listaPersonas = new List<persona>();

         listaPersonas = new CNX_ET_Persona().listaUsuarios();

         return Json(listaPersonas, JsonRequestBehavior.AllowGet);
      }

   }
}