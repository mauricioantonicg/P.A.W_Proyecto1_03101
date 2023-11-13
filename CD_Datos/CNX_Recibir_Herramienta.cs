using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_Datos
{
   public class CNX_Recibir_Herramienta
   {
      //Instancia de la clase Recibir herramienta
      public int DevolucionHerramienta(int idPersona, out string  Mensage)
      {
         Mensage = string.Empty;
         int Resultado = 0;

         try
         {
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               SqlCommand cmd = new SqlCommand("delete top (1) from persona where idPersona = @idPersona", conexionBD);
               cmd.Parameters.AddWithValue("@idPersona", idPersona);
               cmd.CommandType = CommandType.Text; 
               conexionBD.Open();
               Resultado = cmd.ExecuteNonQuery() > 0 ? 1 : 0;
            }

         }
         catch (Exception ex)
         {
            Resultado = 0;
            Mensage = ex.Message;   
         }

         return Resultado;
      }
   }
}
