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
   }
}
