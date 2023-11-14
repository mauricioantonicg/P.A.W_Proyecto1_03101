using CD_Datos;
using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Negocio
{
   public class CNX_ET_PrestamoHerramienta
   {
      //Crear instancia de la clase prestamo herramientas
      private CNX_PrestamoHerramienta objPersonaPrestHerram = new CNX_PrestamoHerramienta();

      public List<persona> listaPersonaPrestHerram(int idPersona)
      {
         return objPersonaPrestHerram.listaPersonasHerram(idPersona);
      }

      //Registrar prestamo de herramienta en base de datos
      public int RegistrarPrestamoHerramientaBD(prestamoHerramienta prestamoHerramienta, out string Mensaje)
      {
         Mensaje = string.Empty;

         //Validacion de campos en el servidor 
         if (string.IsNullOrEmpty(prestamoHerramienta.idPerson.ToString()) || string.IsNullOrWhiteSpace(prestamoHerramienta.idPerson.ToString()))
         {
            Mensaje = "Ingrese la cedula de la persona";
         }
         else if (string.IsNullOrEmpty(prestamoHerramienta.idHerramient.ToString()) || string.IsNullOrWhiteSpace(prestamoHerramienta.idHerramient.ToString()))
         {
            Mensaje = "Ingrese el id de la herramienta";
         }
         else if (string.IsNullOrEmpty(prestamoHerramienta.fechaPrestamoHerramienta.ToString()) || string.IsNullOrWhiteSpace(prestamoHerramienta.idPerson.ToString()))
         {
            Mensaje = "Problemas con la fecha de registro de prestamo de la herramienta";
         }
         else if (string.IsNullOrEmpty(prestamoHerramienta.fechaDevoluHerramienta.ToString()) || string.IsNullOrWhiteSpace(prestamoHerramienta.fechaDevoluHerramienta.ToString()))
         {
            Mensaje = "Problemas con la fecha de devolucion del prestamo de la herramienta";
         }


         if (string.IsNullOrEmpty(Mensaje))
         {
            return objPersonaPrestHerram.RegistrarPrestamoHerramienta(prestamoHerramienta, out Mensaje);
         }
         else
         {
            return 0;
         }
      }
   }
}
