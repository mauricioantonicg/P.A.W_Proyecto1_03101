using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Entidad
{
   public class devolucionHerramienta
   {
      public int idPersonaa { get; set; }
      public string nombrePersona { get; set; }
      public int idHerramientaa { get; set; }
      public string nombreHerramienta { get; set; }
      public int cantHerramientasPrestadas { get; set; }
      public string fechaDePrestamoHerramienta { get; set; }
      public string fechaDevolucionHerramienta { get; set; }
      public bool estadoDevolucionHerramienta { get; set; }
      public string detallesDevolucionHerramienta { get; set; }
   }
}
