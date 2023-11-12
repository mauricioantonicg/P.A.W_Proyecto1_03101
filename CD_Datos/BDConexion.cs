using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CD_Datos
{
   public class BDConexion
   {
      public static string conexionBD = ConfigurationManager.ConnectionStrings["DBConexion"].ToString();
   }
}
