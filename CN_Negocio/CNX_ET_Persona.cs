using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CD_Datos;
using CE_Entidad;

namespace CN_Negocio
{
   public class CNX_ET_Persona
   {
      //Llamar los metodos disponibles en el CRUD de la clase conexion a tabla persona (CNX_Persona) 

      //Crear instancia de la clase persona 
      private CNX_Persona listaPersonas = new CNX_Persona();

      //Crear instancia de la clase persona 
      private CNX_Persona objPersona = new CNX_Persona();

      //Solicitar la lista de personas registradas en la base de datos
      public List<persona> listaUsuarios()
      {
         return listaPersonas.listaUsuarios();
      }

      //Registrar nuevo usuario en la base de datos 
      public int RegistrarPersonaBD(persona person, out string Mensaje)
      {
         Mensaje = string.Empty;

         //Validacion de campos en el servidor 
         if (string.IsNullOrEmpty(person.idPersona.ToString()) || string.IsNullOrWhiteSpace(person.idPersona.ToString())) {
            Mensaje = "Ingrese la cedula de la persona";
         }
         else if (string.IsNullOrEmpty(person.nombrePersona) || string.IsNullOrWhiteSpace(person.nombrePersona))
         {
            Mensaje = "Ingrese el nombre de la persona";
         }
         else if (string.IsNullOrEmpty(person.apellido1) || string.IsNullOrWhiteSpace(person.apellido1))
         {
            Mensaje = "Ingrese el primer apellido de la persona";
         }
         else if (string.IsNullOrEmpty(person.apellido2) || string.IsNullOrWhiteSpace(person.apellido2))
         {
            Mensaje = "Ingrese el segundo apellido de la persona";
         }
         else if (string.IsNullOrEmpty(person.fechaRegistro) || string.IsNullOrWhiteSpace(person.fechaRegistro))
         {
            Mensaje = "Ingrese una fecha";
         }
         else if (string.IsNullOrEmpty(person.estadoPersona.ToString()) || string.IsNullOrWhiteSpace(person.estadoPersona.ToString()))
         {
            Mensaje = "Seleccione el estado de la persona";
         }

         if (string.IsNullOrEmpty(Mensaje))
         {
            return objPersona.RegistrarPersona(person, out Mensaje);
         }
         else
         {
            return 0;
         }         
      }
   }
}
