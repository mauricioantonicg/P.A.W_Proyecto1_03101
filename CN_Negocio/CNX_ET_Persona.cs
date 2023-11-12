using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD_Datos;
using CE_Entidad;

namespace CN_Negocio
{
   public class CNX_ET_Persona
   {
      private CNX_Persona listaPersonas = new CNX_Persona();

      public List<persona> listaUsuarios() {
         return listaPersonas.listaUsuarios();
      }
   }
}
