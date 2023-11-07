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
