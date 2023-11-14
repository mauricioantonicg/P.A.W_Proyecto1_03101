create database BD_Proyecto1_PAW_03101
go 

use BD_Proyecto1_PAW_03101
go

create table persona(
idPersona int primary key not null,
nombrePersona varchar(45) not null,
apellido1 varchar(45) not null,
apellido2 varchar(45) not null,
fechaRegistro date not null,
estadoPersona bit default 1 not null
) 
go

create table herramienta(
idHerramienta int primary key identity,
nombreHerramienta varchar(45) not null,
descripcionHerramienta varchar(100) not null,
cantidHerramienta int not null
)
go

create table prestamoHerramienta(
idPerson int references persona(idPersona) not null,
idHerramient int references herramienta(idHerramienta) not null,
fechaPrestamoHerramienta date not null,
fechaDevoluHerramienta date not null,
estadoPrestamoHerramienta bit default 1 not null
)
go

create table devolucionHerramienta(
idPerso int references persona(idPersona) not null, 
idHerramienta int references herramienta(idHerramienta) not null,
fechaDevolucionHerramienta date not null,
estadoDevolucionHerramienta bit default 1 not null,
detallesDevolucionHerramienta varchar(100) not null
)
go

create proc sp_RegistrarPersona(
@idPersona int,
@nombrePersona varchar(45),
@apellido1 varchar(45),
@apellido2 varchar(45),
@fechaRegistro date,
@estadoPersona bit,
@Mensaje varchar (300) output,
@Resultado int output
)
as
begin
   SET @Resultado = 0

   if NOT EXISTS (select * from persona where idPersona = @idPersona)
   begin
      insert into persona(idPersona, nombrePersona, apellido1, apellido2, fechaRegistro, estadoPersona) values 
	                     (@idPersona, @nombrePersona, @apellido1, @apellido2, @fechaRegistro, @estadoPersona)

	  SET @Resultado = 1
   end
   else
   SET @Mensaje = 'El usuario ya existe'   
end

create proc sp_RegistrarHerramienta(
@idHerramienta int,
@nombreHerramienta varchar(45),
@descripcionHerramienta varchar(100),
@cantidHerramienta int,
@Mensaje varchar (300) output,
@Resultado int output
)
as
begin
   SET @Resultado = 0

   if NOT EXISTS (select * from herramienta where idHerramienta = @idHerramienta)
   begin
      insert into herramienta(nombreHerramienta, descripcionHerramienta, cantidHerramienta) values 
	                     (@nombreHerramienta, @descripcionHerramienta, @cantidHerramienta)

	  SET @Resultado = 1
   end
   else
   SET @Mensaje = 'La herramienta ya existe'   
end

create proc sp_RegistrarPrestamoHerramienta(
@idPerson int,	
@idHerramient int,
@fechaPrestamoHerramienta date,
@fechaDevoluHerramienta date,
@Mensaje varchar (300) output,
@Resultado int output
)
as
begin
   SET @Resultado = 0

   if EXISTS (select * from prestamoHerramienta where idPerson = @idPerson)
   begin
      insert into prestamoHerramienta(idPerson, idHerramient, fechaPrestamoHerramienta, fechaDevoluHerramienta, estadoPrestamoHerramienta) 
	       values (@idPerson, @idHerramient, @fechaPrestamoHerramienta, @fechaDevoluHerramienta, 1)

	  SET @Resultado = 1
   end
   else
   SET @Mensaje = 'El usuario no existe, registre el usuario'   
end
