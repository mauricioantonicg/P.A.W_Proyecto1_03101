using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Entidad
{
   public class prestamoHerramienta
   {
      public persona oPersona { get; set; }
      public herramienta oHerramienta { get; set; }
      public DateTime fechaPrestamoHerramienta { get; set; }
      public DateTime fechaDevoluHerramienta { get; set; }
      public bool estadoPrestamoHerramienta { get; set; }

   }


}
