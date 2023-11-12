using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Entidad
{
   public class devolucionHerramienta
   {
      public persona oPersona { get; set; }
      public herramienta oHerramienta { get; set; }
      public DateTime fechaDevolucionHerramienta { get; set; }
      public bool estadoDevolucionHerramienta { get; set; }
      public string detallesDevolucionHerramienta { get; set; }
   }
}
