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
      public int DevolucionHerramienta(int idPersona, out string Mensaje)
      {
         Mensaje = string.Empty;
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
            Mensaje = ex.Message;   
         }

         return Resultado;
      }

      //Consultar y obtener usuario y herramienta prestada
      public List<devolucionHerramienta> ConsHerramPrestPersBD(int idPersona) {
         //Almacenar la lista de personas y herramientas prestadas
         List<devolucionHerramienta> listaPersonasYHerramPrestBD = new List<devolucionHerramienta>();

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //String a ejecutar en la base de datos 
               string query = "select idPerso, nombrePersona, apellido1, apellido2, devolucionHerramienta.idHerramienta, " +
                  "nombreHerramienta, fechaPrestamoHerramienta, fechaDevoluHerramienta from devolucionHerramienta " +
                  "inner join persona on persona.idPersona = devolucionHerramienta.idPerso " +
                  "inner join herramienta on herramienta.idHerramienta = devolucionHerramienta.idHerramienta " +
                  "inner join prestamoHerramienta on prestamoHerramienta.idHerramient = devolucionHerramienta.idHerramienta " +
                  "where idPerso = "+ idPersona + " and estadoDevolucionHerramienta = 1";

               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand(query, conexionBD);
               cmd.CommandType = CommandType.Text;

               //Abrir conexion con la base de datos
               conexionBD.Open();

               //Ejecutar o enviar el script a la base de datos con la consulta 
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                  //Leer la respuesta de la base de datos
                  while (reader.Read())
                  {
                     //Crear objeto persona y agregarlo a la lista de personas 
                     listaPersonasYHerramPrestBD.Add(new devolucionHerramienta()
                     {
                        idPersonaa = Convert.ToInt32(reader["idPerso"]),
                        nombrePersona = reader["nombrePersona"].ToString() + " " + reader["apellido1"].ToString() + " " + reader["apellido2"].ToString(),
                        idHerramientaa = Convert.ToInt32(reader["idHerramienta"].ToString()),
                        nombreHerramienta = reader["nombreHerramienta"].ToString(),
                        fechaDePrestamoHerramienta = string.Format("{0:dd-MM-yyyy}", reader["fechaPrestamoHerramienta"]),
                        fechaDevolucionHerramienta = string.Format("{0:dd-MM-yyyy}", reader["fechaDevoluHerramienta"])
                     });
                  }
               }

            }
         }
         catch (Exception)
         {

            listaPersonasYHerramPrestBD = new List<devolucionHerramienta>();
         }

         //Retornar la lista 
         return listaPersonasYHerramPrestBD;
      }
   }
}
