using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE_Entidad;

namespace CD_Datos
{
   public class CNX_Persona
   {
      //Traer la lista de personas de la tabla personas en la base de datos 
      public List<persona> listaUsuarios()
      {

         //Almacenar la lista de personas de la tabla personas en la base de datos
         List<persona> listaUsuariosBD = new List<persona>();

         try
         {
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               string query = "select * from persona";

               SqlCommand cmd = new SqlCommand(query, conexionBD);
               cmd.CommandType = CommandType.Text;

               conexionBD.Open();

               using (SqlDataReader reader = cmd.ExecuteReader() ) {
                  while (reader.Read()) {

                     listaUsuariosBD.Add(new persona() {
                        idPersona = Convert.ToInt32(reader["idPersona"]),
                        nombrePersona = reader["nombrePersona"].ToString(),
                        apellido1 = reader["apellido1"].ToString(),
                        apellido2 = reader["apellido2"].ToString(),
                        fechaRegistro = string.Format("{0:dd-MM-yyyy}", reader["fechaRegistro"]),
                        estadoPersona = Convert.ToBoolean(reader["estadoPersona"])
                     });
                  }
               }

            }
         }
         catch (Exception)
         {

            listaUsuariosBD = new List<persona>();
         }

         return listaUsuariosBD;      
      }         
   }
}
