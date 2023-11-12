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

               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     listaUsuariosBD.Add(new persona() {
                        idPersona = Convert.ToInt32(reader[idPersona]),
                        nombrePersona = reader[nombrePersona].ToString(),
                     //this.apellido1 = apellido1;
                     //this.apellido2 = apellido2;
                     //this.fechaRegistro = fechaRegistro;
                     //this.estadoPersona = estadoPersona;
                  });
               }
            }

         }
         }
         catch (Exception)
         {

            throw;
         }





         return listaUsuariosBD;
      
      } 

      
      

   }
}
