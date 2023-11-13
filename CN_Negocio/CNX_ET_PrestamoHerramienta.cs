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
   }
}
