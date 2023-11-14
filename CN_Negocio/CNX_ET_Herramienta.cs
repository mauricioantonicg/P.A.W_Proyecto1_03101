using CD_Datos;
using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Negocio
{  
   public class CNX_ET_Herramienta
   {
      //Crear instancia de la clase herramienta 
      private CNX_Herramienta objHerramienta = new CNX_Herramienta();

      //Consultar cantidad de herramientas
      public string CantidadHerramientasBD()
      {
         int cant;
         string cantidadHerramientas;

         cant = Convert.ToInt32(objHerramienta.CantidadherramientasEnBD()) + 1;

         cantidadHerramientas = cant.ToString();

         return cantidadHerramientas;
      }

      //Registrar nueva herramienta en la base de datos 
      public int RegistrarHerramientaBD(herramienta herramient, out string Mensaje)
      {
         Mensaje = string.Empty;

         //Validacion de campos en el servidor 
         if (string.IsNullOrEmpty(herramient.idHerramienta.ToString()) || string.IsNullOrWhiteSpace(herramient.idHerramienta.ToString()))
         {
            Mensaje = "Ingrese el id de la herramienta";
         }
         else if (string.IsNullOrEmpty(herramient.nombreHerramienta) || string.IsNullOrWhiteSpace(herramient.nombreHerramienta))
         {
            Mensaje = "Ingrese el nombre de la herramienta";
         }
         else if (string.IsNullOrEmpty(herramient.descripcionHerramienta) || string.IsNullOrWhiteSpace(herramient.descripcionHerramienta))
         {
            Mensaje = "Ingrese la descripcion de la herramienta";
         }
         else if (string.IsNullOrEmpty(herramient.cantidHerramienta.ToString()) || string.IsNullOrWhiteSpace(herramient.cantidHerramienta.ToString()))
         {
            Mensaje = "Ingrese la cantidad de herramientas";
         }
         

         if (string.IsNullOrEmpty(Mensaje))
         {
            return objHerramienta.RegistrarHerramienta(herramient, out Mensaje);
         }
         else
         {
            return 0;
         }
      }

      //Consultar y obtener un objeto herramienta 
      public List<herramienta> BuscarHerramienta(string nombreHerramienta)
      {
         return objHerramienta.BuscarHerramientaBD(nombreHerramienta);
      }
   }   
}
