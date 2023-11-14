using CE_Entidad;
using CD_Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_Datos
{
   public class CNX_PrestamoHerramienta
   {
      //Traer la lista de personas y herramientas prestadas  
      public List<persona> listaPersonasHerram( int idPersona)
      {

         //Almacenar la lista de personas y herramientas prestadas
         List<persona> listaPersonasHerramBD = new List<persona>();

         //Instancia de la clase prestamo de herramientas 
         //prestamoHerramienta prestamoHerramient = new prestamoHerramienta();

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //String a ejecutar en la base de datos 
               string query = "select idPersona, nombrePersona, apellido1, apellido2 from prestamoHerramienta " +
                              "inner join persona on persona.idPersona = idPerson " +
                              "where idPerson = " + idPersona + " and estadoPrestamoHerramienta = 1";

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
                     listaPersonasHerramBD.Add(new persona()
                     {
                        idPersona = Convert.ToInt32(reader["idPersona"]),
                        nombrePersona = reader["nombrePersona"].ToString(),
                        apellido1 = reader["apellido1"].ToString(),
                        apellido2 = reader["apellido2"].ToString()
                     });
                  }
               }

            }
         }
         catch (Exception)
         {

            listaPersonasHerramBD = new List<persona>();
         }

         //Retornar la lista 
         return listaPersonasHerramBD;
      }

      //Registrar prestamo de herramienta
      public int RegistrarPrestamoHerramienta(prestamoHerramienta prestamoHerramient, out string Mensaje)
      {
         int resultado = 0;
         Mensaje = string.Empty;

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand("sp_RegistrarPrestamoHerramienta", conexionBD);
               //Datos de la persona 
               cmd.Parameters.AddWithValue("idPerson", prestamoHerramient.idPerson);
               cmd.Parameters.AddWithValue("idHerramient", prestamoHerramient.idHerramient);
               cmd.Parameters.AddWithValue("fechaPrestamoHerramienta", string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(prestamoHerramient.fechaPrestamoHerramienta)));
               cmd.Parameters.AddWithValue("fechaDevoluHerramienta", string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(prestamoHerramient.fechaDevoluHerramienta)));
               cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.CommandType = CommandType.StoredProcedure;

               //Abrir conexion con la base de datos
               conexionBD.Open();

               //Ejecutar o enviar el script a la base de datos con la consulta 
               cmd.ExecuteReader();

               resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
               Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
         }
         catch (Exception ex)
         {
            resultado = 0;
            Mensaje = ex.Message;
         }

         //Retornar si se guardo el registro correctamente 
         return resultado;
      }
   }
}
