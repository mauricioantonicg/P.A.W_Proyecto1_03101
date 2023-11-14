using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_Datos
{
   public class CNX_Herramienta
   {

      //Consultar cantidad de herramientas en la base de datos
      public string CantidadherramientasEnBD() { 

         string cantidadHerramientas = string.Empty;

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //String a ejecutar en la base de datos 
               string query = "select count(*) as cantidad from herramienta";

               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand(query, conexionBD);
               cmd.CommandType = CommandType.Text;

               //Abrir conexion con la base de datos
               conexionBD.Open();

               //Ejecutar o enviar el script a la base de datos con la consulta 
               //Ejecutar o enviar el script a la base de datos con la consulta 
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     //Leer la respuesta de la base de datos
                     cantidadHerramientas = reader["cantidad"].ToString();                  
                  }                                   
               }
            }
         }
         catch (Exception)
         {

            cantidadHerramientas = "-1";
         }

         //Retornar la cantidad de herramientas

         return cantidadHerramientas;
      }

      //Registrar una nueva herramienta en la tabla persona de la base de datos  
      public int RegistrarHerramienta(herramienta herramient, out string Mensaje)
      {
         int resultado = 0;
         Mensaje = string.Empty;

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand("sp_RegistrarHerramienta", conexionBD);
               //Datos de la persona 
               cmd.Parameters.AddWithValue("idHerramienta", herramient.idHerramienta);
               cmd.Parameters.AddWithValue("nombreHerramienta", herramient.nombreHerramienta);
               cmd.Parameters.AddWithValue("descripcionHerramienta", herramient.descripcionHerramienta);
               cmd.Parameters.AddWithValue("cantidHerramienta", herramient.cantidHerramienta);
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

      //Obtener datos de una herramienta
      public List<herramienta> BuscarHerramientaBD(string nombreHerramienta)
      {

         List<herramienta> listaHerramientas = new List<herramienta>();

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //String a ejecutar en la base de datos 
               string query = "select idHerramienta, nombreHerramienta, cantidHerramienta from herramienta where nombreHerramienta  = '" + nombreHerramienta + "'";

               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand(query, conexionBD);
               cmd.CommandType = CommandType.Text;

               //Abrir conexion con la base de datos
               conexionBD.Open();
               
               //Ejecutar o enviar el script a la base de datos con la consulta 
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     //Leer la respuesta de la base de datos
                     //Crear objeto persona y agregarlo a la lista de personas 
                     listaHerramientas.Add(new herramienta()
                     {
                        idHerramienta = Convert.ToInt32(reader["idHerramienta"].ToString()),
                        nombreHerramienta = reader["nombreHerramienta"].ToString(),
                        cantidHerramienta = Convert.ToInt32(reader["cantidHerramienta"].ToString())
                     });
                  }
               }
            }
         }
         catch (Exception)
         {
            listaHerramientas = new List<herramienta>();
         }

         //Retornar la cantidad de herramientas
         return listaHerramientas;
      }
   }
}

