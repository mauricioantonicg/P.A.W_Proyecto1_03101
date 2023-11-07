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


insert into persona (idPersona, nombrePersona, apellido1, apellido2, fechaRegistro, estadoPersona) 
             values (303980386, 'Mauricio', 'Calderón', 'Garro', '2023-11-05',  1) 
go


select * from persona 
go

insert into herramienta (nombreHerramienta, descripcionHerramienta, cantidHerramienta) 
                 values ('martillo', 'carpinteria', 5)
go

select * from herramienta
go

insert into prestamoHerramienta (idPerson, idHerramient, fechaPrestamoHerramienta, fechaDevoluHerramienta, estadoPrestamoHerramienta) 
                         values (303980386, 1, '2023-10-02', '2023-11-05', 1)
go

select idPerson, nombrePersona, idHerramient, nombreHerramienta from prestamoHerramienta 
inner join persona on persona.idPersona = idPerson 
inner join herramienta on herramienta.nombreHerramienta = nombreHerramienta
go

insert into devolucionHerramienta (idPerso, idHerramienta, fechaDevolucionHerramienta, estadoDevolucionHerramienta, detallesDevolucionHerramienta) 
values (303980386, 1, '2023-11-07', 1, 'En buen estado')
go

select * from devolucionHerramienta
go

select idperso as cedula, nombrePersona as nombre, devolucionHerramienta.idHerramienta, nombreHerramienta, estadoDevolucionHerramienta, detallesDevolucionHerramienta from devolucionHerramienta
inner join persona on persona.idPersona = devolucionHerramienta.idPerso
inner join herramienta on herramienta.idHerramienta = devolucionHerramienta.idHerramienta
go