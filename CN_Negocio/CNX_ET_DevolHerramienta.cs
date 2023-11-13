using CD_Datos;
using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Negocio
{
   public class CNX_ET_DevolHerramienta
   {

      //Instancia clase manejador devolucion de herramientas
      CNX_Recibir_Herramienta ObjDevlherramienta = new CNX_Recibir_Herramienta();
      public int DevolucionHerramienta(int idPersona, out string Mensage)
      {

         Mensage = string.Empty;

         Mensage = "";

         return ObjDevlherramienta.DevolucionHerramienta(idPersona, out Mensage);
      }
   }
}
